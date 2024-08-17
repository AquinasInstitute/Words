using System.Collections.Concurrent;
using Words.Extensions;
using Words.Flags;
using Words.Inflected;
using Words.Inflection;
using Words.Tricks;
using Words.Words;

namespace Words;

public partial class LatinDictionary
{
    private readonly ConcurrentDictionary<Word, InflectedForm[]> _inflectionTable = new();
    
    private InflectedForm[] DeclineNoun(Word word)
    {
        if (word.Info is not Noun noun) return Array.Empty<InflectedForm>();
        
        var table1 = InflectionMap.NounInflections[noun.Declension].GetOrEmpty(noun.DeclensionVariant);
        var table2 = noun.DeclensionVariant != 0 ? InflectionMap.NounInflections[noun.Declension].GetOrEmpty(0) : DictionaryExtensions.EmptyLists<NounInflection>.Value;
        
        var forms = new List<InflectedForm>(table1.Count + table2.Count);
        var completed = new HashSet<InflectedForm>();

        for (var i = 0; i < table1.Count; i++)
        {
            AddForm(table1[i]);
        }
        for (var i = 0; i < table2.Count; i++)
        {
            AddForm(table2[i]);
        }
        
        return forms.ToArray();

        void AddForm(NounInflection inflection)
        {
            var stem =
                string.IsNullOrWhiteSpace(word.StemB)
                || inflection is { Case: Case.Nominative or Case.Vocative, Number: Number.Singular }
                || noun is { Declension: 3, DeclensionVariant: 2 } && inflection is { Case: Case.Accusative, Number: Number.Singular }
                
                    ? word.StemA
                    : word.StemB;

            if (stem is null) return;
            
            var form = new InflectedNoun()
            {
                Form = stem + inflection.Ending,
                Stem = stem,
                Ending = inflection.Ending,
                
                Meaning = word.Meaning,
                PartOfSpeech = word.PartOfSpeech,
                Age = inflection.Age,
                Subject = word.Subject,
                GeographicalSource = word.GeographicalSource,
                Frequency = inflection.Frequency,
                Source = word.Source,
                
                Declension = noun.Declension,
                DeclensionVariant = noun.DeclensionVariant,
                
                Case = inflection.Case,
                Number = inflection.Number,
                Gender = inflection.Gender,
                
                Kind = noun.Kind
            };

            if (completed.Contains(form)) return;
            
            forms.Add(form);
            completed.Add(form);
        }
    }
    private InflectedForm[] DeclinePronoun(Word word)
    {
        if (word.Info is not Pronoun pronoun) return Array.Empty<InflectedForm>();
        
        var declensions =
            word.Info is CombinedPronoun combined
                ? combined.Declensions
                : new[] { (pronoun.Declension, pronoun.DeclensionVariant), (pronoun.Declension, 0) };
        
        var forms = new List<InflectedForm>(10);
        var completed = new HashSet<InflectedForm>();
        
        void AddForm(PronounInflection inflection, bool isAlternative = false)
        {
            var stem =
                pronoun is { Declension: 1 } ?
                    inflection is { Case: Case.Genitive or Case.Dative, Number: Number.Singular } ?
                        word.StemB : word.StemA :
                    
                pronoun is { Declension: 3, DeclensionVariant: 1 } ?
                    inflection is { Number: Number.Singular, Case: Case.Genitive or Case.Dative } ? word.StemB : word.StemA :
                    
                pronoun is { Declension: 4, DeclensionVariant: 1 } ?
                    isAlternative || inflection is { Number: Number.Singular, Case: Case.Nominative, Gender: Gender.Masculine or Gender.Neuter } ? word.StemA : word.StemB :
                    
                pronoun is { Declension: 4, DeclensionVariant: 2 } ?
                    isAlternative ? "" :
                    inflection
                        is { Number: Number.Singular, Case: Case.Nominative, Gender: Gender.Masculine }
                        or { Number: Number.Singular, Case: Case.Nominative or Case.Accusative, Gender: Gender.Neuter }
                        or { Number: Number.Plural, Case: Case.Nominative, Gender: Gender.Masculine }
                        ? word.StemA : word.StemB :
                    
                pronoun is { Declension: 5, DeclensionVariant: 3 } ?
                    inflection is { Number: Number.Plural, Case: Case.Genitive } ? word.StemB : word.StemA :
                    
                    inflection.Case is Case.Nominative ? word.StemA : word.StemB;
            
            if (stem is null) return;

            var ending = inflection.Ending;
            
            // SPECIAL CASE
            if (
                isAlternative
                && pronoun is { Declension: 1, DeclensionVariant: 0 }
                && inflection is
                    { Number: Number.Singular, Case: Case.Nominative or Case.Accusative, Gender: Gender.Neuter }
                && stem == "aliqu"
            )
            {
                ending = "od";
            }
            
            var composed = stem + ending;

            if (word.Info is Packon packon)
            {
                ending += packon.Tackon;
                composed += packon.Tackon;
            }

            if (pronoun.MandatoryTackon is not null)
            {
                ending += pronoun.MandatoryTackon;
                composed += pronoun.MandatoryTackon;
            }

            var form = new InflectedPronoun()
            {
                Form = composed,
                
                Stem = stem,
                
                Ending = ending,
                Meaning = word.Meaning,
                PartOfSpeech = word.PartOfSpeech,
                Age = inflection.Age,
                Subject = word.Subject,
                GeographicalSource = word.GeographicalSource,
                Frequency = inflection.Frequency,
                Source = word.Source,
                
                Declension = pronoun.Declension,
                DeclensionVariant = pronoun.DeclensionVariant,
                
                Case = inflection.Case,
                Number = inflection.Number,
                Gender = inflection.Gender,
                
                Kind = NounKind.Unknown,
                PronounKind = pronoun.Kind
            };

            if (completed.Contains(form)) return;
            
            completed.Add(form);
            forms.Add(form);

            if (isAlternative) return;
            
            if (pronoun is { Declension: 4, DeclensionVariant: 1 or 2 } && inflection is { Number: Number.Plural, Case: Case.Dative or Case.Ablative })
            {
                AddForm(inflection, true);
            }
                
            // FUTURE: Special casing this is kind of stupid, but I don't know a good alternative yet.
            if (
                pronoun is { Declension: 1, DeclensionVariant: 0 }
                && inflection is
                    { Number: Number.Singular, Case: Case.Nominative or Case.Accusative, Gender: Gender.Neuter }
                && stem == "aliqu"
            )
            {
                AddForm(inflection, true);
            }
        }

        foreach (var (declension, variant) in declensions)
        {
            var table = InflectionMap.PronounInflections[declension].GetOrEmpty(variant);

            for (var i = 0; i < table.Count; i++)
            {
                AddForm(table[i]);
            }
        }
        
        return forms.ToArray();
    }
    private InflectedForm[] DeclineNumeral(Word word)
    {
        if (word.Info is not Numeral numeral) return Array.Empty<InflectedForm>();

        var table1 = InflectionMap.NumeralInflections[numeral.Declension].GetOrEmpty(numeral.DeclensionVariant);
        var table2 = numeral.DeclensionVariant != 0 ? InflectionMap.NumeralInflections[numeral.Declension].GetOrEmpty(0) : DictionaryExtensions.EmptyLists<NumeralInflection>.Value;
        var table3 = InflectionMap.NumeralInflections[0][0];
        
        var forms = new List<InflectedForm>(table1.Count + table2.Count);

        for (var i = 0; i < table1.Count; i++)
        {
            AddForm(table1[i]);
        }
        for (var i = 0; i < table2.Count; i++)
        {
            AddForm(table2[i]);
        }
        for (var i = 0; i < table3.Count; i++)
        {
            AddForm(table3[i]);
        }
        
        return forms.ToArray();

        void AddForm(NumeralInflection inflection)
        {
            string? stem = null;
            
            if (numeral.Sorting is not NumeralSorting.Unknown || inflection.Sort is NumeralSorting.Cardinal)
            {
                stem = word.StemA;
            }
            else
            {
                stem = inflection.Sort switch
                {
                    NumeralSorting.Ordinal => word.StemB,
                    NumeralSorting.Distributive => word.StemC,
                    NumeralSorting.Adverb => word.StemD,
                    _ => stem
                };
            }

            if (String.IsNullOrEmpty(stem)) return;
            
            forms.Add(new InflectedNumeral
            {
                Form = stem + inflection.Ending,
                Stem = stem,
                Ending = inflection.Ending,
                Meaning = word.Meaning,
                PartOfSpeech = word.PartOfSpeech,
                Age = inflection.Age,
                Subject = word.Subject,
                GeographicalSource = word.GeographicalSource,
                Frequency = inflection.Frequency,
                Source = word.Source,
                
                Declension = numeral.Declension,
                DeclensionVariant = numeral.DeclensionVariant,
                
                Case = inflection.Case,
                Number = inflection.Number,
                Gender = inflection.Gender,
                Kind = NounKind.AbstractIdea,
                
                Sorting = inflection.Sort,
                Value = numeral.Value
            });
        }
    }
    
