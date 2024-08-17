using Words.Flags;

namespace Words.Inflection;

public record NumeralInflection : DeclineableInflection
{
    public NumeralSorting Sort { get; internal init; }
}