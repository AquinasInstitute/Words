using Words.Flags;

namespace Words.Words;

public record Numeral: Declineable
{
    public NumeralSorting Sorting { get; internal init; } = NumeralSorting.Unknown;
    public int Value { get; internal init; } = 0;
}