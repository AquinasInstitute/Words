using System.Diagnostics;
using System.Net;
using System.Text;
using Words.Addons;
using Words.Flags;
using Words.Inflected;
using Words.Words;

namespace Words;

public static class WhitakersCompatability
{
    private static string DisplayNumber(int number)
    {
        return number switch
        {
            1 => "1st",
            2 => "2nd",
            3 => "3rd",
            _ => $"{number}th"
        };
    }

    private static readonly ArrayStructuralEquality<Addon> AddonComparer = new();

    private static void PresentWord(StringBuilder buffer, LatinDictionary latin, string latinWord, (Word? word, (InflectedForm form, Addon[] addons)[] forms) match, bool forHtml = false)
    {
        var word = match.word;
        var forms = match.forms;
        
        // The most shared set of addons.
        // This is used to clean up the addon display when there are many forms, but they all have the same addon.
        var commonAddons =
            forms
                .Select(pair => pair.addons)
                .GroupBy(v => v, AddonComparer)
                .Select(group => (Addons: group.Key, Count: group.Count()))
                .OrderByDescending(pair => pair.Count)
                .FirstOrDefault()
                .Addons
            ?? Array.Empty<Addon>();
        
        PresentAddons(commonAddons, false);
        
        foreach (var (form, addons) in forms)
        {
            var presentedForm = form.Stem is not null && form.Ending is not null
                ? $"{form.Stem}.{form.Ending}"
                : form.Form;
            var partOfSpeech = PresentPartOfSpeech(form.PartOfSpeech);
                
            buffer.Append($"{presentedForm.PadRight(21)} {partOfSpeech} ");

            switch (form)
            {
                // Nouns, pronouns, adjectives, participles.
                case InflectedDeclineable declForm:
                {
                    var @case = PresentCase(declForm.Case);
                    var number = PresentNumber(declForm.Number);
                    var gender = PresentGender(declForm.Gender);
                    
                    buffer.Append($"{declForm.Declension} {declForm.DeclensionVariant} {@case} {number} {gender}");

                    if (declForm is InflectedAdjective adjForm)
                    {
                        var comparison = PresentComparison(adjForm.Comparison);

                        buffer.Append(' ');
                        buffer.Append(comparison);

                        if (adjForm is InflectedParticiple partForm)
                        {
                            var tense = PresentTense(partForm.Tense);
                            var voice = PresentVoice(partForm.Voice);
                            var mood = PresentMood(partForm.Mood);

                            buffer.Append($" {tense} {voice} {mood}");
                        }
                    }
                    
                    buffer.AppendLine();
                    
                    break;
                }
                case InflectedVerb verbForm:
                {
                    var tense = PresentTense(verbForm.Tense);
                    var voice = PresentVoice(verbForm.Voice);
                    var mood = PresentMood(verbForm.Mood);
                    var person = PresentPerson(verbForm.Person);
                    var number = PresentNumber(verbForm.Number);

                    var conjugation = verbForm.Conjugation;
                    var variant = verbForm.ConjugationVariant;

                    // Whitaker stores 4th as a variant of third, so we have to put it back when displaying to the user.
                    if (conjugation == 3 && variant == 4)
                    {
                        conjugation = 4;
                        variant = 0;
                    }
                    
                    buffer.AppendLine($"{conjugation} {variant} {tense} {voice} {mood} {person} {number}");
                    break;
                }
                case InflectedAdverb adverbForm:
                {
                    buffer.AppendLine(PresentComparison(adverbForm.Comparison));
                    break;
                }
                case InflectedPreposition prepForm:
                {
                    buffer.AppendLine(PresentPrepositionCase(prepForm.Case));
                    break;
                }
                default:
                    buffer.AppendLine();
                    break;
            }

            if (!AddonComparer.Equals(commonAddons, addons))
            {
                PresentAddons(addons, true);
            }
        }
        
        if (word is not null)
        {
            var formsForPresentation = latin.Present(word);
            var presentedForms =
                string.Join(
                    " ",
                    formsForPresentation
                        .Select((form, index) =>
                        {
                            var presented = form?.Stem is not null && form.Ending is not null
                                ? $"{form.Stem}.{form.Ending}"
                                : form?.Form ?? "-";

                            return index == 0 && forHtml
                                ? $"<a href=\"https://alatius.com/ls/index.php?ord={formsForPresentation[0]?.Form ?? latinWord}\" target=\"_blank\">{presented}</a>"
                                : presented;
                        })
                );

            buffer.Append(presentedForms);

            buffer.Append(' ');
            buffer.Append(PresentPartOfSpeech(word.PartOfSpeech));
            buffer.Append(' ');

            switch (word.Info)
            {
                // Exclude adjectives from the next case.
                case Adjective: break;
                // Nouns and pronouns.
                case Declineable declWord:
                    buffer.Append('(');
                    buffer.Append(DisplayNumber(declWord.Declension));
                    buffer.Append(") ");
                    break;
                case Verb conjWord:
                    buffer.Append('(');
                    // Whitaker stores 4th as a variant of third, so we have to put it back when displaying to the user.
                    buffer.Append(DisplayNumber(conjWord is { Conjugation: 3, ConjugationVariant: 4} ? 4 : conjWord.Conjugation));
                    buffer.Append(") ");
                    break;
            }

            if (word.Info is Noun nounWord)
            {
                buffer.Append(PresentGender(nounWord.Gender));
            }

            buffer.Append(" [");
            buffer.Append(PresentAge(word.Age));
            buffer.Append(PresentSubject(word.Subject));
            buffer.Append(PresentGeographicalSource(word.GeographicalSource));
            buffer.Append(PresentFrequency(word.Frequency));
            buffer.Append(PresentSource(word.Source));
            buffer.AppendLine("]");
            
            buffer.AppendLine(forHtml ? WebUtility.HtmlEncode(word.Meaning) : word.Meaning);
        }
        // There shouldn't ever be a case in which there is both no word and no matched forms, but it doesn't hurt to be careful.
        else if (forms.Length > 0)
        {
            buffer.AppendLine(forHtml ? WebUtility.HtmlEncode(forms[0].form.Meaning) : forms[0].form.Meaning);
        }

        return;
        
        void PresentAddons(Addon[] addons, bool asPartOfForm)
        {
            const string indent = "    ";

            foreach (var addon in addons)
            {
                if (asPartOfForm) buffer.Append(indent);
                buffer.AppendLine($"{addon.Word.PadRight(21)} {PresentAddonKind(addon.Kind)}");
            
                if (asPartOfForm) buffer.Append(indent);
                buffer.AppendLine(addon.Meaning);
            }
        }
        
        static string PresentPartOfSpeech(PartOfSpeech partOfSpeech)
        {
            return partOfSpeech switch
            {
                PartOfSpeech.Unknown =>        "X     ",
                PartOfSpeech.Noun =>           "N     ",
                PartOfSpeech.Pronoun =>        "PRON  ",
                PartOfSpeech.Packon =>         "PACK  ",
                PartOfSpeech.Adjective =>      "ADJ   ",
                PartOfSpeech.Numeral =>        "NUM   ",
                PartOfSpeech.Adverb =>         "ADV   ",
                PartOfSpeech.Verb =>           "V     ",
                PartOfSpeech.VerbParticiple => "VPAR  ",
                PartOfSpeech.Supine =>         "SUPINE",
                PartOfSpeech.Preposition =>    "PREP  ",
                PartOfSpeech.Conjunction =>    "CONJ  ",
                PartOfSpeech.Interjection =>   "INTERJ",
            
                _ => throw new ArgumentOutOfRangeException(nameof(partOfSpeech), partOfSpeech, "Invalid part of speech!")
            };
        }
        static string PresentGender(Gender gender)
        {
            return gender switch
            {
                Gender.Unknown => "X",
                Gender.Masculine => "M",
                Gender.Feminine => "F",
                Gender.Neuter => "N",
                Gender.Common => "C",
            
                _ => throw new ArgumentOutOfRangeException(nameof(gender), gender, "Invalid gender!")
            };
        }
        static string PresentComparison(Comparison comparison)
        {
            return comparison switch
            {
                Comparison.Unknown => "X    ",
                Comparison.Positive => "POS  ",
                Comparison.Comparative => "COMP ",
                Comparison.Superlative => "SUPER",

                _ => throw new ArgumentOutOfRangeException(nameof(comparison), comparison, "Invalid comparision kind!")
            };
        }
        static string PresentPrepositionCase(PrepositionCase @case)
        {
            return @case switch
            {
                PrepositionCase.Unknown =>    "X  ",
                PrepositionCase.Nominative => "NOM",
                PrepositionCase.Vocative =>   "VOC",
                PrepositionCase.Genitive =>   "GEN",
                PrepositionCase.Locative =>   "LOC",
                PrepositionCase.Dative =>     "DAT",
                PrepositionCase.Ablative =>   "ABL",
                PrepositionCase.Accusative => "ACC",
            
                _ => throw new ArgumentOutOfRangeException(nameof(@case), @case, "Invalid preposition case!")
            };
        }
        static string PresentCase(Case @case)
        {
            return @case switch
            {
                Case.Unknown => "X  ",
                Case.Nominative => "NOM",
                Case.Vocative => "VOC",
                Case.Genitive => "GEN",
                Case.Locative => "LOC",
                Case.Dative => "DAT",
                Case.Ablative => "ABL",
                Case.Accusative => "ACC",
            
                _ => throw new ArgumentOutOfRangeException(nameof(@case), @case, "Invalid noun case!")
            };
        }
        static string PresentAge(Age age)
        {
            return age switch
            {
                Age.Unknown => "X",
                Age.VeryEarly => "A",
                Age.Early => "B",
                Age.Classical => "C",
                Age.LateOrPostClassical => "D",
                Age.PostClassical => "E",
                Age.Medieval => "F",
                Age.Scientific => "G",
                Age.Modern => "H",

                _ => throw new ArgumentOutOfRangeException(nameof(age), age, "Invalid word age!")
            };
        }
        static string PresentSubject(Subject subject)
        {
            return subject switch
            {
                Subject.None => "X",
                Subject.Agriculture => "A",
                Subject.Biology => "B",
                Subject.Art => "D",
                Subject.Religion => "E",
                Subject.Literature => "G",
                Subject.Legal => "L",
                Subject.Poetic => "P",
                Subject.Science => "S",
                Subject.Technical => "T",
                Subject.War => "W",
                Subject.Mythology => "Y",
            
                _ => throw new ArgumentOutOfRangeException(nameof(subject), subject, "Invalid subject!")
            };
        }
        static string PresentGeographicalSource(GeographicalSource geographicalSource)
        {
            return geographicalSource switch
            {
                GeographicalSource.None => "X",
                GeographicalSource.Africa => "A",
                GeographicalSource.Britain => "B",
                GeographicalSource.China => "C",
                GeographicalSource.Scandinavia => "D",
                GeographicalSource.Egypt => "E",
                GeographicalSource.France => "F",
                GeographicalSource.Germany => "G",
                GeographicalSource.Greece => "H",
                GeographicalSource.Italy => "I",
                GeographicalSource.India => "J",
                GeographicalSource.Balkans => "K",
                GeographicalSource.Netherlands => "N",
                GeographicalSource.Persia => "P",
                GeographicalSource.NearEast => "Q",
                GeographicalSource.Russia => "R",
                GeographicalSource.Spain => "S",
                GeographicalSource.EasternEurope => "U",
            
                _ => throw new ArgumentOutOfRangeException(nameof(geographicalSource), geographicalSource, "Invalid geographical source for word!")
            };
        }
        static string PresentFrequency(Frequency frequency)
        {
            return frequency switch
            {
                Frequency.Unspecified => "X",
                Frequency.VeryFrequent => "A",
                Frequency.Frequent => "B",
                Frequency.Common => "C",
                Frequency.LessCommon => "D",
                Frequency.Uncommon => "E",
                Frequency.VeryRare => "F",
                Frequency.Inscription => "I",
                Frequency.Graffiti => "M",
                Frequency.Pliny => "N",

                _ => throw new ArgumentOutOfRangeException(nameof(frequency), frequency, "Invalid word frequency!")
            };
        }
        static string PresentSource(Source source)
        {
            return source switch
            {
                Source.Unknown => "X",
                Source.APrimerOfMedievalLatin => "B",
                Source.CassellsLatinDictionary => "C",
                Source.LatinSexualVocabulary => "D",
                Source.DictionaryOfEccles => "E",
                Source.DictionaryOfStThomasAquinas => "F",
                Source.LatinGrammar1895 => "G",
                Source.CollatinusDictionary => "H",
                Source.LexiconOfTheLatinLanguage => "I",
                Source.DeLegibusEtConsuetudinibusAngliae => "J",
                Source.CalephinusNovus => "K",
                Source.ElementaryLatuinDictionary => "L",
                Source.RevisedMedievalWordList => "M",
                Source.Wordlist => "N",
                Source.OxfordLatinDictionary => "O",
                Source.AGlossaryOfLaterLatinTo600AD => "P",
                Source.Unspecified => "Q",
                Source.AGrammarOfTheVulgate => "R",
                Source.ALatinDictionary1879 => "S",
                Source.FoundInTranslation => "T",
                Source.VademecumInOpusSaxonis => "V",
                Source.PersonalGuess => "W",
                Source.Temporary => "Y",
                Source.SentByUser => "Z",
            
                _ => throw new ArgumentOutOfRangeException(nameof(source), source, "Invalid source!")
            };
        }
        static string PresentNumber(Number number)
        {
            return number switch
            {
                Number.Unknown => "X",
                Number.Singular => "S",
                Number.Plural => "P",

                _ => throw new ArgumentOutOfRangeException(nameof(number), number, "Invalid person number!")
            };
        }
        static string PresentTense(Tense tense)
        {
            return tense switch
            {
                Tense.Unknown =>       "X   ",
                Tense.Present =>       "PRES",
                Tense.Imperfect =>     "IMPF",
                Tense.Future =>        "FUT ",
                Tense.Perfect =>       "PERF",
                Tense.Pluperfect =>    "PLUP",
                Tense.FuturePerfect => "FUTP",
                _ => throw new ArgumentOutOfRangeException(nameof(tense), tense, "Invalid tense!")
            };
        }
        static string PresentAddonKind(AddonKind addonKind)
        {
            return addonKind switch
            {
                AddonKind.Prefix => "PREFIX",
                AddonKind.Suffix => "SUFFIX",
                AddonKind.Tackon => "TACKON",

                _ => throw new ArgumentOutOfRangeException(nameof(addonKind), addonKind, "Invalid addon kind!")
            };
        }
        static string PresentMood(Mood mood)
        {
            return mood switch
            {
                Mood.Unknown => "X  ",
                Mood.Indicative => "IND",
                Mood.Subjunctive => "SUB",
                Mood.Imperative => "IMP",
                Mood.Infinitive => "INF",
                Mood.Participle => "PPL",

                _ => throw new ArgumentOutOfRangeException(nameof(mood), mood, "Invalid verb mood!")
            };
        }
        static string PresentVoice(Voice voice)
        {
            return voice switch
            {
                Voice.Unknown => "X      ",
                Voice.Active =>  "ACTIVE ",
                Voice.Passive => "PASSIVE",
                _ => throw new ArgumentOutOfRangeException(nameof(voice), voice, "Invalid voice value!")
            };
        }
        static string PresentPerson(Person person)
        {
            return person switch
            {
                Person.Unknown => "0",
                Person.First => "1",
                Person.Second => "2",
                Person.Third => "3",
            
                _ => throw new ArgumentOutOfRangeException(nameof(person), person, "Invalid person number!")
            };
        }
    }
    
