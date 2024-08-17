using Words.Flags;

namespace Words.Inflected;

public record InflectedParticiple: InflectedAdjective
{
    public Tense Tense { get; internal init; }
    public Voice Voice { get; internal init; }
    public Mood Mood { get; internal init; }
}