using System.Text;
using Words.Addons;
using Words.Extensions;
using Words.Flags;
using Words.Inflected;
using Words.Tricks;
using Words.Words;

namespace Words;

public partial class LatinDictionary
{
    private List<(string, Addon[])> HandleAddons(string originalForm)
    {
        var state = new List<(string, Addon[])> { (originalForm, Array.Empty<Addon>()) };

        foreach (var prefix in Prefixes)
        {
            if (originalForm.StartsWith(prefix.Word))
            {
                state.Add((originalForm[prefix.Word.Length..], [prefix]));
            }
        }

        var tackonCount = state.Count;
        var foundTackon = false;
        
        foreach (var tackon in Tackons)
        {
            for (var i = 0; i < tackonCount; i++)
            {
                var (form, addons) = state[i];

                if (!form.EndsWith(tackon.Word)) continue;
                var newAddons = new Addon[addons.Length + 1];
                addons.CopyTo(newAddons, 0);
                newAddons[^1] = tackon;
                    
                state.Add((form[..^tackon.Word.Length], newAddons));
                foundTackon = true;
            }
        }

        if (!foundTackon)
        {
            foreach (var packon in Packons)
            {
                for (var i = 0; i < tackonCount; i++)
                {
                    var (form, addons) = state[i];

                    if (!form.EndsWith(packon.Word)) continue;
                    var newAddons = new Addon[addons.Length + 1];
                    addons.CopyTo(newAddons, 0);
                    newAddons[^1] = packon;
                    
                    state.Add((form[..^packon.Word.Length], newAddons));
                }
            }   
        }

        var count = state.Count;
        
        for (var i = 0; i < count; i++)
        {
            foreach (var suffix in Suffixes)
            {
                var (form, addons) = state[i];
                
                var index = form.LastIndexOf(suffix.Word, StringComparison.Ordinal);
                if (index == -1) continue;
                
                var before = form.Substring(0, index);
                var after = form.Substring(index + suffix.Word.Length);

                var isValidStem = false;

                foreach (var inflection in Inflections)
                {
                    if (inflection.Ending == after)
                    {
                        isValidStem = true;
                    }
                }
                
                if (!isValidStem) continue;

                var newAddons = new Addon[addons.Length + 1];
                addons.CopyTo(newAddons, 0);
                newAddons[^1] = suffix;
                    
                state.Add((before + after, newAddons));
            }
        }

        return state;
    }

    private List<string> PerformTricks(string form)
    {
        if (string.IsNullOrWhiteSpace(form))
        {
            return DictionaryExtensions.EmptyLists<string>.Value;
        }
        
        var result = new List<string>(10) { form };

        if (_settings.DoBasicTricks)
        {
            var alternative = form.ReplaceFirst("i", "j");

            if (form != alternative)
            {
                result.Add(alternative);
            }

            alternative = form.ReplaceFirst("u", "v");

            if (form != alternative)
            {
                result.Add(alternative);
            }

            alternative = form.ReplaceFirst("n", "m");

            if (form != alternative)
            {
                result.Add(alternative);
            }
        }

        if (_settings.DoGenericTricks)
        {
            foreach (var trick in TrickTables.AnyTricks)
            {
                if (TrickTables.IsTrickRelevant(trick, form))
                {
                    result.Add(TrickTables.PerformTrick(trick, form));
                }
            }

            var tricks = TrickTables.TricksTable.GetValueOrDefault(form[0], Array.Empty<Trick>());
            
            foreach (var trick in tricks)
            {
                if (TrickTables.IsTrickRelevant(trick, form))
                {
                    result.Add(TrickTables.PerformTrick(trick, form));
                }
            }
        }

        if (_settings.DoMedievalTricks)
        {
            foreach (var trick in TrickTables.Mediaeval_Tricks)
            {
                if (TrickTables.IsTrickRelevant(trick, form))
                {
                    result.Add(TrickTables.PerformTrick(trick, form));
                }
            }
        }

        if (_settings.DoSlurTricks)
        {
            var tricks = TrickTables.SlursTable.GetValueOrDefault(form[0], Array.Empty<Trick>());

            foreach (var trick in tricks)
            {
                if (TrickTables.IsTrickRelevant(trick, form))
                {
                    result.Add(TrickTables.PerformTrick(trick, form));
                }
            }
        }
        
        return result;
    }
    
    private static string ReplaceVowels(string original)
    {
        var result = new StringBuilder(original.Length);

        for (var i = 0; i < original.Length; i++)
        {
            if (TrickTables.VowelMap.TryGetValue(original[i], out var replacement))
            {
                result.Append(replacement);
            }
            else
            {
                result.Append(original[i]);
            }
        }
        
        return result.ToString();
    }

    /// <summary>
    /// Normalizes a form by replacing macrons, trimming, and removing unneeded punctuation.
    /// </summary>
    /// <param name="form">The form to normalize.</param>
    /// <returns>The normalized form.</returns>
    public static string CleanForm(string form)
    {
        return ReplaceVowels(
            form
                .Trim()
                .ToLowerInvariant()
                .Replace("-", "")
                .Replace(".", "")
                .Replace("!", "")
                .Replace("?", "")
                .Replace(":", "")
                .Replace(";", "")
                .Replace(",", "")
                .Replace("(", "")
                .Replace(")", "")
                .Replace("[", "")
                .Replace("]", "")
                .Replace("{", "")
                .Replace("}", "")
        );
    }

    private static bool AreGroupsEqual((int a, int b) source, (int a, int b) test)
    {
        return (test.a == 0 || source.a == test.a) && (test.b == 0 || source.b == test.b);
    }
    
    /// <summary>
    /// Determines if the specified addon can be applied to the specified form.
    /// </summary>
    /// <param name="form">The form to check against.</param>
    /// <param name="addon">The addon to check.</param>
    /// <returns>Whether or not the specified addon can be applied to the specified form.</returns>
    public static bool IsAddonCompatible(InflectedForm form, Addon addon)
    {
        if (addon is Suffix suffix)
        {
            if (suffix.From != suffix.To)
            {
                if (form.PartOfSpeech != suffix.To) return false;
            }
            else
            {
                if (form.PartOfSpeech != suffix.From) return false;
            }
        }
        else
        {
            if (addon.From != PartOfSpeech.Unknown && form.PartOfSpeech != addon.From) return false;
        }
        
        if (addon is Tackon tackon)
        {
            if (tackon.IsPackon && form.PartOfSpeech != PartOfSpeech.Packon) return false;
            
            if (
                (form is InflectedNoun source1
                 && tackon.TargetInfo is Declineable target1
                 && !AreGroupsEqual((source1.Declension, source1.DeclensionVariant),
                     (target1.Declension, target1.DeclensionVariant))
                ) ||
                (form is InflectedVerb source2
                 && tackon.TargetInfo is Verb target2
                 && !AreGroupsEqual((source2.Conjugation, source2.ConjugationVariant),
                     (target2.Conjugation, target2.ConjugationVariant))
                )
            )
            {
                return false;
            }
        }

        return true;
    }
}