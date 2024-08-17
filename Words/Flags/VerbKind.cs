namespace Words.Flags;

public enum VerbKind
{
    /// <summary>
    /// All, none, or unknown.
    /// </summary>
    Unknown,
    /// <summary>
    /// Only the verb TO BE (esse)
    /// </summary>
    ToBe,
    /// <summary>
    /// Compounds of the verb to be (esse)
    /// </summary>
    ToBeing,
    TakesGenitive,
    TakesDative,
    TakesAblative,
    Transitive,
    Intransitive,
    Impersonal,
    Deponent,
    SemiDeponent,
    PerfectDefinitive
}