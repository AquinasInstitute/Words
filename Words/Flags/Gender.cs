namespace Words.Flags;

public enum Gender
{
    /// <summary>
    /// Used for words that are applicable to all genders, genderless, or whose gender is unknown.
    /// </summary>
    Unknown,
    Masculine,
    Feminine,
    Neuter,
    /// <summary>
    /// Masculine and/or feminine.
    /// </summary>
    Common
}