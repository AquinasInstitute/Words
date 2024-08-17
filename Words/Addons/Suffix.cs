using Words.Words;

namespace Words.Addons;

public record Suffix: Addon
{
    public int Unknown1 { get; internal init; }
    public int Unknown2 { get; internal set; }

    public WordInfo Result { get; internal set; } = WordInfo.Null;
}