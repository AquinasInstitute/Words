using Words.Flags;

namespace Words.Inflection;

public abstract record Inflection
{
    public PartOfSpeech PartOfSpeech { get; internal set; }

    /// <summary>
    /// The meaning of this value is unclear.
    /// </summary>
    public int StemType { get; internal set; }

    public string Ending { get; internal set; } = "";

    public Age Age { get; internal set; }
    public Frequency Frequency { get; internal set; }
}