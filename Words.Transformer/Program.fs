open System
open System.Collections.Concurrent
open Words
open Words.Addons
open Words.Data_Sources
open Words.Flags
open Words.Inflected
open Words.Inflection
open Words.Words
open Words.Transformer
open FSharp.Reflection

let client = SqlClient("Server=localhost;Database=test;Uid=naharie;Pwd=induction;")
let latin = LatinDictionary(LatinDictionarySettings(), TextFileDataSource())

let mutable command = ""

let insert (tableName: string) (record: 'T) =
    let fields = FSharpType.GetRecordFields (record.GetType())
    
    let names =
        fields
        |> Array.map (fun field -> $"`{field.Name}`")
        |> String.concat ", "
    let values =
        fields
        |> Array.map (fun field ->
            let value = FSharpValue.GetRecordField (record, field)
            
            if isNull value then
                value
            else
                let vType = value.GetType()
                
                if vType.IsEnum then
                    (value :?> int) |> byte |> box
                else
                    value
        )
    let parameters =
        fields
        |> Array.mapi (fun i _ -> $"@p%i{i + 1}")
        |> String.concat ", "
    
    let code = $"insert into {tableName} ({names}) values ({parameters});"
    command <- code
    
    client.Execute(code, values)

type inflected_declineable = {
    id: int
    declension: byte
    declension_variant: byte
    case: Case
    number: Number
    gender: Gender
}
type inflected_adjective = {
    id: int
    comparison: Comparison
}
type inflected_adverb = {
    id: int
    comparison: Comparison
}
type inflected_noun = {
    id: int
    kind: NounKind
}
type inflected_numeral = {
    id: int
    sorting: NumeralSorting
    value: int
}
type inflected_participle = {
    id: int
    tense: Tense
    voice: Voice
    mood: Mood
}
type inflected_preposition = {
    id: int
    case: PrepositionCase
}
type inflected_pronoun = {
    id: int
    pronoun_kind: PronounKind
}
type inflected_verb = {
    id: int
    conjugation: byte
    conjugation_variant: byte
    tense: Tense
    voice: Voice
    mood: Mood
    person: Person
    number: Number
    kind: VerbKind
}
type unique = {
    form: string
    meaning: string
    part_of_speech: PartOfSpeech
    age: Age
    subject: Subject
    geographical_source: GeographicalSource
    frequency: Frequency
    source: Source
}

let insertInflectedDeclineable id (value: InflectedDeclineable) =
    insert "inflected_declineable" {
        id = id
        declension = byte value.Declension
        declension_variant = byte value.DeclensionVariant
        case = value.Case
        number = value.Number
        gender = value.Gender 
    } |> ignore
let insertInflectedAdjective id (value: InflectedAdjective) =
    insertInflectedDeclineable id value
    
    insert "inflected_adjective" {
        id = id
        comparison = value.Comparison 
    } |> ignore
let insertInflectedAdverb id (value: InflectedAdverb) =
    insert "inflected_adverb" {
        id = id
        comparison = value.Comparison 
    } |> ignore
let insertInflectedNoun id (value: InflectedNoun) =
    insertInflectedDeclineable id value
    insert "inflected_noun" {
        id = id
        kind = value.Kind
    } |> ignore
let insertInflectedNumeral id (value: InflectedNumeral) =
    insertInflectedNoun id value
    insert "inflected_numeral" {
        id = id
        value = value.Value
        sorting = value.Sorting 
    } |> ignore
let insertInflectedParticiple id (value: InflectedParticiple) =
    insertInflectedAdjective id value
    insert "inflected_participle" {
        id = id
        tense = value.Tense
        voice = value.Voice
        mood = value.Mood 
    } |> ignore
let insertInflectedPreposition id (value: InflectedPreposition) =
    insert "inflected_preposition" {
        id = id
        case = value.Case
    } |> ignore
let insertInflectedPronoun id (value: InflectedPronoun) =
    insertInflectedNoun id value
    insert "inflected_pronoun" {
        id = id
        pronoun_kind = value.PronounKind 
    } |> ignore
let insertInflectedVerb id (value: InflectedVerb) =
    insert "inflected_verb" {
        id = id
        conjugation = byte value.Conjugation
        conjugation_variant = byte value.ConjugationVariant
        tense = value.Tense
        voice = value.Voice
        mood = value.Mood
        person = value.Person
        number = value.Number
        kind = value.Kind 
    } |> ignore

let insertInflectedForm (value: InflectedForm) =
    let id = insert "uniques" {
        form = value.Form
        meaning = value.Meaning
        part_of_speech = value.PartOfSpeech
        age = value.Age
        subject = value.Subject
        geographical_source = value.GeographicalSource
        frequency = value.Frequency
        source = value.Source 
    }
    
    match value with
    | :? InflectedParticiple as value -> insertInflectedParticiple id value
    | :? InflectedAdjective as value -> insertInflectedAdjective id value
    | :? InflectedNumeral as value -> insertInflectedNumeral id value
    | :? InflectedPronoun as value -> insertInflectedPronoun id value
    | :? InflectedNoun as value -> insertInflectedNoun id value
    | :? InflectedPreposition as value -> insertInflectedPreposition id value
    | :? InflectedVerb as value -> insertInflectedVerb id value
    | :? InflectedConjunction -> ()
    | :? InflectedInterjection -> ()
    | _ -> failwith "Unknown inflected form type"

// -----------------------------------

type inflection = {
    major: byte
    minor: byte
    part_of_speech: PartOfSpeech
    ending: string
    age: Age
    frequency: Frequency
}
type verb_inflection = {
    id: int
    tense: Tense
    voice: Voice
    mood: Mood
    person: Person
    number: Number
    is_simple: bool
}
type verbal_noun_inflection = {
    id: int
    case: Case
    gender: Gender
    supine: bool
}
type preposition_inflection = {
    id: int
    case: PrepositionCase
}
type adverb_inflection = {
    id: int
    comparison: Comparison
}
type declineable_inflection = {
    id: int
    case: Case
    number: Number
    gender: Gender
}
type adjective_inflection = {
    id: int
    comparison: Comparison
}
type numeral_inflection = {
    id: int
    sort: NumeralSorting
}

let insertVerbInflection id simple (inflection: VerbInflection) =
    insert "verb_inflections" {
        id = id
        tense = inflection.Tense
        voice = inflection.Voice
        mood = inflection.Mood
        person = inflection.Person
        number = inflection.Number
        is_simple = simple
    }
    |> ignore
let insertVerbalNounInflection id supine (inflection: VerbalNounInflection) =
    insertVerbInflection id false inflection
    insert "verbal_noun_inflections" {
        id = id
        case = inflection.Case
        gender = inflection.Gender
        supine = supine 
    }
    |> ignore
let insertSupineInflection id (inflection: SupineInflection) =
    insertVerbalNounInflection id true inflection
let insertPrepositionInflection id (inflection: PrepositionInflection) =
    insert "preposition_inflections" {
        id = id
        case = inflection.Case
    }
    |> ignore
let insertAdverbInflection id (inflection: AdverbInflection) =
    insert "adverb_inflections" {
        id = id
        comparison = inflection.Comparison 
    }
    |> ignore
let insertDeclineableInflection id (inflection: DeclineableInflection) =
    insert "declineable_inflections" {
        id = id
        case = inflection.Case
        number = inflection.Number
        gender = inflection.Gender 
    }
    |> ignore
let insertAdjectiveInflection id (inflection: AdjectiveInflection) =
    insertDeclineableInflection id inflection
    insert "adjective_inflections" {
        id = id
        comparison = inflection.Comparison 
    }
    |> ignore
let insertNumeralInflection id (inflection: NumeralInflection) =
    insertDeclineableInflection id inflection
    insert "numeral_inflections" {
        id = id
        sort = inflection.Sort
    }
    |> ignore

let insertInflection major minor (inflection: Inflection) =
    let id = insert "inflections" {
        major = byte major
        minor = byte minor
        ending = inflection.Ending
        part_of_speech = inflection.PartOfSpeech
        age = inflection.Age
        frequency = inflection.Frequency 
    }
    
    match inflection with
    | :? NounInflection as value -> insertDeclineableInflection id value
    | :? NumeralInflection as value -> insertNumeralInflection id value
    | :? PronounInflection as value -> insertDeclineableInflection id value
    | :? AdjectiveInflection as value -> insertAdjectiveInflection id value
    | :? AdverbInflection as value -> insertAdverbInflection id value
    | :? PrepositionInflection as value -> insertPrepositionInflection id value
    | :? SupineInflection as value -> insertSupineInflection id value
    | :? VerbalNounInflection as value -> insertVerbalNounInflection id false value
    | :? VerbInflection as value -> insertVerbInflection id true value
    | :? InterjectionInflection -> ()
    | :? ConjunctionInflection -> ()
    | _ -> failwith "Unknown inflection type"

// --------------------------

type addon = {
    id: int
    kind: AddonKind
    word: string
    connecting_character: Nullable<char>
    from: PartOfSpeech
    ``to``: PartOfSpeech
    meaning: string
}
type packon = {
    id: int
    is_packon: bool
}
type declineable = {
    id: int
    declension: byte
    declension_variant: byte
}
type adjective = {
    id: int
    comparison: Comparison
}
type adverb = {
    id: int
    comparison: Comparison
}
type noun = {
    id: int
    gender: Gender
    kind: NounKind
}
type verb = {
    id: int
    conjugation: byte
    conjugation_variant: byte
    verb_kind: VerbKind
}
type word = {
    id: int
    stem_a: string
    stem_b: string
    stem_c: string
    stem_d: string
    meaning: string
    part_of_speech: PartOfSpeech
    age: Age
    subject: Subject
    geographical_source: GeographicalSource
    frequency: Frequency
    source: Source
}
type pronoun = {
    id: int
    kind: PronounKind
    tackon: string
}
type preposition = {
    id: int
    case: PrepositionCase
}
type numeral = {
    id: int
    sorting: NumeralSorting
    value: int
}
type meta = {
    is_word: bool
}

let insertMeta isWord =
    insert "meta" {
        is_word = isWord 
    }

let insertDeclineable id (value: Declineable) =
    insert "declineable" {
        id = id
        declension = byte value.Declension
        declension_variant = byte value.DeclensionVariant
    } |> ignore
let insertAdjective id (value: Adjective) =
    insertDeclineable id value
    insert "adjectives" {
        id = id
        comparison = value.Comparison 
    } |> ignore
let mapAdverb id (value: Adverb) =
    {
        id = id
        comparison = value.Comparison 
    }
let insertNumeral id (value: Numeral) =
    insertDeclineable id value
    insert "numerals" {
        id = id
        sorting = value.Sorting
        value = value.Value
    } |> ignore
let mapPreposition id (value: Preposition) =
    {
        id = id
        case = value.Case
    }
let insertPackon id (value: Packon) =
    insertDeclineable id value
    insert "pronouns" {
        id = id
        kind = value.Kind
        tackon = value.Tackon 
    } |> ignore
let insertPronoun id (value: Pronoun) =
    insertDeclineable id value
    insert "pronouns" {
        id = id
        kind = value.Kind
        tackon = value.MandatoryTackon 
    } |> ignore
let insertVerb id (value: Verb) =
    insert "verbs" {
        id = id
        conjugation = byte value.Conjugation
        conjugation_variant = byte value.ConjugationVariant
        verb_kind = value.VerbKind 
    } |> ignore
let insertNoun id (value: Noun) =
    insertDeclineable id value
    insert "nouns" {
        id = id
        gender = value.Gender
        kind = value.Kind
    } |> ignore

let insertWordInfo id (info: WordInfo) =
    match info with
    | :? Adjective as value -> insertAdjective id value
    | :? Adverb as value -> insert "adverbs" (mapAdverb id value) |> ignore
    | :? Packon as value -> insertPackon id value
    | :? Pronoun as value -> insertPronoun id value
    | :? Noun as value -> insertNoun id value
    | :? Preposition as value -> insert "prepositions" (mapPreposition id value) |> ignore
    | :? Numeral as value -> insertNumeral id value
    | :? Verb as value -> insertVerb id value
    | :? Conjunction -> ()
    | :? Interjection -> ()
    | _ -> ()
let rec insertWord (value: Word) =
    match value.Info with
    | :? CombinedPronoun as value ->
        for word in value.Underlying do
            insertWord word
    | _ ->
        let id = insertMeta true
    
        insert "words" {
            id = id
            stem_a = value.StemA
            stem_b = value.StemB
            stem_c = value.StemC
            stem_d = value.StemD
            age = value.Age
            frequency = value.Frequency
            geographical_source = value.GeographicalSource
            meaning = value.Meaning
            part_of_speech = value.PartOfSpeech
            source = value.Source
            subject = value.Subject
        } |> ignore
        
        insertWordInfo id value.Info

let insertAddon (addon: Addon) =
    let id = insertMeta false
    
    insert "addons" {
        id = id
        kind = addon.Kind
        word = addon.Word
        connecting_character = addon.ConnectingCharacter
        from = addon.From
        ``to`` = addon.To
        meaning = addon.Meaning 
    } |> ignore
    
    match addon with
    | :? Prefix -> ()
    | :? Suffix as value -> insertWordInfo id value.Result
    | :? Tackon as value ->
        insert "packons" {
            id = id
            is_packon = value.IsPackon
        } |> ignore
        
        insertWordInfo id value.TargetInfo
    | _ -> failwith "Unknown addon type!"

client.Transaction (fun () ->
    for word in latin.EnumerateWords() do
        insertWord word

    for addon in latin.EnumerateAddons() do
        insertAddon addon
    
    for unique in latin.EnumerateIrregularWords() do 
        insertInflectedForm unique
        
    let processMap (map: ConcurrentDictionary<int, ConcurrentDictionary<int, ResizeArray<'t>>>) =
        for KeyValue (major, group) in map do
            for KeyValue (minor, inflections) in group do
                for inflection in inflections do
                    insertInflection major minor inflection
        
    let mapping = latin.GetInflectionMap()
    
    processMap mapping.AdjectiveInflections
    processMap mapping.NounInflections
    processMap mapping.NumeralInflections
    processMap mapping.PronounInflections
    processMap mapping.SupineInflections
    processMap mapping.VerbInflections
    processMap mapping.VerbParticipleInflections
)

printfn $"%s{command}"