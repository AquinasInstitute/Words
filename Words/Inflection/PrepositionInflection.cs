using Words.Flags;

namespace Words.Inflection;

public record PrepositionInflection: Inflection
{
    public PrepositionCase Case { get; internal set; } = PrepositionCase.Unknown;
}