    private InflectedForm[] DeclineAdjective(Word word)
    {
        if (word.Info is not Adjective adjective) return Array.Empty<InflectedForm>();

        var table1 = InflectionMap.AdjectiveInflections[adjective.Declension].GetOrEmpty(adjective.DeclensionVariant);
        var table2 = adjective.DeclensionVariant != 0 ? InflectionMap.AdjectiveInflections[adjective.Declension].GetOrEmpty(0) : DictionaryExtensions.EmptyLists<AdjectiveInflection>.Value;
        var table3 = InflectionMap.AdjectiveInflections[0][0];
        
        var forms = new List<InflectedForm>(table1.Count + table2.Count + table3.Count);
        var completed = new HashSet<InflectedForm>();

        for (var i = 0; i < table1.Count; i++)
        {
            AddForm(table1[i]);
        }
        for (var i = 0; i < table2.Count; i++)
        {
            var form = table2[i];
            AddForm(form);
        }

        // Don't try to decline indeclinable adjectives.
        if (adjective is { Declension: 9 }) return forms.ToArray();
        
        for (var i = 0; i < table3.Count; i++)
        {
            var form = table3[i];
            AddForm(form);
        }

        return forms.ToArray();

        void AddForm(AdjectiveInflection inflection)
        {
            if (adjective.Comparison is Comparison.Comparative or Comparison.Superlative)
            {
                if (adjective.Comparison != inflection.Comparison) return;
            }
            
            string? stem;
            
            if (
                inflection.Comparison is Comparison.Unknown or Comparison.Positive
                && (
                    inflection is { Case: Case.Nominative or Case.Vocative, Number: Number.Singular }
                    || adjective is { Declension: 3, DeclensionVariant: 1 } && inflection is
                        { Case: Case.Accusative, Gender: Gender.Neuter, Number: Number.Singular }
                )
            )
            {
                stem = word.StemA;
            }
            else if (adjective.Comparison is Comparison.Unknown or Comparison.Positive)
            {
                // Use the first (and only) stem for indeclinable adjectives.
                if (adjective is { Declension: 9 })
                {
                    stem = word.StemA;
                }
                else
                {
                    stem = inflection.Comparison switch
                    {
                        Comparison.Comparative => word.StemC,
                        Comparison.Superlative => word.StemD,
                        _ => word.StemB
                    };
                }
            }
            else
            {
                stem = word.StemA;
            }

            if (stem is null) return;

            var form = new InflectedAdjective()
            {
                Form = stem + inflection.Ending,
                Stem = stem,
                Ending = inflection.Ending,
                Meaning = word.Meaning,
                PartOfSpeech = word.PartOfSpeech,
                Age = inflection.Age,
                Subject = word.Subject,
                GeographicalSource = word.GeographicalSource,
                Frequency = inflection.Frequency,
                Source = word.Source,

                Declension = adjective.Declension,
                DeclensionVariant = adjective.DeclensionVariant,

                Case = inflection.Case,
                Number = inflection.Number,
                Gender = inflection.Gender,

                Comparison = inflection.Comparison
            };

            if (!completed.Contains(form))
            {
                forms.Add(form);
                completed.Add(form);
            }
        }
    }
    
