using Words.Flags;

namespace Words.Inflection;

public record AdjectiveInflection : DeclineableInflection
{
    public Comparison Comparison { get; internal init; }
}