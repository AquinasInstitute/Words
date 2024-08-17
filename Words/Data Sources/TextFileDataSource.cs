using System.Collections.Concurrent;
using System.Reflection;
using Microsoft.VisualBasic.FileIO;
using Words.Addons;
using Words.Extensions;
using Words.Flags;
using Words.Inflected;
using Words.Inflection;
using Words.Tricks;
using Words.Words;

namespace Words.Data_Sources;

public class TextFileDataSource: IDictionaryDataSource
{
    public TextFileDataSource()
    {
        var assemblyPath = Assembly.GetExecutingAssembly().Location;
        var assemblyDir = Path.GetDirectoryName(assemblyPath) ?? "./";
        Directory.SetCurrentDirectory(assemblyDir);
    }
    
    private static PartOfSpeech PartOfSpeechFrom(string chunk)
    {
        return chunk.ToUpper() switch
        {
            "X" => PartOfSpeech.Unknown,
            "N" => PartOfSpeech.Noun,
            "PRON" => PartOfSpeech.Pronoun,
            "PACK" => PartOfSpeech.Packon,
            "ADJ" => PartOfSpeech.Adjective,
            "NUM" => PartOfSpeech.Numeral,
            "ADV" => PartOfSpeech.Adverb,
            "V" => PartOfSpeech.Verb,
            "VPAR" => PartOfSpeech.VerbParticiple,
            "SUPINE" => PartOfSpeech.Supine,
            "PREP" => PartOfSpeech.Preposition,
            "CONJ" => PartOfSpeech.Conjunction,
            "INTERJ" => PartOfSpeech.Interjection,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known part of speech.")
        };   
    }
    private static PartOfSpeech ReadPartOfSpeech(StreamReader file)
    {
        return PartOfSpeechFrom(file.ReadString());
    }
    