    private InflectedForm[] ConjugateVerb(Word word)
    {
        if (word.Info is not Verb verb) return Array.Empty<InflectedForm>();

        var table1 = InflectionMap.VerbInflections[verb.Conjugation].GetOrEmpty(verb.ConjugationVariant);
        var table2 = verb.ConjugationVariant != 0 ? InflectionMap.VerbInflections[verb.Conjugation].GetOrEmpty(0) : DictionaryExtensions.EmptyLists<VerbInflection>.Value;
        var table3 = InflectionMap.VerbInflections[0][0];
        
        var table4 = InflectionMap.SupineInflections[0][0];
        
        var table5 =
            InflectionMap.VerbParticipleInflections.TryGetValue(verb.Conjugation, out var participleTable5)
                ? participleTable5.GetOrEmpty(verb.ConjugationVariant)
                : DictionaryExtensions.EmptyLists<VerbalNounInflection>.Value;
        var table6 =
            InflectionMap.VerbParticipleInflections.TryGetValue(verb.Conjugation, out var participleTable6)
                ? participleTable6.GetOrEmpty(0)
                : DictionaryExtensions.EmptyLists<VerbalNounInflection>.Value;
        var table7 = InflectionMap.VerbParticipleInflections[0][0];
        
        var forms = new List<InflectedForm>(table1.Count + table2.Count + table3.Count + table4.Count + table5.Count + table6.Count + table7.Count);

        void AddSupineForm(SupineInflection inflection)
        {
            if (word.StemD is null) return;
            var composed = word.StemD + inflection.Ending;
            
            forms.Add(new InflectedNoun()
            {
                Form = composed,
                Stem = word.StemD,
                Ending = inflection.Ending,
                Meaning = word.Meaning,
                PartOfSpeech = PartOfSpeech.Supine,
                Age = inflection.Age,
                Subject = word.Subject,
                GeographicalSource = word.GeographicalSource,
                Frequency = inflection.Frequency,
                Source = word.Source,
                
                Declension = inflection.Conjugation,
                DeclensionVariant = inflection.ConjugationVariant,
                
                Case = inflection.Case,
                Number = inflection.Number,
                Gender = inflection.Gender,
                
                Kind = NounKind.AbstractIdea
            });
        }
        void AddParticipleForm(VerbalNounInflection inflection)
        {
            if (verb.VerbKind is VerbKind.ToBe or VerbKind.ToBeing)
            {
                if (inflection.Tense != Tense.Future && inflection.Tense != Tense.FuturePerfect && inflection.Tense != Tense.Pluperfect) return;
            }
            
            var stem =
                inflection.Tense == Tense.Present || inflection is { Tense: Tense.Future, Voice: Voice.Passive } ?
                    word.StemA :
                    word.StemD;

            var composed = stem + inflection.Ending;
            
            switch (inflection.Tense)
            {
                case Tense.Future:
                case Tense.Perfect:
                    if (word.StemD is null) return;
                    break;
                default:
                    if (word.StemA is null) return;
                    break;
            }
            
            forms.Add(new InflectedParticiple()
            {
                Form = composed,
                Stem = stem,
                Ending = inflection.Ending ,
                Meaning = word.Meaning,
                PartOfSpeech = PartOfSpeech.VerbParticiple,
                Age = inflection.Age,
                Subject = word.Subject,
                GeographicalSource = word.GeographicalSource,
                Frequency = inflection.Frequency,
                Source = word.Source,
                
                Declension = inflection.Conjugation,
                DeclensionVariant = inflection.ConjugationVariant,
                
                Case = inflection.Case,
                Number = inflection.Number,
                Gender = inflection.Gender,
                
                Comparison = Comparison.Unknown,
                
                Tense = inflection.Tense,
                Voice = inflection.Voice,
                Mood = inflection.Mood
            });
        }
        
        for (var i = 0; i < table1.Count; i++)
        {
            AddForm(table1[i]);
        }

        for (var i = 0; i < table2.Count; i++)
        {
            AddForm(table2[i]);
        }
        
        for (var i = 0; i < table3.Count; i++)
        {
            AddForm(table3[i]);
        }

        if (verb.VerbKind != VerbKind.ToBe && verb.VerbKind != VerbKind.ToBeing)
        {
            for (var i = 0; i < table4.Count; i++)
            {
                AddSupineForm(table4[i]);
            }
        }
        
        for (var i = 0; i < table5.Count; i++)
        {
            AddParticipleForm(table5[i]);
        }
        for (var i = 0; i < table6.Count; i++)
        {
            AddParticipleForm(table6[i]);
        }
        for (var i = 0; i < table7.Count; i++)
        {
            AddParticipleForm(table7[i]);
        }
        
        return forms.ToArray();

        void AddForm(VerbInflection inflection)
        {
            if (verb.VerbKind == VerbKind.Deponent && inflection.Voice == Voice.Active) return;
            
            string? stem = null;

            // This is kind of bad kludge, but what to do about it being entirely irregular?
            if (verb.VerbKind == VerbKind.ToBe)
            {
                stem = inflection switch
                {
                    {
                            Tense: Tense.Present,
                            Voice: Voice.Active,
                            Mood: Mood.Indicative,
                            Number: Number.Singular or Number.Plural,
                            Person: Person.First
                        }
                        or {
                            Tense: Tense.Present,
                            Voice: Voice.Active,
                            Mood: Mood.Indicative,
                            Person: Person.Third,
                            Number: Number.Plural
                        }
                        or { Tense: Tense.Present, Voice: Voice.Active, Mood: Mood.Subjunctive } => word.StemA ?? "",
                    
                    { Tense: Tense.Perfect or Tense.FuturePerfect or Tense.Pluperfect } => word.StemC ?? "",
                    
                    { Mood: Mood.Infinitive } =>
                        word.StemB ?? "",
                    
                    _ => ""
                };
            }
            // Verbs like volo
            else if (verb is { Conjugation: 6, ConjugationVariant: 2 })
            {
                stem = inflection switch
                {
                    { Tense: Tense.Present, Mood: Mood.Indicative, Number: Number.Singular, Person: Person.First } => word.StemA,
                    { Tense: Tense.Perfect } => word.StemC,
                    { Mood: Mood.Infinitive or Mood.Subjunctive } => word.StemB,
                    _ => word.StemA
                };
            }
            else
            {
                if (inflection is { Tense: Tense.Present, Mood: Mood.Indicative, Number: Number.Singular, Person: Person.First })
                {
                    stem = word.StemA;
                }
                else if (inflection.Tense == Tense.Perfect)
                {
                    stem = word.StemC;
                }
                else if (inflection.Mood == Mood.Infinitive)
                {
                    // possum, posse, potui
                    stem = inflection is { Conjugation: 5, ConjugationVariant: 2 } ? word.StemA : word.StemB;
                }
                else
                {
                    stem = word.StemB;
                }
            }

            if (stem is null) return;

            var composed = stem + inflection.Ending;
            var prior = Add(composed, null);

            if (inflection.Tense != Tense.Perfect) return;
            
            foreach (var syncope in TrickTables.Syncopes)
            {
                var index = composed.LastIndexOf(syncope.Before, StringComparison.Ordinal);
                if (index == -1) continue;
                
                var before = composed.Substring(0, index);
                var after = composed.Substring(index + syncope.Before.Length);
                
                Add(before + syncope.After + after, (prior, syncope));
            }

            return;
            
            InflectedVerb Add(string form, (InflectedVerb priorForm, Syncope syncope)? syncope)
            {
                var inflectedForm = new InflectedVerb()
                {
                    Form = form,
                    Stem = stem,
                    Ending = inflection.Ending,
                    Meaning = word.Meaning,
                    PartOfSpeech = word.PartOfSpeech,
                    Age = inflection.Age,
                    Subject = word.Subject,
                    GeographicalSource = word.GeographicalSource,
                    Frequency = inflection.Frequency,
                    Source = word.Source,

                    Conjugation = verb.Conjugation,
                    ConjugationVariant = verb.ConjugationVariant,

                    Tense = inflection.Tense,
                    Voice = inflection.Voice,
                    Mood = inflection.Mood,

                    Person = inflection.Person,
                    Number = inflection.Number,

                    Kind = verb.VerbKind,
                    Syncope = syncope
                };
                forms.Add(inflectedForm);
                return inflectedForm;
            }
        }
    }
    
