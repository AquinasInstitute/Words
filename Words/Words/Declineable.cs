namespace Words.Words;

/// <summary>
/// A noun, pronoun, numeral, or adjective.
/// </summary>
public abstract record Declineable: WordInfo
{
    public int Declension { get; internal init; }
    public int DeclensionVariant { get; internal init; }
}