    private static Gender ReadGender(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => Gender.Unknown,
            "M" => Gender.Masculine,
            "F" => Gender.Feminine,
            "N" => Gender.Neuter,
            "C" => Gender.Common,
            
            _ => throw new MalformedLineException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known Latin gender.")
        };
    }
    private static NounKind ReadNounKind(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => NounKind.Unknown,
            "S" => NounKind.SingularOnly,
            "M" => NounKind.PluralOnly,
            "A" => NounKind.AbstractIdea,
            "G" => NounKind.CollectiveName,
            "N" => NounKind.ProperName,
            "P" => NounKind.Person,
            "T" => NounKind.Thing,
            "L" => NounKind.Locale,
            "W" => NounKind.Place,
            
            _ => throw new MalformedLineException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known kind of Latin noun.")
        };
    }
    private static PronounKind ReadPronounKind(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => PronounKind.Unknown,
            "PERS" => PronounKind.Personal,
            "REL" => PronounKind.Relative,
            "REFLEX" => PronounKind.Reflexive,
            "DEMONS" => PronounKind.Demonstrative,
            "INTERR" => PronounKind.Interrogative,
            "INDEF" => PronounKind.Indefinite,
            "ADJECT" => PronounKind.Adjectival,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known pronoun kind.")
        };
    }
    private static Comparison ReadComparison(StreamReader file)
    {
        var chunk = file.ReadString();

        return chunk switch
        {
            "X" => Comparison.Unknown,
            "POS" => Comparison.Positive,
            "COMP" => Comparison.Comparative,
            "SUPER" => Comparison.Superlative,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known adjectival comparison kin.")
        };
    }
    private static VerbKind ReadVerbKind(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => VerbKind.Unknown,
            "TO_BE" => VerbKind.ToBe,
            "TO_BEING" => VerbKind.ToBeing,
            "GEN" => VerbKind.TakesGenitive,
            "DAT" => VerbKind.TakesDative,
            "ABL" => VerbKind.TakesAblative,
            "TRANS" => VerbKind.Transitive,
            "INTRANS" => VerbKind.Intransitive,
            "IMPERS" => VerbKind.Impersonal,
            "DEP" => VerbKind.Deponent,
            "SEMIDEP" => VerbKind.SemiDeponent,
            "PERFDEF" => VerbKind.PerfectDefinitive,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known verb kind.")
        };
    }
    private static NumeralSorting ReadNumeralSorting(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => NumeralSorting.Unknown,
            "CARD" => NumeralSorting.Cardinal,
            "ORD" => NumeralSorting.Ordinal,
            "DIST" => NumeralSorting.Distributive,
            "ADVERB" => NumeralSorting.Adverb,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known numeral sorting kind.")
        };
    }
    private static PrepositionCase ReadPrepositionCase(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => PrepositionCase.Unknown,
            "NOM" => PrepositionCase.Nominative,
            "VOC" => PrepositionCase.Vocative,
            "GEN" => PrepositionCase.Genitive,
            "LOC" => PrepositionCase.Locative,
            "DAT" => PrepositionCase.Dative,
            "ABL" => PrepositionCase.Ablative,
            "ACC" => PrepositionCase.Accusative,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known preposition case.")
        };
    }
    private static Case ReadCase(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => Case.Unknown,
            "NOM" => Case.Nominative,
            "VOC" => Case.Vocative,
            "GEN" => Case.Genitive,
            "LOC" => Case.Locative,
            "DAT" => Case.Dative,
            "ABL" => Case.Ablative,
            "ACC" => Case.Accusative,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known word case.")
        };
    }
    private static Age ReadAge(StreamReader file)
    {
        var chunk = file.ReadString();

        return chunk switch
        {
            "X" => Age.Unknown,
            "A" => Age.VeryEarly,
            "B" => Age.Early,
            "C" => Age.Classical,
            "D" => Age.LateOrPostClassical,
            "E" => Age.PostClassical,
            "F" => Age.Medieval,
            "G" => Age.Scientific,
            "H" => Age.Modern,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known Latin word age.")
        };
    }
    private static Subject ReadSubject(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => Subject.None,
            "A" => Subject.Agriculture,
            "B" => Subject.Biology,
            "D" => Subject.Art,
            "E" => Subject.Religion,
            "G" => Subject.Literature,
            "L" => Subject.Legal,
            "P" => Subject.Poetic,
            "S" => Subject.Science,
            "T" => Subject.Technical,
            "W" => Subject.War,
            "Y" => Subject.Mythology,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known subject area.")
        };
    }
    private static GeographicalSource ReadGeographicalSource(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => GeographicalSource.None,
            "A" => GeographicalSource.Africa,
            "B" => GeographicalSource.Britain,
            "C" => GeographicalSource.China,
            "D" => GeographicalSource.Scandinavia,
            "E" => GeographicalSource.Egypt,
            "F" => GeographicalSource.France,
            "G" => GeographicalSource.Germany,
            "H" => GeographicalSource.Greece,
            "I" => GeographicalSource.Italy,
            "J" => GeographicalSource.India,
            "K" => GeographicalSource.Balkans,
            "N" => GeographicalSource.Netherlands,
            "P" => GeographicalSource.Persia,
            "Q" => GeographicalSource.NearEast,
            "R" => GeographicalSource.Russia,
            "S" => GeographicalSource.Spain,
            "U" => GeographicalSource.EasternEurope,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known geographical source.")
        };
    }
    private static Frequency ReadFrequency(StreamReader file)
    {
        var chunk = file.ReadString();

        return chunk switch
        {
            "X" => Frequency.Unspecified,
            "A" => Frequency.VeryFrequent,
            "B" => Frequency.Frequent,
            "C" => Frequency.Common,
            "D" => Frequency.LessCommon,
            "E" => Frequency.Uncommon,
            "F" => Frequency.VeryRare,
            "I" => Frequency.Inscription,
            "M" => Frequency.Graffiti,
            "N" => Frequency.Pliny,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known word usage frequency.")
        };
    }
    private static Source ReadSource(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => Source.Unknown,
            "B" => Source.APrimerOfMedievalLatin,
            "C" => Source.CassellsLatinDictionary,
            "D" => Source.LatinSexualVocabulary,
            "E" => Source.DictionaryOfEccles,
            "F" => Source.DictionaryOfStThomasAquinas,
            "G" => Source.LatinGrammar1895,
            "H" => Source.CollatinusDictionary,
            "I" => Source.LexiconOfTheLatinLanguage,
            "J" => Source.DeLegibusEtConsuetudinibusAngliae,
            "K" => Source.CalephinusNovus,
            "L" => Source.ElementaryLatuinDictionary,
            "M" => Source.RevisedMedievalWordList,
            "N" => Source.Wordlist,
            "O" => Source.OxfordLatinDictionary,
            "P" => Source.AGlossaryOfLaterLatinTo600AD,
            "Q" => Source.Unspecified,
            "R" => Source.AGrammarOfTheVulgate,
            "S" => Source.ALatinDictionary1879,
            "T" => Source.FoundInTranslation,
            "V" => Source.VademecumInOpusSaxonis,
            "W" => Source.PersonalGuess,
            "Y" => Source.Temporary,
            "Z" => Source.SentByUser,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known Latin word source.")
        };
    }
    private static Number ReadNumber(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => Number.Unknown,
            "S" => Number.Singular,
            "P" => Number.Plural,

            _ => throw new MalformedDictionaryEntryException(
                $"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known number (singular or plural).")
        };
    }
    private static Tense ReadTense(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => Tense.Unknown,
            "PRES" => Tense.Present,
            "IMPF" => Tense.Imperfect,
            "FUT" => Tense.Future,
            "PERF" => Tense.Perfect,
            "PLUP" => Tense.Pluperfect,
            "FUTP" => Tense.FuturePerfect,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known tense.")
        };
    }
    private static Mood ReadMood(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => Mood.Unknown,
            "IND" => Mood.Indicative,
            "SUB" => Mood.Subjunctive,
            "IMP" => Mood.Imperative,
            "INF" => Mood.Infinitive,
            "PPL" => Mood.Participle,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known mood.")
        };
    }
    private static Voice ReadVoice(StreamReader file)
    {
        var chunk = file.ReadString().ToUpper();

        return chunk switch
        {
            "X" => Voice.Unknown,
            "ACTIVE" => Voice.Active,
            "PASSIVE" => Voice.Passive,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known voice.")
        };
    }
    private static Person ReadPerson(StreamReader file)
    {
        var chunk = file.ReadString();

        return chunk switch
        {
            "0" => Person.Unknown,
            "1" => Person.First,
            "2" => Person.Second,
            "3" => Person.Third,
            
            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known person (1st, 2nd, or 3rd).")
        };
    }
    private static AddonKind AddonKindFrom(string chunk)
    {
        return chunk.ToUpper() switch
        {
            "PREFIX" => AddonKind.Prefix,
            "SUFFIX" => AddonKind.Suffix,
            "TACKON" => AddonKind.Tackon,

            _ => throw new MalformedDictionaryEntryException($"The token \"{Utilities.EscapeQuotes(chunk)}\" is not recognized as representing a known addon kind.")
        };
    }

    private static Noun ReadNoun(StreamReader file)
    {
        var word = new Noun
        {
            Declension = file.ReadInteger(),
            DeclensionVariant = file.ReadInteger(),
            Gender = ReadGender(file),
            Kind = ReadNounKind(file)
        };

        return word;
    }
    private static Pronoun ReadPronoun(StreamReader file)
    {
        var word = new Pronoun
        {
            Declension = file.ReadInteger(),
            DeclensionVariant = file.ReadInteger(),
            
            Kind = ReadPronounKind(file)
        };

        return word;
    }
    private static Packon ReadPackon(StreamReader file)
    {
        var word = new Packon()
        {
            Declension = file.ReadInteger(),
            DeclensionVariant = file.ReadInteger(),
            
            Kind = ReadPronounKind(file)
        };

        return word;
    }
    private static Adjective ReadAdjective(StreamReader file)
    {
        var word = new Adjective
        {
            Declension = file.ReadInteger(),
            DeclensionVariant = file.ReadInteger(),
            
            Comparison = ReadComparison(file)
        };

        return word;
    }
    private static Adverb ReadAdverb(StreamReader file)
    {
        var word = new Adverb
        {
            Comparison = ReadComparison(file)
        };

        return word;
    }
    private static Verb ReadVerb(StreamReader file)
    {
        var word = new Verb
        {
            Conjugation = file.ReadInteger(),
            ConjugationVariant = file.ReadInteger(),
            VerbKind = ReadVerbKind(file)
        };

        return word;
    }
    private static Numeral ReadNumeral(StreamReader file)
    {
        var word = new Numeral
        {
            Declension = file.ReadInteger(),
            DeclensionVariant = file.ReadInteger(),
            
            Sorting = ReadNumeralSorting(file),
            Value = file.ReadInteger()
        };

        return word;
    }
    private static Preposition ReadPreposition(StreamReader file)
    {
        var word = new Preposition
        {
            Case = ReadPrepositionCase(file)
        };

        return word;
    }
    private static Conjunction ReadConjunction(StreamReader _) => new();
    private static Interjection ReadInterjection(StreamReader _) => new();

    public void CleanUp()
    {
    }
    
    private static ((string meaning, InflectedForm form)[] EnglishIrregularLookup, InflectedForm[] IrregularWords) LoadUniques(ConcurrentDictionary<string, List<(InflectedForm, Word?)>> lookupList)
    {
        using var file = new StreamReader("./Files/UNIQUES.LAT");

        var irregularWords = new List<InflectedForm>(100);
        var english = new List<(string, InflectedForm)>(100);
        
        while (!file.EndOfStream)
        {
            var unique = ReadInflectedForm(file);
            
            lookupList.GetOrAdd(unique.Form, static (_, _) => [], 0).Add((unique, null));
            irregularWords.Add(unique);
            
            if (unique is InflectedVerb verb)
            {
                foreach (var syncope in TrickTables.Syncopes)
                {
                    var composed = unique.Form;
                    var index = composed.LastIndexOf(syncope.Before, StringComparison.Ordinal);
                    if (index == -1) continue;

                    var before = composed[..index];
                    var after = composed[(index + syncope.Before.Length)..];
                    
                    Add(before + syncope.After + after, verb, (verb, syncope));
                }
            }

            english.AddRange(unique.Meaning.Split(LatinDictionary.WordSeparators, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(part => (part, unique)));
        }

        return (english.ToArray(), irregularWords.ToArray());
        
        void Add(string form, InflectedVerb verb, (InflectedVerb priorForm, Syncope syncope)? syncope)
        {
            var unique = new InflectedVerb()
            {
                Form = form,
                Meaning = verb.Meaning,
                PartOfSpeech = verb.PartOfSpeech,
                Age = verb.Age,
                Subject = verb.Subject,
                GeographicalSource = verb.GeographicalSource,
                Frequency = verb.Frequency,
                Source = verb.Source,

                Conjugation = verb.Conjugation,
                ConjugationVariant = verb.ConjugationVariant,

                Tense = verb.Tense,
                Voice = verb.Voice,
                Mood = verb.Mood,

                Person = verb.Person,
                Number = verb.Number,

                Kind = verb.Kind,
                Syncope = syncope
            };
            lookupList.GetOrAdd(form, static _ => []).Add((unique, null));
        }
        
        static InflectedForm ReadInflectedForm(StreamReader file)
        {
            var form = file.ReadLine()?.Trim() ?? "";
            var part = ReadPartOfSpeech(file);

            InflectedForm entry = part switch
            {
                PartOfSpeech.Noun => ReadInflectedNoun(file),
                PartOfSpeech.Pronoun => ReadInflectedPronoun(file),
                PartOfSpeech.Verb => ReadInflectedVerb(file),
                PartOfSpeech.Adjective => ReadInflectedAdjective(file),
            
                _ => throw new MalformedDictionaryEntryException($"No handler for {part.ToString()} words as uniques!")
            };

            entry.PartOfSpeech = part;
            entry.Form = form;
        
            entry.Age = ReadAge(file);
            entry.Subject = ReadSubject(file);
            entry.GeographicalSource = ReadGeographicalSource(file);
            entry.Frequency = ReadFrequency(file);
            entry.Source = ReadSource(file);
        
            // Windows style line endings mean we may need to consume additional whitespace characters (\r)
            while (file.Peek() != -1 && char.IsWhiteSpace((char)file.Peek()))
            {
                file.Read();
            }
        
            entry.Meaning = file.ReadLine()?.Trim() ?? "";
        
            return entry;
        
            static InflectedAdjective ReadInflectedAdjective(StreamReader file)
            {
                return new InflectedAdjective
                {
                    Declension = file.ReadInteger(),
                    DeclensionVariant = file.ReadInteger(),
            
                    Case = ReadCase(file),
                    Number = ReadNumber(file),
                    Gender = ReadGender(file),
            
                    Comparison = ReadComparison(file)
                };
            }
            static InflectedNoun ReadInflectedNoun(StreamReader file)
            {
                var result = new InflectedNoun
                {
                    Declension = file.ReadInteger(),
                    DeclensionVariant = file.ReadInteger(),
            
                    Case = ReadCase(file),
                    Number = ReadNumber(file),
                    Gender = ReadGender(file),
            
                    Kind = ReadNounKind(file)
                };

                return result;
            }
            static InflectedPronoun ReadInflectedPronoun(StreamReader file)
            {
                return new InflectedPronoun
                {
                    Declension = file.ReadInteger(),
                    DeclensionVariant = file.ReadInteger(),
            
                    Case = ReadCase(file),
                    Number = ReadNumber(file),
                    Gender = ReadGender(file),
            
                    PronounKind = ReadPronounKind(file)
                };
            }
            static InflectedVerb ReadInflectedVerb(StreamReader file)
            {
                return new InflectedVerb
                {
                    Conjugation = file.ReadInteger(),
                    ConjugationVariant = file.ReadInteger(),
            
                    Tense = ReadTense(file),
                    Voice = ReadVoice(file),
                    Mood = ReadMood(file),
            
                    Person = ReadPerson(file),
                    Number = ReadNumber(file),
            
                    Kind = ReadVerbKind(file)
                };
            }
        }
    }
    public WordTables LoadWords(LatinDictionarySettings settings, LatinDictionary dictionary)
    {
        using var file = new StreamReader("./Files/DICTLINE.GEN");

        var tables = new WordTables();

        var latinTable = tables.LookupTable;
        var extendedLookup = tables.ExtendedLookupTable;
        var wordList = new List<Word>(40_000);
        
        var pronouns = new ConcurrentDictionary<(string meaning, PronounKind kind), List<Word>>();

        Word? baseWord = null;
        
        while (!file.EndOfStream)
        {
            var word = ReadWord(file);
            HandleWord(word, baseWord);

            if (!word.Meaning.StartsWith('|'))
            {
                baseWord = word;
            }
        }

        // A lovely pile of "fixes" for irregular words that nevertheless can not be simply put into the uniques table as they need a proper dictionary entry
        var specialCases = new Word[]
        {
            new()
            {
                StemA = "s",
                StemB = "",
                StemC = "fu",
                StemD = "fut",
                
                PartOfSpeech = PartOfSpeech.Verb,
                Meaning = "be; exist; (also used to form verb perfect passive tenses) with NOM PERF PPL",
                
                GeographicalSource = GeographicalSource.Italy,
                Frequency = Frequency.VeryFrequent,
                Age = Age.Unknown,
                Source = Source.Unknown,
                Subject = Subject.None,
                
                Info = new Verb
                {
                    Conjugation = 5,
                    ConjugationVariant = 1,
                    VerbKind = VerbKind.ToBe
                }
            }
        };

        foreach (var word in specialCases)
        {
            HandleWord(word, null);
        }
        
        var quCuPronouns =
            pronouns.Values
                .Where(word =>
                    word[0].PartOfSpeech != PartOfSpeech.Packon && word[0].Info is Pronoun { Declension: 1 } &&
                    word[0].StemA == "qu"
                )
                .Select(list =>
                    (
                        ((Pronoun)list[0].Info).Kind,
                        list.Select(word =>
                                word.Info is Pronoun pronoun ? (pronoun.Declension, pronoun.DeclensionVariant) : (0, 0))
                            .ToArray()
                    )
                )
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
                    Underlying = group.ToArray(),
                
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

        void HandleWord(Word word, Word? previousWord)
        {
            if (previousWord is not null && word.Meaning.StartsWith('|'))
            {
                previousWord.Meaning = previousWord.Meaning + " " + word.Meaning.TrimStart('|');
                return;
            }

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
        static Word ReadWord(StreamReader file)
        {
            var word = new Word
            {
                StemA = EmptyIfZzz(file.ReadString(19)),
                StemB = EmptyIfZzz(file.ReadString(19)),
                StemC = EmptyIfZzz(file.ReadString(19)),
                StemD = EmptyIfZzz(file.ReadString(19)),

                PartOfSpeech = ReadPartOfSpeech(file)
            };
            
            word.Info = word.PartOfSpeech switch
            {
                PartOfSpeech.Noun => ReadNoun(file),
                PartOfSpeech.Pronoun => ReadPronoun(file),
                PartOfSpeech.Packon => ReadPackon(file),
                
                PartOfSpeech.Adjective => ReadAdjective(file),
                PartOfSpeech.Adverb => ReadAdverb(file),
                
                PartOfSpeech.Verb => ReadVerb(file),
                
                PartOfSpeech.Numeral => ReadNumeral(file),
                PartOfSpeech.Preposition => ReadPreposition(file),
                
                // These methods do nothing, but are included to align with the ones above.
                PartOfSpeech.Conjunction => ReadConjunction(file),
                PartOfSpeech.Interjection => ReadInterjection(file),

                _ => throw new MalformedDictionaryEntryException($"Failed to understand {word.PartOfSpeech.ToString()} as a valid word info kind.")
            };
            
            if (word is { PartOfSpeech: PartOfSpeech.Pronoun or PartOfSpeech.Packon, Info: Pronoun { Declension: 1 }, StemA: "qu", StemB: null })
            {
                word.StemB = "cu";
            }
            
            word.Age = ReadAge(file);
            word.Subject = ReadSubject(file);
            word.GeographicalSource = ReadGeographicalSource(file);
            word.Frequency = ReadFrequency(file);
            word.Source = ReadSource(file);

            word.Meaning = file.ReadLine()?.Trim() ?? "";
            
            // (w/-dem ONLY,
            if (word is { PartOfSpeech: PartOfSpeech.Pronoun, StemA: "i", StemB: "e", Info: Pronoun pronoun } && word.Meaning.Contains("w/") && word.Meaning.Contains("ONLY"))
            {
                var forcedTackon = word.Meaning.Substring(4).Split(' ')[0];
                pronoun.MandatoryTackon = forcedTackon;
            }

            if (word is not { PartOfSpeech: PartOfSpeech.Packon, Info: Packon packon }) return word;
            
            packon.Tackon = word.Meaning.Split(' ')[0][4..].TrimEnd(')');
            word.Meaning = word.Meaning[(word.Meaning.IndexOf(' ') + 1)..];

            return word;

            static string? EmptyIfZzz(string value) => string.IsNullOrWhiteSpace(value) || value is "zzz" or "ZZZ" ? null : value.Trim().ToLowerInvariant();
        }
    }
    
    private static readonly object InflectionsLock = new();

    private static void ProcessInflectionsFile(bool skipUnlikelyInflections, StreamReader inFile, TextWriter outFile)
    {
        lock (InflectionsLock)
        {
            while (!inFile.EndOfStream)
            {
                var rawLine = inFile.ReadLine() ?? "";
                var chunks = rawLine.Split(["--"], StringSplitOptions.TrimEntries);

                var line = chunks.Length == 0 ? "" : chunks[0];
            
                if (string.IsNullOrWhiteSpace(line) || skipUnlikelyInflections && rawLine.Contains("G&L")) continue;
            
                outFile.WriteLine(line);
            }
        
            inFile.Close();
            outFile.Close();
        }
    }
    public (InflectionMaps mapping, Inflection.Inflection[] inflections) LoadInflections(LatinDictionarySettings settings)
    {
        ProcessInflectionsFile(
            settings.SkipUnlikelyInflections,
            new StreamReader("./Files/INFLECTS.LAT"), 
            new StreamWriter("./Files/INFLECTS.CMP")
        );

        using var file = new StreamReader("./Files/INFLECTS.CMP");

        var map = new InflectionMaps();
        
        var nounInflectionMap = map.NounInflections;
        var verbInflectionMap = map.VerbInflections;
        var adjectiveInflectionMap = map.AdjectiveInflections;
        var numeralInflectionMap = map.NumeralInflections;
        var pronounInflectionMap = map.PronounInflections;
        var supineInflectionMap = map.SupineInflections;
        var verbParticipleInflectionMap = map.VerbParticipleInflections;

        var inflectionList = new List<Inflection.Inflection>();

        while (!file.EndOfStream)
        {
            var inflection = ReadInflection(file);

            inflectionList.Add(inflection);
            
            switch (inflection)
            {
                case NounInflection noun:
                    AddInflection(nounInflectionMap, noun.Declension, noun.DeclensionVariant, noun);
                    break;
                case SupineInflection supine:
                    AddInflection(supineInflectionMap, supine.Conjugation, supine.ConjugationVariant, supine);
                    break;
                case VerbalNounInflection participle:
                    AddInflection(verbParticipleInflectionMap, participle.Conjugation, participle.ConjugationVariant, participle);
                    break;
                case VerbInflection verb:
                    AddInflection(verbInflectionMap, verb.Conjugation, verb.ConjugationVariant, verb);
                    break;
                case AdjectiveInflection adjective:
                    AddInflection(adjectiveInflectionMap, adjective.Declension, adjective.DeclensionVariant, adjective);
                    break;
                case NumeralInflection numeral:
                    AddInflection(numeralInflectionMap, numeral.Declension, numeral.DeclensionVariant, numeral);
                    break;
                case PronounInflection pronoun:
                    AddInflection(pronounInflectionMap, pronoun.Declension, pronoun.DeclensionVariant, pronoun);
                    break;
            }
        }

        FinalizeGroups(nounInflectionMap);
        FinalizeGroups(verbInflectionMap);
        FinalizeGroups(adjectiveInflectionMap);
        FinalizeGroups(numeralInflectionMap);
        FinalizeGroups(pronounInflectionMap);
        FinalizeGroups(supineInflectionMap);
        FinalizeGroups(verbParticipleInflectionMap);
        
        return (map, inflectionList.ToArray());

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
        static void AddInflection<T>(ConcurrentDictionary<int, ConcurrentDictionary<int, List<T>>> table, int group, int groupVariant, T value)
        {
            table.GetOrAdd(group, _ => new()).GetOrAdd(groupVariant, _ => []).Add(value);
        }
        static Inflection.Inflection ReadInflection(StreamReader file)
        {
            var partOfSpeech = ReadPartOfSpeech(file);

            Inflection.Inflection result = partOfSpeech switch
            {
                PartOfSpeech.Noun => ReadNounInflection(file),
                PartOfSpeech.Pronoun => ReadPronounInflection(file),
                
                PartOfSpeech.Adjective => ReadAdjectiveInflection(file),
                PartOfSpeech.Adverb => ReadAdverbInflection(file),
                PartOfSpeech.Preposition => ReadPrepositionInflection(file),
                
                // These two do nothing but are included in for parity.
                PartOfSpeech.Conjunction => new ConjunctionInflection(),
                PartOfSpeech.Interjection => new InterjectionInflection(),
                
                PartOfSpeech.Verb => ReadVerbInflection(file),
                PartOfSpeech.VerbParticiple => ReadParticipleInflection(file),
                PartOfSpeech.Supine => ReadSupineInflection(file),
                
                PartOfSpeech.Numeral => ReadNumeralInflection(file),

                _ => throw new MalformedDictionaryEntryException($"{partOfSpeech.ToString()} is not understood as having inflections.")
            };

            result.PartOfSpeech = partOfSpeech;
            result.StemType = file.ReadInteger();
            
            var endingLength = file.ReadInteger();
            result.Ending = endingLength == 0 ? "" : file.ReadString();

            result.Age = ReadAge(file);
            result.Frequency = ReadFrequency(file);

            while (char.IsWhiteSpace((char)file.Peek()))
            {
                file.Read();
            }

            return result;
            
            static NounInflection ReadNounInflection(StreamReader file)
            {
                var result = new NounInflection
                {
                    Declension = file.ReadInteger(),
                    DeclensionVariant = file.ReadInteger(),
                
                    Case = ReadCase(file),
                    Number = ReadNumber(file),
                    Gender = ReadGender(file)
                };

                return result;
            }
            static PronounInflection ReadPronounInflection(StreamReader file)
            {
                return new PronounInflection
                {
                    Declension = file.ReadInteger(),
                    DeclensionVariant = file.ReadInteger(),
                
                    Case = ReadCase(file),
                    Number = ReadNumber(file),
                    Gender = ReadGender(file)
                };
            }
            static AdjectiveInflection ReadAdjectiveInflection(StreamReader file)
            {
                return new AdjectiveInflection
                {
                    Declension = file.ReadInteger(),
                    DeclensionVariant = file.ReadInteger(),
                
                    Case = ReadCase(file),
                    Number = ReadNumber(file),
                    Gender = ReadGender(file),
                
                    Comparison = ReadComparison(file)
                };
            }
            static AdverbInflection ReadAdverbInflection(StreamReader file)
            {
                return new AdverbInflection
                {
                    Comparison = ReadComparison(file)
                };
            }
            static PrepositionInflection ReadPrepositionInflection(StreamReader file)
            {
                return new PrepositionInflection
                {
                    Case = ReadPrepositionCase(file)
                };
            }
            static VerbInflection ReadVerbInflection(StreamReader file)
            {
                return new VerbInflection
                {
                    Conjugation = file.ReadInteger(),
                    ConjugationVariant = file.ReadInteger(),
                
                    Tense = ReadTense(file),
                    Voice = ReadVoice(file),
                    Mood = ReadMood(file),
                
                    Person = ReadPerson(file),
                    Number = ReadNumber(file),
                };
            }
            static VerbalNounInflection ReadParticipleInflection(StreamReader file)
            {
                return new VerbalNounInflection
                {
                    Conjugation = file.ReadInteger(),
                    ConjugationVariant = file.ReadInteger(),
                
                    Case = ReadCase(file),
                    Number = ReadNumber(file),
                    Gender = ReadGender(file),
                
                    Tense = ReadTense(file),
                    Voice = ReadVoice(file),
                    Mood = ReadMood(file)
                };
            }
            static SupineInflection ReadSupineInflection(StreamReader file)
            {
                return new SupineInflection
                {
                    Conjugation = file.ReadInteger(),
                    ConjugationVariant = file.ReadInteger(),
                
                    Case = ReadCase(file),
                    Number = ReadNumber(file),
                    Gender = ReadGender(file)
                };
            }
            static NumeralInflection ReadNumeralInflection(StreamReader file)
            {
                return new NumeralInflection
                {
                    Declension = file.ReadInteger(),
                    DeclensionVariant = file.ReadInteger(),
                
                    Case = ReadCase(file),
                    Number = ReadNumber(file),
                    Gender = ReadGender(file),
                
                    Sort = ReadNumeralSorting(file)
                };
            }
        }
    }

    public (Prefix[] prefixes, Suffix[] suffixes, Tackon[] tackons, Tackon[] packons) LoadAddons(LatinDictionarySettings settings)
    {
        using var file = new StreamReader("./Files/ADDONS.LAT");

        var prefixes = new List<Prefix>();
        var suffixes = new List<Suffix>();
        var tackons = new List<Tackon>();
        var packons = new List<Tackon>();

        while (!file.EndOfStream)
        {
            var addon = ReadAddon(file);

            switch (addon)
            {
                case Prefix prefix:
                    prefixes.Add(prefix);
                    break;
                case Suffix suffix:
                    suffixes.Add(suffix);
                    break;
                case Tackon { IsPackon: true } tackon:
                    packons.Add(tackon);
                    break;
                case Tackon tackon:
                    tackons.Add(tackon);
                    break;
            }
        }

        return (prefixes.ToArray(), suffixes.ToArray(), tackons.ToArray(), packons.ToArray());
        
        static Addon ReadAddon(StreamReader file)
        {
            var line = file.ReadLine()?.Trim() ?? "";

            while (line.StartsWith("--"))
            {
                line = file.ReadLine()?.Trim() ?? "";
            }

            var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var kind = AddonKindFrom(parts[0]);
        
            var word = parts[1];
            char? connectingCharacter = parts.Length == 3 ? parts[2][0] : null;
        
            Addon addon = kind switch
            {
                AddonKind.Prefix => ReadPrefix(file),
                AddonKind.Suffix => ReadSuffix(file),
                AddonKind.Tackon => ReadTackon(file),
            
                _ => throw new MalformedDictionaryEntryException($"{kind.ToString()} is not an understood addon kind.")
            };
        
            var meaning = file.ReadLine()?.Trim() ?? "";

            addon.Kind = kind;
            addon.Word = word;
            addon.ConnectingCharacter = connectingCharacter;
            addon.Meaning = meaning;

            if (addon is not Tackon tackon) return addon;
            var isPackon = tackon.From == PartOfSpeech.Packon;

            tackon.IsPackon = isPackon;
            
            if (!isPackon && meaning.StartsWith("TACKON"))
            {
                addon.Meaning = addon.Meaning[7..];
            }

            return addon;
            
            static Prefix ReadPrefix(TextReader file)
            {
                var chunks = (file.ReadLine()?.Trim() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

                return new Prefix()
                {
                    From = PartOfSpeechFrom(chunks[0]),
                    To = PartOfSpeechFrom(chunks[1])
                };
            }
            static Suffix ReadSuffix(StreamReader file)
            {
                var addon = new Suffix
                {
                    From = ReadPartOfSpeech(file),
                    Unknown1 = file.ReadInteger(),
                    To = ReadPartOfSpeech(file)
                };

                addon.Result = addon.To switch
                {
                    PartOfSpeech.Noun => ReadNoun(file),
                    PartOfSpeech.Adjective => ReadAdjective(file),
                    PartOfSpeech.Adverb => ReadAdverb(file),
                    PartOfSpeech.Verb => ReadVerb(file),
                    PartOfSpeech.Numeral => ReadNumeral(file),
                    PartOfSpeech.Pronoun => ReadPronoun(file),

                    _ => throw new MalformedDictionaryEntryException($"Invalid suffix result type: {addon.To.ToString()}")
                };

                addon.Unknown2 = int.Parse(file.ReadLine()?.Trim() ?? "0");
        
                return addon;
            }
            static Tackon ReadTackon(StreamReader file)
            {
                var addon = new Tackon();
                var part = ReadPartOfSpeech(file);

                addon.From = part;
                addon.To = part;
        
                addon.TargetInfo = part switch
                {
                    PartOfSpeech.Unknown => WordInfo.Null,
                    PartOfSpeech.Noun => ReadNoun(file),
                    PartOfSpeech.Adjective => ReadAdjective(file),
                    PartOfSpeech.Adverb => ReadAdverb(file),
                    PartOfSpeech.Verb => ReadVerb(file),
                    PartOfSpeech.Numeral => ReadNumeral(file),
                    PartOfSpeech.Pronoun => ReadPronoun(file),
                    PartOfSpeech.Packon => ReadPronoun(file),

                    _ => throw new MalformedDictionaryEntryException($"Invalid tackon target type: {part.ToString()}")
                };

                file.SkipWhitespace();

                return addon;
            }
        }
    }
}