    // Uninflected words that needed to be included nevertheless.
    private static InflectedForm[] InflectAdverb(Word word)
    {
        if (word.Info is not Adverb adverb || word.StemA is null) return Array.Empty<InflectedForm>();
        
        return
        [
            new InflectedAdverb
            {
                Form = word.StemA,
                Stem = word.StemA,
                Ending = null,
                PartOfSpeech = word.PartOfSpeech,
                Age = word.Age,
                Subject = word.Subject,
                GeographicalSource = word.GeographicalSource,
                Frequency = word.Frequency,
                Source = word.Source,
                Meaning = word.Meaning,
                
                Comparison = adverb.Comparison
            }
        ];
    }
    private static InflectedForm[] InflectPreposition(Word word)
    {
        if (word.Info is not Preposition preposition || word.StemA is null) return Array.Empty<InflectedForm>();
        
        return
        [
            new InflectedPreposition
            {
                Form = word.StemA,
                Stem = word.StemA,
                Ending = null,
                PartOfSpeech = word.PartOfSpeech,
                Age = word.Age,
                Subject = word.Subject,
                GeographicalSource = word.GeographicalSource,
                Frequency = word.Frequency,
                Source = word.Source,
                Meaning = word.Meaning,
                
                Case = preposition.Case
            }
        ];
    }
    private static InflectedForm[] InflectConjunction(Word word)
    {
        if (word.Info is not Conjunction || word.StemA is null) return Array.Empty<InflectedForm>();

        return
        [
            new InflectedConjunction
            {
                Form = word.StemA,
                Stem = word.StemA,
                Ending = null,
                PartOfSpeech = word.PartOfSpeech,
                Age = word.Age,
                Subject = word.Subject,
                GeographicalSource = word.GeographicalSource,
                Frequency = word.Frequency,
                Source = word.Source,
                Meaning = word.Meaning,
            }
        ];
    }
    private static InflectedForm[] InflectInterjection(Word word)
    {
        if (word.Info is not Interjection || word.StemA is null) return Array.Empty<InflectedForm>();
        
        return
        [
            new InflectedInterjection()
            {
                Form = word.StemA,
                Stem = word.StemA,
                Ending = null,
                PartOfSpeech = word.PartOfSpeech,
                Age = word.Age,
                Subject = word.Subject,
                GeographicalSource = word.GeographicalSource,
                Frequency = word.Frequency,
                Source = word.Source,
                Meaning = word.Meaning,
            }
        ];
    }

