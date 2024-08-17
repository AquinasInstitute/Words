namespace Words.Flags;

public enum Age
{
    /// <summary>
    /// In use throughout the ages/unknown -- the default
    /// </summary>
    Unknown,
    /// <summary>
    /// Very early forms, obsolete by classical times
    /// </summary>
    VeryEarly,
    /// <summary>
    /// Early Latin, pre-classical, used for effect/poetry
    /// </summary>
    Early,
    /// <summary>
    /// Limited to classical (~150 BC - 200 AD)
    /// </summary>
    Classical,
    /// <summary>
    /// Late, post-classical (3rd-5th centuries)
    /// </summary>
    LateOrPostClassical,
    /// <summary>
    /// Latin not in use in Classical times (6-10)
    /// </summary>
    PostClassical,
    /// <summary>
    /// Medieval (11th-15th centuries)
    /// </summary>
    Medieval,
    /// <summary>
    /// Latin post 15th - Scholarly/Scientific   (16-18)
    /// </summary>
    Scientific,
    /// <summary>
    /// Coined recently, words for new things (19-20)
    /// </summary>
    Modern
}