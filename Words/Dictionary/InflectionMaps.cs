using System.Collections.Concurrent;
using Words.Inflection;

namespace Words;

public record InflectionMaps
{
    public ConcurrentDictionary<int, ConcurrentDictionary<int, List<NounInflection>>> NounInflections { get; } = new();
    public ConcurrentDictionary<int, ConcurrentDictionary<int, List<VerbInflection>>> VerbInflections { get; } = new();
    public ConcurrentDictionary<int, ConcurrentDictionary<int, List<AdjectiveInflection>>> AdjectiveInflections { get; } = new();
    public ConcurrentDictionary<int, ConcurrentDictionary<int, List<NumeralInflection>>> NumeralInflections { get; } = new();
    public ConcurrentDictionary<int, ConcurrentDictionary<int, List<PronounInflection>>> PronounInflections { get; } = new();
    public ConcurrentDictionary<int, ConcurrentDictionary<int, List<SupineInflection>>> SupineInflections { get; } = new();
    public ConcurrentDictionary<int, ConcurrentDictionary<int, List<VerbalNounInflection>>>VerbParticipleInflections { get; } = new();
}