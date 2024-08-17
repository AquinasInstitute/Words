namespace Words.Words;

public record Packon: Pronoun
{
    /// <summary>
    /// The tackon (suffix added after inflection) that applies to this meaning.
    /// </summary>
    public string Tackon { get; internal set; } = "";
}