using Words.Flags;

namespace Words.Inflection;

public record VerbInflection: Inflection
{
    public int Conjugation { get; internal init; }
    public int ConjugationVariant { get; internal init; }

    public Tense Tense { get; internal init; }
    public Voice Voice { get; internal init; }
    public Mood Mood { get; internal init; }

    public Person Person { get; internal init; }
    public Number Number { get; internal init; }
}