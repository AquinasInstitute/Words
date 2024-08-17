using Words.Flags;

namespace Words.Inflected;

public record InflectedPronoun : InflectedNoun
{
    public PronounKind PronounKind { get; internal init; }
}