    /// <summary>
    /// Declines/conjugates the word or returns the base stems if it does not inflect.
    /// </summary>
    /// <param name="word">The word to inflect.</param>
    /// <param name="expandInflectionCache">Set to true during loading to build the inflection cache.</param>
    /// <returns>The inflected forms of the word, or an array of stems.</returns>
    public InflectedForm[] Inflect(Word word, bool expandInflectionCache = false)
    {
        if (_inflectionTable.TryGetValue(word, out var forms))
        {
            return forms;
        }
        
        var computedForms = word.PartOfSpeech switch
        {
            PartOfSpeech.Noun => DeclineNoun(word),
            PartOfSpeech.Numeral => DeclineNumeral(word),

            PartOfSpeech.Pronoun => DeclinePronoun(word),
            PartOfSpeech.Packon => DeclinePronoun(word),

            PartOfSpeech.Adjective => DeclineAdjective(word),

            PartOfSpeech.Verb => ConjugateVerb(word),

            PartOfSpeech.Adverb => InflectAdverb(word),
            PartOfSpeech.Preposition => InflectPreposition(word),
            PartOfSpeech.Conjunction => InflectConjunction(word),
            PartOfSpeech.Interjection => InflectInterjection(word),

            PartOfSpeech.VerbParticiple => Array.Empty<InflectedForm>(),
            PartOfSpeech.Supine => Array.Empty<InflectedForm>(),
            PartOfSpeech.Unknown => Array.Empty<InflectedForm>(),
            _ => Array.Empty<InflectedForm>()
        };
        
        if (expandInflectionCache || _settings.DynamicallyExpandInflectionCache)
        {
            _inflectionTable[word] = computedForms;
        }

        return computedForms;
    }
    
