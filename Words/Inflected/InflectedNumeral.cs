using Words.Flags;

namespace Words.Inflected;

public record InflectedNumeral : InflectedNoun
{
    public NumeralSorting Sorting { get; internal init; } = NumeralSorting.Unknown;
    public int Value { get; internal init; }
}