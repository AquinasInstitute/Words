using Words.Flags;

namespace Words.Inflected;

public record InflectedPreposition: InflectedForm
{
    public PrepositionCase Case { get; internal init; } = PrepositionCase.Unknown;
}