    /// <summary>
    /// Returns the standard principle parts of a word.
    /// </summary>
    public InflectedForm?[] Present(Word word)
    {
        var forms = Inflect(word).OrderBy(form => form.Frequency).ToArray();
        
        InflectedForm? FindCases(Case[] cases, Number[] numbers, Gender[] genders)
        {
            foreach (var @case in cases)
            {
                foreach (var number in numbers)
                {
                    foreach (var gender in genders)
                    {
                        foreach (var form in forms)
                        {
                            if (form is InflectedDeclineable declineable && declineable.Case == @case && declineable.Number == number && declineable.Gender == gender)
                            {
                                return form;
                            }
                        }
                                
                    }
                }
            }

            return null;
        }
        InflectedForm? FindSingleCase(Case @case, Number[] numbers)
        {
            foreach (var form in forms)
            {
                foreach (var number in numbers)
                {
                    if (form is InflectedDeclineable declinable && declinable.Case == @case && declinable.Number == number)
                    {
                        return form;
                    }
                }
            }

            return null;
        }
        
        var caseOrdering = new[] { Case.Nominative };
        var numberOrdering = new[] { Number.Singular, Number.Unknown, Number.Plural };
        
        switch (word.PartOfSpeech)
        {
            case PartOfSpeech.Noun:
            {
                var nominative =
                    forms.FirstOrDefault(form => form is InflectedNoun { Case: Case.Nominative, Number: Number.Singular })
                    ?? forms.FirstOrDefault(form => form is InflectedNoun { Case: Case.Nominative, Number: Number.Plural })
                    ?? forms.FirstOrDefault(form => form is InflectedNoun { Case: Case.Unknown, Number: Number.Unknown });
                
                var genitive =
                    forms.FirstOrDefault(form => form is InflectedNoun { Case: Case.Genitive, Number: Number.Singular })
                    ?? forms.FirstOrDefault(form => form is InflectedNoun { Case: Case.Genitive, Number: Number.Plural });

                if (nominative is not null && genitive is null)
                {
                    return [nominative];
                }
                if (nominative is null && genitive is null && forms.Length == 1)
                {
                    return forms;
                }
                
                return [nominative, genitive];
            }
            
            case PartOfSpeech.Numeral:
            {
                var cardinal =
                    forms.FirstOrDefault(form => form is InflectedNumeral { Case: Case.Nominative, Sorting: NumeralSorting.Cardinal });
                
                var ordinal =
                    forms.FirstOrDefault(form => form is InflectedNumeral { Case: Case.Nominative, Sorting: NumeralSorting.Ordinal });
                
                return [cardinal, ordinal];
            }

            case PartOfSpeech.Packon:
            case PartOfSpeech.Pronoun:
            {
                var preferSingular = new[] { Number.Singular, Number.Unknown, Number.Plural };
                
                if (word.Info is Pronoun pronoun)
                {
                    if (pronoun.Declension == 5)
                    {
                        var nominative = FindSingleCase(Case.Nominative, preferSingular);
                        var genitive = FindSingleCase(Case.Genitive, preferSingular);

                        return [nominative, genitive];
                    }
                }
                
                var masculine = FindCases(caseOrdering, numberOrdering, [Gender.Masculine, Gender.Common, Gender.Unknown
                ]);
                var feminine = FindCases(caseOrdering, numberOrdering, [Gender.Feminine, Gender.Common, Gender.Unknown]);
                var neuter = FindCases(caseOrdering, numberOrdering, [Gender.Neuter, Gender.Common, Gender.Unknown]);
                
                return [masculine, feminine, neuter];
            }
            
            case PartOfSpeech.Adjective:
            {
                var normal = forms.FirstOrDefault(form => form is InflectedAdjective { Case: Case.Nominative, Comparison: Comparison.Unknown or Comparison.Positive });
                var comp = forms.FirstOrDefault(form => form is InflectedAdjective { Case: Case.Nominative, Comparison: Comparison.Comparative });
                var super = forms.FirstOrDefault(form => form is InflectedAdjective { Case: Case.Nominative, Gender: Gender.Masculine, Comparison: Comparison.Superlative });
                
                if (word.Info is Adjective { Comparison: Comparison.Comparative or Comparison.Superlative } || normal is null || comp is null || super is null)
                {
                    var masculine = FindCases(caseOrdering, numberOrdering, [Gender.Masculine, Gender.Common, Gender.Unknown
                    ]);
                    var feminine = FindCases(caseOrdering, numberOrdering, [Gender.Feminine, Gender.Common, Gender.Unknown
                    ]);
                    var neuter = FindCases(caseOrdering, numberOrdering, [Gender.Neuter, Gender.Common, Gender.Unknown]);
                
                    return [masculine, feminine, neuter];                    
                }

                return [normal, comp, super];
            }
            
            case PartOfSpeech.Verb:
            {
                var first = forms.FirstOrDefault(form => form is InflectedVerb
                {
                    Person: Person.First, Number: Number.Singular, Tense: Tense.Present, Voice: Voice.Active, Mood: Mood.Indicative
                }) ?? forms.FirstOrDefault(form => form  is InflectedVerb
                {
                    Person: Person.First, Number: Number.Singular, Tense: Tense.Present, Voice: Voice.Passive, Mood: Mood.Indicative
                });
                
                var second = forms.FirstOrDefault(form => form is InflectedVerb
                {
                    Voice: Voice.Active, Mood: Mood.Infinitive, Tense: Tense.Present
                }) ?? forms.FirstOrDefault(form => form is InflectedVerb
                {
                    Voice: Voice.Passive, Mood: Mood.Infinitive, Tense: Tense.Present
                });
                
                var third = forms.FirstOrDefault(form => form is InflectedVerb
                {
                    Person: Person.First, Number: Number.Singular, Tense: Tense.Perfect, Voice: Voice.Active, Mood: Mood.Indicative, Syncope: null
                }) ?? forms.FirstOrDefault(form => form is InflectedVerb
                {
                    Person: Person.First, Number: Number.Singular, Tense: Tense.Perfect, Voice: Voice.Passive, Mood: Mood.Indicative, Syncope: null
                });

                var fourth =
                    word.Info is Verb { VerbKind: VerbKind.ToBe or VerbKind.ToBeing } ?
                        forms.FirstOrDefault(form => form is InflectedParticiple
                        {
                            Number: Number.Singular, Tense: Tense.Future, Voice: Voice.Active, Mood: Mood.Participle, Case: Case.Nominative
                        }) :
                    
                        forms.FirstOrDefault(form => form is InflectedParticiple
                        {
                            Number: Number.Singular, Tense: Tense.Perfect, Voice: Voice.Passive, Mood: Mood.Indicative or Mood.Participle, Case: Case.Nominative
                        });
                
                return [first, second, third, fourth];
            }
            
            case PartOfSpeech.Adverb:
                return InflectAdverb(word);
            case PartOfSpeech.Preposition:
                return InflectPreposition(word);
            case PartOfSpeech.Conjunction:
                return InflectConjunction(word);
            case PartOfSpeech.Interjection:
                return InflectInterjection(word);
            
            case PartOfSpeech.VerbParticiple:
            case PartOfSpeech.Supine:
            case PartOfSpeech.Unknown:
            default:
                return Array.Empty<InflectedForm>();
        }
    }
}