    /// <summary>
    /// Looks up a word in the latin dictionary.
    /// </summary>
    /// <param name="latin">The dictionary to lookup within.</param>
    /// <param name="latinWord">The word to lookup.</param>
    /// <param name="forHtml">Whether to insert links to online sources and escape text for use in html</param>
    /// <param name="printTime">Add the lookup time as part of the output</param>
    /// <returns>The whitaker style display of matching words.</returns>
    public static string LookupLatin(LatinDictionary latin, string latinWord, bool forHtml = false, bool printTime = true)
    {
        var buffer = new StringBuilder();
        
        buffer.Clear();
        latinWord = latinWord.ToLower().Trim();
        
        var watch = new Stopwatch();
        watch.Start();
        
        var words = latin.LookupLatinForm(latinWord);
        
        watch.Stop();

        if (printTime)
        {
            buffer.AppendLine($"Time: {watch.ElapsedMilliseconds}");
        }
        
        foreach (var match in words)
        {
            PresentWord(buffer, latin, latinWord, match, forHtml);
            buffer.AppendLine();
        }

        return buffer.ToString().Trim();
    }

    public static string LookupEnglish(LatinDictionary latin, string englishWord, bool forHtml = false)
    {
        return string.Join(forHtml ? "<br />\r\n" : "\r\n",
            latin.LookupEnglishWord(englishWord)
                .Select(word =>
                {
                    var principleParts = string.Join(" ",
                        latin.Present(word).Select(form =>
                            form?.Stem is not null && form.Ending is not null
                                ? form.Stem + "." + form.Ending
                                : form?.Form ?? "-"));

                    return principleParts + " : " + word.Meaning;
                })
        );
    }
    
    private class ArrayStructuralEquality<T> : IEqualityComparer<T[]>
    {
        public bool Equals(T[]? x, T[]? y)
        {
            // Null or the same array passed twice.
            if (x == y) return true;

            if (x is null) return y is null;
            if (y is null) return false;

            if (x.Length != y.Length) return false;

            var comparer = EqualityComparer<T>.Default;
            
            // Can be converted to LINQ, but haven't bothered to test
            // Whether we meaningfully lose performance for that.
            for (var i = 0; i < x.Length; i++)
            {
                if (!comparer.Equals(x[i], y[i])) return false;
            }
            
            return true;
        }

        public int GetHashCode(T[] array)
        {
            if (array.Length == 0) return 0;

            var hash = new HashCode();

            foreach (var value in array)
            {
                hash.Add(value);
            }
            
            return hash.ToHashCode();
        }
    }
}