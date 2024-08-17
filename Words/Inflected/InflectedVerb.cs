using Words.Flags;
using Words.Tricks;

namespace Words.Inflected;

public record InflectedVerb: InflectedForm
{
    public int Conjugation { get; internal init; }
    public int ConjugationVariant { get; internal init; }

    public Tense Tense { get; internal init; }
    public Voice Voice { get; internal init; }
    public Mood Mood { get; internal init; }

    public Person Person { get; internal init; }
    public Number Number { get; internal init; }

    public VerbKind Kind { get; internal init; }

    public (InflectedVerb priorForm, Syncope syncope)? Syncope { get; internal init; }
}