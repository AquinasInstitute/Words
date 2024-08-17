using Words.Addons;
using Words.Extensions;
using Words.Inflected;
using Words.Words;

namespace Words;

public partial class LatinDictionary
{
    /// <summary>
    /// Looks up the specified latin form in the dictionary.
    /// This version does not handle addons of any kind, which all but guarantees a consistently fast lookup time.
    /// It does, however, consider all available tricks that are enabled.
    /// </summary>
    private (Word? word, InflectedForm[] forms)[] LookupLatinFormInternal(string form)
    {
        var options = PerformTricks(CleanForm(form));

        for (var i = 0; i < options.Count; i++)
        {
            var option = options[i];
            
            if (LatinLookup.TryGetValue(option, out var result))
            {
                return result
                    .GroupBy(pair => pair.word)
                    .Select(group => (group.Key, group.Select(pair => pair.form).ToArray()))
                    .ToArray();
            }
        }

        return Array.Empty<(Word?, InflectedForm[])>();
    }

    /// <summary>
    /// Looks up the specified latin form in the dictionary using the addons table to enlarge the searched word count.
    /// This function is potentially costly (relative to the normal version) so use with caution.
    /// </summary>
    /// <param name="form">The inflected Latin word to lookup.</param>
    /// <param name="skipNormalLookup">Don't do the normal lookup and go right to using the addons table. Useful if using this function as a fallback.</param>
    /// <param name="stopEarly">Stops the search as soon as a match is found. Often times this can greatly speedup the process with no real loss of information.</param>
    public (Word? word, (InflectedForm form, Addon[] addons)[] forms)[] LookupLatinForm(string form, bool skipNormalLookup = false, bool stopEarly = false)
    {
        form = CleanForm(form);
        
        if (form.Contains(' '))
        {
            var parts = form.Split(' ');
            var results = new List<(Word? word, (InflectedForm form, Addon[] addons)[] forms)>();

            foreach (var part in parts)
            {
                results.AddRange(LookupLatinForm(part));
            }

            return results.ToArray();
        }
        
        if (!skipNormalLookup)
        {
            var attempt = LookupLatinFormInternal(form);

            if (attempt.Length > 0)
            {
                return attempt
                    .Select(pair => (pair.word, pair.forms.Select(inflectedForm => (form: inflectedForm, Array.Empty<Addon>())).ToArray()))
                    .ToArray();
            }
        }

        var result = new Dictionary<InflectedForm, (Word? word, Addon[] addons)>();
        var tricks = PerformTricks(form);
        
        for (var i = 0; i < tricks.Count; i++)
        {
            var trickForm = tricks[i];
            var choices = HandleAddons(trickForm);
        
            foreach (var (reducedForm, addons) in choices)
            {
                Suffix? suffix = null;

                foreach (var addon in addons)
                {
                    if (addon is not Suffix suffix1) continue;
                    suffix = suffix1;
                    break;
                }

                if (suffix is not null && suffix.To != suffix.From)
                {
                    if (_settings.UseExtendedLookupTable)
                    {
                        if (LatinExtendedLookup.TryGetValue(suffix, out var suffixTable) && suffixTable.TryGetValue(reducedForm, out var matches))
                        {
                            foreach (var (inflectedForm, word) in matches)
                            {
                                if (inflectedForm.PartOfSpeech != suffix.To) continue;
                                if (word is null) continue;
                                
                                var skip = false;

                                foreach (var addon in addons)
                                {
                                    if (IsAddonCompatible(inflectedForm, addon)) continue;
                                    skip = true;
                                    break;
                                }
                                
                                if (skip) continue;
                                
                                result.GetOrAdd(inflectedForm, () => (word, addons));
                            }
                        }
                    }
                    else
                    {
                        foreach (var word in WordList)
                        {
                            if (word.PartOfSpeech != suffix.From) continue;

                            if (
                                !reducedForm.StartsWith(word.StemA ?? "-") && !reducedForm.StartsWith(word.StemB ?? "-")
                                && !reducedForm.StartsWith(word.StemC ?? "-") && !reducedForm.StartsWith(word.StemD ?? "-")
                            )
                            {
                                continue;
                            }
                            
                            var fake = word with
                            {
                                PartOfSpeech = suffix.To,
                                Info = suffix.Result
                            };
                            var inflected = Inflect(fake);

                            foreach (var fakeForm in inflected)
                            {
                                if (fakeForm.Form.Length < reducedForm.Length) continue;
                                if (fakeForm.Form != reducedForm) continue;

                                var skip = false;

                                foreach (var addon in addons)
                                {
                                    if (IsAddonCompatible(fakeForm, addon)) continue;
                                    skip = true;
                                    break;
                                }
                                
                                if (skip) continue;
                                
                                result.GetOrAdd(fakeForm, () => (word, addons));
                            }
                        }
                    }
                }
                else if (LatinLookup.TryGetValue(reducedForm, out var potential))
                {
                    foreach (var (inflectedForm, word) in potential)
                    {
                        var skip = false;

                        foreach (var addon in addons)
                        {
                            if (IsAddonCompatible(inflectedForm, addon)) continue;
                            skip = true;
                            break;
                        }
                        
                        if (skip) continue;
                        
                        result.GetOrAdd(inflectedForm, () => (word, addons));
                    }
                }

                if (stopEarly && result.Count > 0)
                {
                    return result
                        .Select(pair => (pair.Value.word, (pair.Key, pair.Value.addons.ToArray())))
                        .GroupBy(pair => pair.word)
                        .Select(group => (group.Key, group.Select(pair => pair.Item2).ToArray()))
                        .ToArray();
                }
            }
        }

        return result
            .Select(pair => (pair.Value.word, (pair.Key, pair.Value.addons.ToArray())))
            .GroupBy(pair => pair.word)
            .Select(group => (group.Key, group.Select(pair => pair.Item2).ToArray()))
            .ToArray();
    }

