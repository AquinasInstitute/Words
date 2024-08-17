namespace Words.Flags;

public enum NounKind
{
    /// <summary>
    /// Unknown or nondescript
    /// </summary>
    Unknown,
    SingularOnly,
    PluralOnly,
    AbstractIdea,
    /// <summary>
    /// The name of a group or collective.
    /// </summary>
    CollectiveName,
    ProperName,
    Person,
    Thing,
    /// <summary>
    /// The name of a locale, that is a country or a city.
    /// </summary>
    Locale,
    Place
}