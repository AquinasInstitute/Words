using Words.Flags;

namespace Words.Addons;

public record Addon
{
    public PartOfSpeech From { get; internal set; } = PartOfSpeech.Unknown;
    public PartOfSpeech To { get; internal set; } = PartOfSpeech.Unknown;
    
    public AddonKind Kind { get; internal set; } = AddonKind.Prefix;
    public string Word { get; internal set; } = "";
    public char? ConnectingCharacter { get; internal set; }

    public string Meaning { get; internal set; } = "";
}