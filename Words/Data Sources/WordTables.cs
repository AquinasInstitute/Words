using System.Collections.Concurrent;
using Words.Addons;
using Words.Inflected;
using Words.Words;

namespace Words.Data_Sources;

public record WordTables
{
    public ConcurrentDictionary<string, List<(InflectedForm form, Word? word)>> LookupTable { get; init; } = new();
    public ConcurrentDictionary<Suffix, ConcurrentDictionary<string, List<(InflectedForm form, Word? word)>>> ExtendedLookupTable { get; init; } = new();
    public Word[] WordList { get; init; } = Array.Empty<Word>();
    public InflectedForm[] IrregularWords { get; init; } = Array.Empty<InflectedForm>();
    public (string, InflectedForm)[] EnglishIrregularLookup { get; init; } = Array.Empty<(string, InflectedForm)>();
}