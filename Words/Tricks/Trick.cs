using Words.Flags;

namespace Words;

public record Trick(int Unknown, TrickKind Kind, string Before, string After)
{
    public int Unknown { get; internal set; } = Unknown;
    public TrickKind Kind { get; internal init; } = Kind;
    public string Before { get; } = Before;
    public string After { get; } = After;
}