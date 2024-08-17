using Words.Flags;

namespace Words.Words;

public record Noun: Declineable
{
    public Gender Gender { get; internal init; }
    /// <summary>
    /// The kind of thing the noun represents.
    /// </summary>
    public NounKind Kind { get; internal init; }
}