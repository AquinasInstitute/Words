using Words.Flags;

namespace Words.Words;

public record Pronoun: Declineable
{
    public PronounKind Kind { get; internal init; } = PronounKind.Unknown;

    /// <summary>
    /// A tackon that must always be added to this pronoun.
    /// Only used if idem, eadem, idem.
    /// </summary>
    public string? MandatoryTackon = null; 
}