    public static readonly char[] WordSeparators = [
        '~', '`', '!', '@', '#', '$', '%', '^', '&', '*', '(', ')', '-', '_', '=', '+', '[', ']', '{', '}', '\\', '|', ';', ':', '\'', '"', '<', '>', ',', '.', '/', '?'
    ];

    public Word[] LookupEnglishWord(string englishWord)
    {
        englishWord = englishWord.ToLower();
        return !EnglishLookup.TryGetValue(englishWord, out var list) ? [] : list.ToArray();
    }
    
    /// <summary>
    /// Looks up irregular forms using the specified english word.
    /// </summary>
    public InflectedForm[] LookupIrregularFormFromEnglish(string englishWord)
    {
        englishWord = englishWord.ToLowerInvariant();
        
        var result = new Dictionary<InflectedForm, int>();

        foreach (var pair in EnglishIrregularLookup)
        {
            var (meaning, form) = pair;

            if (meaning.Contains(englishWord))
            {
                result[form] = result.GetValueOrDefault(form, 0) + 1;
            }
        }

        return result.OrderByDescending(pair => pair.Value).Select(pair => pair.Key).ToArray();
    }

    /// <summary>
    /// Returns an iterator that goes through all (regular) words in the dictionary.
    /// To enumerate irregular words, call EnumerateIrregularWords.
    /// </summary>
    public IEnumerable<Word> EnumerateWords() => WordList.Select(v => v);
    /// <summary>
    /// Enumerates all inflected forms that don't have a matching word entry, that is, anything from the uniques file.
    /// </summary>
    public IEnumerable<InflectedForm> EnumerateIrregularWords() => IrregularWords.Select(v => v);
    /// <summary>
    /// Enumerates all inflected forms in the lookup table, returning a tuple of the text form and the array of all matching inflected form/word combos.
    /// </summary>
    public IEnumerable<(string inflectedForm, (InflectedForm form, Word? word)[])> EnumerateInflectedForms() =>
        LatinLookup.Select(pair => (pair.Key, pair.Value.ToArray()));

    /// <summary>
    /// Enumerates just suffixes. Helpful for data sources wanting to implement extended lookup support.
    /// </summary>
    public IEnumerable<Suffix> EnumerateSuffixes() => Suffixes.Select(v => v);
    
    /// <summary>
    /// Enumerates all addons in the system.
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Addon> EnumerateAddons() => Prefixes.Concat<Addon>(Suffixes).Concat(Tackons).Concat(Packons);
    
    /// <summary>
    /// Note that this method is *potentially* unsafe as it returns the underlying inflection map with no wrapper, allowing the caller to modify it at will.
    /// </summary>
    public InflectionMaps GetInflectionMap() => InflectionMap;
}