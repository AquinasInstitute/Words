using Words.Flags;

namespace Words.Inflection;

public record AdverbInflection : Inflection
{
    public Comparison Comparison { get; internal set; }
}