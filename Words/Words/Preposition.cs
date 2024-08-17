using Words.Flags;

namespace Words.Words;

public record Preposition: WordInfo
{
    public PrepositionCase Case { get; internal init; } = PrepositionCase.Unknown;
}