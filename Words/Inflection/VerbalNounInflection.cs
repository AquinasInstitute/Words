using Words.Flags;

namespace Words.Inflection;

public record VerbalNounInflection: VerbInflection
{
    public Case Case { get; internal init; }
    public Gender Gender { get; internal init; }
}