using System.Collections.Concurrent;
using System.Data;
using MySqlConnector;
using Words.Addons;
using Words.Extensions;
using Words.Flags;
using Words.Inflected;
using Words.Inflection;
using Words.Words;

namespace Words.Data_Sources;

public class DatabaseDataSource: IDictionaryDataSource
{
    private readonly string dbString;

    public DatabaseDataSource(string dbString)
    {
        this.dbString = dbString;
    }

    public void CleanUp() { }

    private MySqlCommand GetCommand(MySqlConnection connection, string code, object?[] parameters)
    {
        var command = new MySqlCommand(code, connection);

        for (var i = 0; i < parameters.Length; i++)
        {
            command.Parameters.AddWithValue("@p" + (i + 1), parameters[i]);
        }

        return command;
    }
    private (string code, object?[] parameters) GetCommandParts(FormattableString command)
    {
        var parameters = command.GetArguments();
        var code = command.Format;

        for (var i = 0; i < parameters.Length; i++)
        {
            code = code.Replace("{" + i + "}", "@p" + (i + 1));
        }

        return (code, parameters);
    }

    private void ReadList(FormattableString query, Action<MySqlDataReader> processItem)
    {
        var connection = new MySqlConnection(dbString);
        connection.Open();
        
        var (code, parameters) = GetCommandParts(query);
        var command = GetCommand(connection, code, parameters);
        var reader = command.ExecuteReader();
        
        while (reader.Read())
        {
            processItem(reader);
        }
        
        reader.Close();
        connection.Close();
    }

    private static WordInfo ReadWordInfo(MySqlDataReader reader, PartOfSpeech partOfSpeech)
    {
        return partOfSpeech switch
        {
            PartOfSpeech.Noun =>
                new Noun
                {
                    Declension = reader.GetByte("declension"),
                    DeclensionVariant = reader.GetByte("declension_variant"),
                    Gender = (Gender)reader.GetByte("gender"),
                    Kind = (NounKind)reader.GetByte("kind")
                },
            PartOfSpeech.Pronoun =>
                new Pronoun
                {
                    Declension = reader.GetByte("declension"),
                    DeclensionVariant = reader.GetByte("declension_variant"),
                    Kind = (PronounKind)reader.GetByte("kind"),
                    MandatoryTackon = reader.GetStringOrNull("tackon")
                },

            PartOfSpeech.Packon =>
                new Packon
                {
                    Declension = reader.GetByte("declension"),
                    DeclensionVariant = reader.GetByte("declension_variant"),
                    Kind = (PronounKind)reader.GetByte("kind"),
                    // Can never be null *except* when loading addons.
                    Tackon = reader.GetStringOrNull("tackon") ?? ""
                },

            PartOfSpeech.Adjective =>
                new Adjective
                {
                    Declension = reader.GetByte("declension"),
                    DeclensionVariant = reader.GetByte("declension_variant"),
                    Comparison = (Comparison)reader.GetByte("comparison")
                },
            PartOfSpeech.Adverb =>
                new Adverb
                {
                    Comparison = (Comparison)reader.GetByte("comparison")
                },

            PartOfSpeech.Verb =>
                new Verb
                {
                    Conjugation = reader.GetByte("conjugation"),
                    ConjugationVariant = reader.GetByte("conjugation_variant"),
                    VerbKind = (VerbKind)reader.GetByte("verb_kind")
                },

            PartOfSpeech.Numeral =>
                new Numeral
                {
                    Declension = reader.GetByte("declension"),
                    DeclensionVariant = reader.GetByte("declension_variant"),
                    Sorting = (NumeralSorting)reader.GetByte("sorting"),
                    Value = reader.GetInt32("value")
                },
            PartOfSpeech.Preposition =>
                new Preposition
                {
                    Case = (PrepositionCase)reader.GetByte("case")
                },

            PartOfSpeech.Conjunction => new Conjunction(),
            PartOfSpeech.Interjection => new Interjection(),

            _ => throw new MalformedDictionaryEntryException($"Failed to understand {partOfSpeech} as a valid word info kind.")
        };
    }
    
