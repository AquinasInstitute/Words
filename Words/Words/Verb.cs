using Words.Flags;

namespace Words.Words;

public record Verb: WordInfo
{
    public int Conjugation { get; internal init; }
    public int ConjugationVariant { get; internal init; }
    public VerbKind VerbKind { get; internal init; }
}