using Words.Flags;

namespace Words.Words;

public record Adjective: Declineable
{
    public Comparison Comparison { get; internal init; } = Comparison.Unknown;
}