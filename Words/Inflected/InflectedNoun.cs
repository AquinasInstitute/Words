using Words.Flags;

namespace Words.Inflected;

public record InflectedNoun: InflectedDeclineable
{
    public NounKind Kind { get; internal set; }
}