    private ((string meaning, InflectedForm form)[] EnglishIrregularLookup, InflectedForm[] IrregularWords) LoadUniques(ConcurrentDictionary<string, List<(InflectedForm, Word?)>> lookupList)
    {
        var englishIrregularLookup = new List<(string meaning, InflectedForm form)>();
        var irregularWords = new List<InflectedForm>();
        
        Parallel.Invoke(
            () =>
                // Adjectives
                ReadList($"""
                    select
                        /* Common */
                        form, meaning, part_of_speech, age, subject, geographical_source, frequency, source,
                        /* Unique */
                        comparison
                    from uniques
                    join inflected_adjective on inflected_adjective.id = uniques.id
                    left outer join inflected_participle on inflected_adjective.id = inflected_participle.id
                """, LoadUnique),
            
            () =>
                // Adverbs
                ReadList($"""
                    select
                        /* Common */
                        form, meaning, part_of_speech, age, subject, geographical_source, frequency, source,
                        /* Unique */
                        comparison
                    from uniques
                    join inflected_adverb on inflected_adverb.id = uniques.id
                """, LoadUnique),
            
            () =>
                // Prepositions
                ReadList($"""
                    select
                        /* Common */
                        form, meaning, part_of_speech, age, subject, geographical_source, frequency, source,
                        /* Unique */
                        `case`
                    from uniques
                    join inflected_preposition on inflected_preposition.id = uniques.id
                """, LoadUnique),
            
            () =>
                // Participles
                ReadList($"""
                    select
                        /* Common */
                        form, meaning, part_of_speech, age, subject, geographical_source, frequency, source,
                        /* Unique */
                        comparison, tense, voice, mood
                    from uniques
                    join inflected_adjective on inflected_adjective.id = uniques.id
                    join inflected_participle on inflected_adjective.id = inflected_participle.id
                """, LoadUnique),
            
            () =>
                // Verbs
                ReadList($"""
                    select
                        /* Common */
                        form, meaning, part_of_speech, age, subject, geographical_source, frequency, source,
                        /* Unique */
                        conjugation, conjugation_variant, tense, voice, mood, person, number, kind
                    from uniques
                    join inflected_verb on inflected_verb.id = uniques.id
                """, LoadUnique),
            
            () =>
                // Nouns
                ReadList($"""
                    select
                        /* Common */
                        form, meaning, part_of_speech, age, subject, geographical_source, frequency, source,
                        /* Declineable */
                        declension, declension_variant, `case`, number, gender,
                        /* Unique */
                        kind
                    from uniques
                    join inflected_declineable on uniques.id = inflected_declineable.id
                    join inflected_noun on inflected_declineable.id = inflected_noun.id
                    where part_of_speech = {(byte)PartOfSpeech.Noun}
                """, LoadUnique),
            
            () =>
                // Numerals
                ReadList($"""
                    select
                        /* Common */
                        form, meaning, part_of_speech, age, subject, geographical_source, frequency, source,
                        /* Declineable */
                        declension, declension_variant, `case`, number, gender,
                        /* Unique */
                        sorting, value
                    from uniques
                    join inflected_declineable on uniques.id = inflected_declineable.id
                    join inflected_numeral on inflected_numeral.id = inflected_declineable.id
                """, LoadUnique),
            
            () =>
                // Pronouns and Packons
                ReadList($"""
                    select
                        /* Common */
                        form, meaning, part_of_speech, age, subject, geographical_source, frequency, source,
                        /* Declineable */
                        declension, declension_variant, `case`, number, gender,
                        /* Unique */
                        kind, pronoun_kind
                    from uniques
                    join inflected_declineable on uniques.id = inflected_declineable.id
                    join inflected_noun on inflected_declineable.id = inflected_noun.id
                    join inflected_pronoun on inflected_pronoun.id = inflected_declineable.id
                """, LoadUnique)
        );
        
        return (englishIrregularLookup.ToArray(), irregularWords.ToArray());

        void LoadUnique(MySqlDataReader reader)
        {
            var partOfSpeech = (PartOfSpeech)reader.GetByte("part_of_speech");
            InflectedForm inflectedForm = partOfSpeech switch
            {
                PartOfSpeech.Adjective =>
                    new InflectedAdjective
                    {
                        Comparison = (Comparison)reader.GetByte("comparison")
                    },
                PartOfSpeech.Adverb =>
                    new InflectedAdverb
                    {
                        Comparison = (Comparison)reader.GetByte("comparison")
                    },
                PartOfSpeech.Preposition =>
                    new InflectedPreposition
                    {
                        Case = (PrepositionCase)reader.GetByte("case")
                    },
                PartOfSpeech.VerbParticiple =>
                    new InflectedParticiple
                    {
                        Comparison = (Comparison)reader.GetByte("comparison"),
                        Tense = (Tense)reader.GetByte("tense"),
                        Voice = (Voice)reader.GetByte("voice"),
                        Mood = (Mood)reader.GetByte("mood")
                    },
                PartOfSpeech.Verb =>
                    new InflectedVerb
                    {
                        Conjugation = reader.GetByte("conjugation"),
                        ConjugationVariant = reader.GetByte("conjugation_variant"),
                        Tense = (Tense)reader.GetByte("tense"),
                        Voice = (Voice)reader.GetByte("voice"),
                        Mood = (Mood)reader.GetByte("mood"),
                        Person = (Person)reader.GetByte("person"),
                        Number = (Number)reader.GetByte("number"),
                        Kind = (VerbKind)reader.GetByte("kind")
                    },
                PartOfSpeech.Noun =>
                    new InflectedNoun
                    {
                        Declension = reader.GetByte("declension"),
                        DeclensionVariant = reader.GetByte("declension_variant"),
                        Case = (Case)reader.GetByte("case"),
                        Number = (Number)reader.GetByte("number"),
                        Gender = (Gender)reader.GetByte("gender"),
                        Kind = (NounKind)reader.GetByte("kind")
                    },
                PartOfSpeech.Numeral =>
                    new InflectedNumeral
                    {
                        Declension = reader.GetByte("declension"),
                        DeclensionVariant = reader.GetByte("declension_variant"),
                        Case = (Case)reader.GetByte("case"),
                        Number = (Number)reader.GetByte("number"),
                        Gender = (Gender)reader.GetByte("gender"),
                        Sorting = (NumeralSorting)reader.GetByte("sorting"),
                        Value = reader.GetInt32("value")
                    },
                PartOfSpeech.Pronoun or PartOfSpeech.Packon =>
                    new InflectedPronoun()
                    {
                        Declension = reader.GetByte("declension"),
                        DeclensionVariant = reader.GetByte("declension_variant"),
                        Case = (Case)reader.GetByte("case"),
                        Number = (Number)reader.GetByte("number"),
                        Gender = (Gender)reader.GetByte("gender"),
                        Kind = (NounKind)reader.GetByte("kind"),
                        PronounKind = (PronounKind)reader.GetByte("pronoun_kind")
                    },
                
                _ => throw new MalformedDictionaryEntryException(partOfSpeech + " is not understood as a valid unique type!")
            };

            inflectedForm.Form = reader.GetString("form");
            inflectedForm.Meaning = reader.GetString("meaning");
            inflectedForm.PartOfSpeech = partOfSpeech;
            inflectedForm.Age = (Age)reader.GetByte("age");
            inflectedForm.Subject = (Subject)reader.GetByte("subject");
            inflectedForm.GeographicalSource = (GeographicalSource)reader.GetByte("geographical_source");
            inflectedForm.Frequency = (Frequency)reader.GetByte("frequency");
            inflectedForm.Source = (Source)reader.GetByte("source");
            
            irregularWords.Add(inflectedForm);
            englishIrregularLookup.AddRange(inflectedForm.Meaning.Split(LatinDictionary.WordSeparators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(part => (part, inflectedForm)));
        }
    }
    public WordTables LoadWords(LatinDictionarySettings settings, LatinDictionary dictionary)
    {
        var tables = new WordTables();

        var latinTable = tables.LookupTable;
        var extendedLookup = tables.ExtendedLookupTable;
        var wordList = new List<Word>(40_000);
        
        var pronouns = new ConcurrentDictionary<(string meaning, PronounKind kind), List<Word>>();

        Parallel.Invoke(
            () => 
                // Adjectives
                ReadList($"""
                    select
                        /* Generic to all words */
                        stem_a, stem_b, stem_c, stem_d,
                        meaning,
                        part_of_speech,
                        age, subject, geographical_source, frequency, source,
                    
                        /* Specific */
                        declension, declension_variant, comparison
                    from meta
                    join words on words.id = meta.id
                    join adjectives on adjectives.id = meta.id
                    join declineable on declineable.id = meta.id
                    where is_word
                """, LoadWord),
            
            () =>
                // Adverbs
                ReadList($"""
                    select
                        /* Generic to all words */
                        stem_a, stem_b, stem_c, stem_d,
                        meaning,
                        part_of_speech,
                        age, subject, geographical_source, frequency, source,
                    
                        /* Specific */
                        comparison
                    from meta
                    join words on words.id = meta.id
                    join adverbs on meta.id = adverbs.id
                    where is_word
                """, LoadWord),
            
            () =>
                // Nouns
                ReadList($"""
                    select
                        /* Generic to all words */
                        stem_a, stem_b, stem_c, stem_d,
                        meaning,
                        part_of_speech,
                        age, subject, geographical_source, frequency, source,
                    
                        /* Specific */
                        declension, declension_variant, gender, kind
                    from meta
                    join words on words.id = meta.id
                    join nouns on nouns.id = meta.id
                    join declineable on declineable.id = meta.id
                    where is_word
                """, LoadWord),
            
            () =>
                // Numerals
                ReadList($"""
                    select
                        /* Generic to all words */
                        stem_a, stem_b, stem_c, stem_d,
                        meaning,
                        part_of_speech,
                        age, subject, geographical_source, frequency, source,
                    
                        /* Specific */
                        declension, declension_variant, sorting, value
                    from meta
                    join words on words.id = meta.id
                    join numerals on numerals.id = meta.id
                    join declineable on declineable.id = meta.id
                    where is_word
                """, LoadWord),
            
            () =>
                // Prepositions
                ReadList($"""
                    select
                        /* Generic to all words */
                        stem_a, stem_b, stem_c, stem_d,
                        meaning,
                        part_of_speech,
                        age, subject, geographical_source, frequency, source,
                    
                        /* Specific */
                        `case`
                    from meta
                    join words on words.id = meta.id
                    join prepositions on words.id = prepositions.id
                    where is_word
                """, LoadWord),
            
            () =>
                // Pronouns
                ReadList($"""
                    select
                        /* Generic to all words */
                        stem_a, stem_b, stem_c, stem_d,
                        meaning,
                        part_of_speech,
                        age, subject, geographical_source, frequency, source,
                    
                        /* Specific */
                        declension, declension_variant, kind, tackon
                    from meta
                    join words on words.id = meta.id
                    join pronouns on pronouns.id = meta.id
                    join declineable on declineable.id = meta.id
                    where is_word
                """, LoadWord),
            
            () =>
                // Verbs
                ReadList($"""
                    select
                        /* Generic to all words */
                        stem_a, stem_b, stem_c, stem_d,
                        meaning,
                        part_of_speech,
                        age, subject, geographical_source, frequency, source,
                    
                        /* Specific */
                        conjugation, conjugation_variant, verb_kind
                    from meta
                    join words on words.id = meta.id
                    join verbs on meta.id = verbs.id
                    where is_word
                """, LoadWord)
        );
        
        var quCuPronouns =
            pronouns.Values
                .Where(word => word[0].PartOfSpeech != PartOfSpeech.Packon && word[0].Info is Pronoun { Declension: 1 } && word[0].StemA == "qu")
                .Select(list => (((Pronoun)list[0].Info).Kind, list.Select(word => word.Info is Pronoun pronoun ? (pronoun.Declension, pronoun.DeclensionVariant) : (0, 0)).ToArray()))
                .DistinctBy(group => group.Kind)
                .ToDictionary(group => group.Kind, group => group.Item2);
        
        foreach (var group in pronouns.Values)
        {
            var primary = group[0];
            if (primary.Info is not Pronoun primaryInfo) continue;
            
            // ReSharper disable once StringLiteralTypo
            var quStem = group.All(word => word.StemA is "qu" or "aliqu");
            
            // Normal pronouns
            if (group.Count == 1 || !quStem && primary.PartOfSpeech != PartOfSpeech.Packon)
            {
                for (var i = 0; i < group.Count; i++)
                {
                    var word = group[i];
                    var inflected = dictionary.Inflect(word, true);

                    wordList.Add(word);
            
                    foreach (var form in inflected)
                    {
                        if (string.IsNullOrWhiteSpace(form.Form)) continue;
                        latinTable?.GetOrAdd(form.Form, static _ => []).Add((form, word));
                    }
                }
            }
            // Merged pronouns
            else
            {
                var extraDeclension = primary.Info is Packon packon
                    ? quCuPronouns[packon.Kind]
                    : Array.Empty<(int, int)>();
                
                var declensions =
                    group
                        .Select(word => word.Info is Pronoun pronoun ? (pronoun.Declension, pronoun.DeclensionVariant) : (0, 0))
                        .Concat(extraDeclension)
                        .Distinct()
                        .ToArray();

                var merged = new CombinedPronoun()
                {
                    Declension = primaryInfo.Declension,
                    DeclensionVariant = primaryInfo.DeclensionVariant,
                    Declensions = declensions,
                
                    Kind = primaryInfo.Kind,
                    MandatoryTackon = primaryInfo.MandatoryTackon
                };
                var word = primary with { Info = merged };
                var inflected = dictionary.Inflect(word, true);

                wordList.Add(word);
            
                foreach (var form in inflected)
                {
                    if (string.IsNullOrWhiteSpace(form.Form)) continue;
                    latinTable?.GetOrAdd(form.Form, static (_, _) => new List<(InflectedForm, Word?)>(), 0).Add((form, word));
                }
            }
        }
        
        if (latinTable != null)
        {
            LoadUniques(latinTable);
        }

        var (irregularLookup, irregularWords) = LoadUniques(latinTable ?? new());
        
        return new WordTables()
        {
            LookupTable = tables.LookupTable,
            ExtendedLookupTable = tables.ExtendedLookupTable,
            IrregularWords = irregularWords,
            EnglishIrregularLookup = irregularLookup,
            WordList = wordList.ToArray()
        };
        
        void HandleWord(Word word)
        {
            if (word.Info is Pronoun pronoun)
            {
                pronouns.GetOrAdd((word.Meaning, pronoun.Kind), static (_, _) => [], 0).Add(word);
            }
            else
            {
                var inflected = dictionary.Inflect(word, true);

                wordList.Add(word);
            
                foreach (var form in inflected)
                {
                    if (string.IsNullOrWhiteSpace(form.Form)) continue;
                    latinTable?.GetOrAdd(form.Form, static _ => []).Add((form, word));
                }
            }

            if (!settings.UseExtendedLookupTable) return;

            var completed = new ConcurrentDictionary<WordInfo, ConcurrentDictionary<string, List<(InflectedForm, Word?)>>>();
            
            // It's actually ~200ms slower to use Parallel.ForEach here.
            foreach (var suffix in dictionary.EnumerateSuffixes())
            {
                if (suffix.From == suffix.To || suffix.From != word.PartOfSpeech) continue;

                if (completed.TryGetValue(suffix.Result, out var existingTable))
                {
                    extendedLookup[suffix] = existingTable;
                }
                else
                {
                    var suffixTable = extendedLookup.GetOrAdd(suffix, static (_, _) => new(), 0);
                    completed[suffix.Result] = suffixTable;
                    
                    var extended = word with
                    {
                        PartOfSpeech = suffix.To,
                        Info = suffix.Result
                    };
                    var extendedInflections = dictionary.Inflect(extended, true);
                
                    foreach (var form in extendedInflections)
                    {
                        if (string.IsNullOrWhiteSpace(form.Form)) continue;
                        suffixTable.GetOrAdd(form.Form, static (_, _) => new List<(InflectedForm, Word?)>(), 0).Add((form, word));
                    }
                }
            }
        }
        void LoadWord(MySqlDataReader reader)
        {
            var word = new Word
            {
                StemA = reader.GetStringOrNull("stem_a"),
                StemB = reader.GetStringOrNull("stem_b"),
                StemC = reader.GetStringOrNull("stem_c"),
                StemD = reader.GetStringOrNull("stem_d"),

                PartOfSpeech = (PartOfSpeech)reader.GetByte("part_of_speech"),
                Age = (Age)reader.GetByte("age"),
                Subject = (Subject)reader.GetByte("subject"),
                GeographicalSource = (GeographicalSource)reader.GetByte("geographical_source"),
                Frequency = (Frequency)reader.GetByte("frequency"),
                Source = (Source)reader.GetByte("source"),
                Meaning = reader.GetString("meaning")
            };

            word.Info = ReadWordInfo(reader, word.PartOfSpeech); 
            HandleWord(word);
        }
    }

    public (InflectionMaps mapping, Inflection.Inflection[] inflections) LoadInflections(LatinDictionarySettings settings)
    {
        var mapping = new InflectionMaps();
        var inflections = new List<Inflection.Inflection>();
        
        // Nouns
        ReadList($"""
            select
                /* Common */
                part_of_speech, ending, age, frequency, major, minor,
                /* Special */
                `case`, number, gender
            from inflections
            join declineable_inflections on inflections.id = declineable_inflections.id
            where part_of_speech in ({(byte)PartOfSpeech.Noun}, {(byte)PartOfSpeech.Pronoun})
        """, ReadInflection);
        
        // Adjectives
        ReadList($"""
            select
                /* Common */
                part_of_speech, ending, age, frequency, major, minor,
                /* Special */
                `case`, number, gender, comparison
            from inflections
            join declineable_inflections on inflections.id = declineable_inflections.id
            join adjective_inflections on inflections.id = adjective_inflections.id
        """, ReadInflection);
        
        // Numerals
        ReadList($"""
            select
                /* Common */
                part_of_speech, ending, age, frequency, major, minor,
                /* Special */
                `case`, number, gender, sort
            from inflections
            join declineable_inflections on inflections.id = declineable_inflections.id
            join numeral_inflections on inflections.id = numeral_inflections.id
        """, ReadInflection);
        
        // Verbs
        ReadList($"""
            select
                /* Common */
                part_of_speech, ending, age, frequency, major, minor,
                /* Special */
                tense, voice, mood, person, number
            from inflections
            join verb_inflections on inflections.id = verb_inflections.id
            where is_simple
        """, ReadInflection);
        
        // Verb Participles
        ReadList($"""
            select
                /* Common */
                part_of_speech, ending, age, frequency, major, minor,
                /* Special */
                tense, voice, mood, person, number, `case`, gender
            from inflections
            join verb_inflections on inflections.id = verb_inflections.id
            join verbal_noun_inflections on inflections.id = verbal_noun_inflections.id
            where not supine
        """, ReadInflection);
        
        // Supine
        ReadList($"""
            select
                /* Common */
                part_of_speech, ending, age, frequency, major, minor,
                /* Special */
                tense, voice, mood, person, number, `case`, gender
            from inflections
            join verb_inflections on inflections.id = verb_inflections.id
            join verbal_noun_inflections on inflections.id = verbal_noun_inflections.id
            where supine
        """, ReadInflection);
        
        // Prepositions
        ReadList($"""
            select
                /* Common */
                part_of_speech, ending, age, frequency, major, minor,
                /* Special */
                `case`
            from inflections
            join preposition_inflections on inflections.id = preposition_inflections.id
        """, ReadInflection);
        
        FinalizeGroups(mapping.NounInflections);
        FinalizeGroups(mapping.VerbInflections);
        FinalizeGroups(mapping.AdjectiveInflections);
        FinalizeGroups(mapping.NumeralInflections);
        FinalizeGroups(mapping.PronounInflections);
        FinalizeGroups(mapping.SupineInflections);
        FinalizeGroups(mapping.VerbParticipleInflections);

        return (mapping, inflections.ToArray());

        static void FinalizeGroups<T>(ConcurrentDictionary<int, ConcurrentDictionary<int, List<T>>> table)
        {
            foreach (var variant in table.Values)
            {
                foreach (var list in variant.Values)
                {
                    list.TrimExcess();
                }
            }
        }
        static T AddInflection<T>(ConcurrentDictionary<int, ConcurrentDictionary<int, List<T>>> table, int group, int groupVariant, T value)
        {
            table.GetOrAdd(group, _ => new()).GetOrAdd(groupVariant, _ => []).Add(value);
            return value;
        }
        void ReadInflection(MySqlDataReader reader)
        {
            var partOfSpeech = (PartOfSpeech)reader.GetByte("part_of_speech");
            var major = reader.GetByte("major");
            var minor = reader.GetByte("minor");

            Inflection.Inflection inflection = partOfSpeech switch
            {
                PartOfSpeech.Noun => AddInflection(mapping.NounInflections, major, minor,
                    new NounInflection
                    {
                        Declension = reader.GetByte("major"),
                        DeclensionVariant = reader.GetByte("minor"),
                        Case = (Case)reader.GetByte("case"),
                        Number = (Number)reader.GetByte("number"),
                        Gender = (Gender)reader.GetByte("gender")
                    }),
                PartOfSpeech.Pronoun or PartOfSpeech.Packon => AddInflection(mapping.PronounInflections, major, minor,
                    new PronounInflection
                    {
                        Declension = reader.GetByte("major"),
                        DeclensionVariant = reader.GetByte("minor"),
                        Case = (Case)reader.GetByte("case"),
                        Number = (Number)reader.GetByte("number"),
                        Gender = (Gender)reader.GetByte("gender")
                    }),
                PartOfSpeech.Adjective => AddInflection(mapping.AdjectiveInflections, major, minor,
                    new AdjectiveInflection
                    {
                        Declension = reader.GetByte("major"),
                        DeclensionVariant = reader.GetByte("minor"),
                        Case = (Case)reader.GetByte("case"),
                        Number = (Number)reader.GetByte("number"),
                        Gender = (Gender)reader.GetByte("gender"),
                        Comparison = (Comparison)reader.GetByte("comparison")
                    }),
                PartOfSpeech.Numeral => AddInflection(mapping.NumeralInflections, major, minor,
                    new NumeralInflection
                    {
                        Declension = reader.GetByte("major"),
                        DeclensionVariant = reader.GetByte("minor"),
                        Case = (Case)reader.GetByte("case"),
                        Number = (Number)reader.GetByte("number"),
                        Gender = (Gender)reader.GetByte("gender"),
                        Sort = (NumeralSorting)reader.GetByte("sort")
                    }),
                PartOfSpeech.Verb => AddInflection(mapping.VerbInflections, major, minor,
                    new VerbInflection()
                    {
                        Conjugation = reader.GetByte("major"),
                        ConjugationVariant = reader.GetByte("minor"),
                        Tense = (Tense)reader.GetByte("tense"),
                        Voice = (Voice)reader.GetByte("voice"),
                        Mood = (Mood)reader.GetByte("mood"),
                        Person = (Person)reader.GetByte("person"),
                        Number = (Number)reader.GetByte("number")
                    }),
                PartOfSpeech.VerbParticiple => AddInflection(mapping.VerbParticipleInflections, major, minor,
                    new VerbalNounInflection()
                    {
                        Conjugation = reader.GetByte("major"),
                        ConjugationVariant = reader.GetByte("minor"),
                        Tense = (Tense)reader.GetByte("tense"),
                        Voice = (Voice)reader.GetByte("voice"),
                        Mood = (Mood)reader.GetByte("mood"),
                        Person = (Person)reader.GetByte("person"),
                        Number = (Number)reader.GetByte("number"),
                        Case = (Case)reader.GetByte("case"),
                        Gender = (Gender)reader.GetByte("gender")
                    }),
                PartOfSpeech.Supine => AddInflection(mapping.SupineInflections, major, minor,
                    new SupineInflection
                    {
                        Conjugation = reader.GetByte("major"),
                        ConjugationVariant = reader.GetByte("minor"),
                        Tense = (Tense)reader.GetByte("tense"),
                        Voice = (Voice)reader.GetByte("voice"),
                        Mood = (Mood)reader.GetByte("mood"),
                        Person = (Person)reader.GetByte("person"),
                        Number = (Number)reader.GetByte("number"),
                        Case = (Case)reader.GetByte("case"),
                        Gender = (Gender)reader.GetByte("gender")
                    }),
                _ => throw new MalformedDictionaryEntryException("Unknown or invalid part of speech!")
            };

            inflection.PartOfSpeech = partOfSpeech;
            inflection.Frequency = (Frequency)reader.GetByte("frequency");
            inflection.Age = (Age)reader.GetByte("age");
            inflection.Ending = reader.GetString("ending");
            
            inflections.Add(inflection);
        }
    }

    public (Prefix[] prefixes, Suffix[] suffixes, Tackon[] tackons, Tackon[] packons) LoadAddons(
        LatinDictionarySettings settings)
    {
        var prefixes = new List<Prefix>();
        var suffixes = new List<Suffix>();
        var tackons = new List<Tackon>();
        var packons = new List<Tackon>();

        Parallel.Invoke(
            () =>
                ReadList($"""
                    select kind, word, connecting_character, `from`, `to`, meaning
                    from addons
                    where kind = {(byte)AddonKind.Prefix}
                """, ReadAddon),
            
            () =>
                ReadList($"""
                    select * from meta
                    join addons on meta.id = addons.id
                    join adjectives on adjectives.id = meta.id
                    join declineable on meta.id = declineable.id
                    where !is_word
                """, ReadAddon),
            
            () =>
                ReadList($"""
                    select * from meta
                    join addons on meta.id = addons.id
                    join adverbs on adverbs.id = meta.id
                    where !is_word
                """, ReadAddon),
            
            () =>
                ReadList($"""
                    select * from meta
                    join addons on meta.id = addons.id
                    join nouns on nouns.id = meta.id
                    join declineable on meta.id = declineable.id
                    where !is_word
                """, ReadAddon),
            
            () =>
                ReadList($"""
                    select * from meta
                    join addons on meta.id = addons.id
                    join numerals on numerals.id = meta.id
                    join declineable on meta.id = declineable.id
                    where !is_word
                """, ReadAddon),
            
            () =>
                ReadList($"""
                    select * from meta
                    join addons on meta.id = addons.id
                    join prepositions on prepositions.id = meta.id
                    where !is_word
                """, ReadAddon),
            
            () =>
                ReadList($"""
                    select * from meta
                    join addons on meta.id = addons.id
                    join pronouns on pronouns.id = meta.id
                    join declineable on meta.id = declineable.id
                    where !is_word
                """, ReadAddon),
            
            () =>
                ReadList($"""
                    select * from meta
                    join addons on meta.id = addons.id
                    join verbs on verbs.id = meta.id
                    where !is_word
                """, ReadAddon)
        );
        
        return (prefixes.ToArray(), suffixes.ToArray(), tackons.ToArray(), packons.ToArray());

        T Add<T>(ICollection<T> list, T item)
        {
            list.Add(item);
            return item;
        }
        void ReadAddon(MySqlDataReader reader)
        {
            var kind = (AddonKind)reader.GetByte("kind");
            var from = (PartOfSpeech)reader.GetByte("from");
            
            Addon addon = kind switch
            {
                AddonKind.Prefix => Add(prefixes, new Prefix()),
                AddonKind.Suffix => Add(suffixes, new Suffix
                {
                    Result = ReadWordInfo(reader, (PartOfSpeech)reader.GetByte("to"))
                }),
                AddonKind.Tackon => from is PartOfSpeech.Packon ?
                    Add(packons, new Tackon { TargetInfo = ReadWordInfo(reader, from) }) :
                    Add(tackons, new Tackon { TargetInfo = ReadWordInfo(reader, from) }),
                _ => throw new MalformedDictionaryEntryException("Non existent addon kind recorded!")
            };

            addon.Kind = kind;
            addon.Word = reader.GetString("word");
            addon.ConnectingCharacter = reader.GetCharOrNull("connecting_character");
            addon.From = from;
            addon.To = (PartOfSpeech)reader.GetByte("to");
            addon.Meaning = reader.GetString("meaning");
        }
    }
}