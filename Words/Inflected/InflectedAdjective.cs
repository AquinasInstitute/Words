using Words.Flags;

namespace Words.Inflected;

public record InflectedAdjective : InflectedDeclineable
{
    public Comparison Comparison { get; internal init; }
}