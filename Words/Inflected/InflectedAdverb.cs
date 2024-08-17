using Words.Flags;

namespace Words.Inflected;

public record InflectedAdverb: InflectedForm
{
    public Comparison Comparison { get; internal init; } = Comparison.Unknown;
}