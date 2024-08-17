using System.Collections.Concurrent;
using Words.Addons;
using Words.Data_Sources;
using Words.Inflected;
using Words.Words;

namespace Words;

public partial class LatinDictionary
{
    public LatinDictionary(LatinDictionarySettings settings, IDictionaryDataSource dataSource)
    {
        _settings = settings;

        (InflectionMap, Inflections) = dataSource.LoadInflections(settings);

        var tables = dataSource.LoadWords(settings, this);

        LatinLookup = tables.LookupTable;
        LatinExtendedLookup = tables.ExtendedLookupTable;
        WordList = tables.WordList;
        IrregularWords = tables.IrregularWords;
        EnglishIrregularLookup = tables.EnglishIrregularLookup;
        
        (Prefixes, Suffixes, Tackons, Packons) = dataSource.LoadAddons(settings);
        
        dataSource.CleanUp();
        
        foreach (var word in WordList)
        {
            var chunks = word.Meaning.ToLower().Split(WordSeparators, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            foreach (var chunk in chunks)
            {
                EnglishLookup.GetOrAdd(chunk, _ => []).Add(word);
            }
        }
    }

    public LatinDictionary() : this(new LatinDictionarySettings(), CanonicalDataSource)
    {
    }
    
    private InflectionMaps InflectionMap { get; }
    private Inflection.Inflection[] Inflections { get; }

    private Prefix[] Prefixes { get; }
    private Suffix[] Suffixes { get; }
    private Tackon[] Tackons { get; }
    private Tackon[] Packons { get; }
    
    private ConcurrentDictionary<string, List<(InflectedForm form, Word? word)>> LatinLookup { get; }
    private ConcurrentDictionary<Suffix, ConcurrentDictionary<string, List<(InflectedForm form, Word? word)>>> LatinExtendedLookup { get; }

    private ConcurrentDictionary<string, List<Word>> EnglishLookup { get; } = new();

    private Word[] WordList { get; }
    private InflectedForm[] IrregularWords { get; }

    private (string, InflectedForm)[] EnglishIrregularLookup { get; }
    
    private readonly LatinDictionarySettings _settings;
}