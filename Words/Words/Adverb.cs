using Words.Flags;

namespace Words.Words;

public record Adverb: WordInfo
{
    public Comparison Comparison { get; internal init; } = Comparison.Unknown;
}