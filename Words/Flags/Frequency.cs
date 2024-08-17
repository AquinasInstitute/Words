namespace Words.Flags;

public enum Frequency
{
    /// <summary>
    /// Unknown or unspecified
    /// </summary>
    Unspecified,
    /// <summary>
    /// Very frequent, in all Elementary Latin books
    /// </summary>
    VeryFrequent,
    /// <summary>
    /// In the top 10 percent
    /// </summary>
    Frequent,
    /// <summary>
    /// In the top 10,000 words
    /// </summary>
    Common,
    /// <summary>
    /// In the top 20,000 words
    /// </summary>
    LessCommon,
    /// <summary>
    /// 2 or 3 citations
    /// </summary>
    Uncommon,
    /// <summary>
    /// Having only single citation in OLD or L+S
    /// </summary>
    VeryRare,
    /// <summary>
    /// Only citation is an inscription
    /// </summary>
    Inscription,
    /// <summary>
    /// Graffiti - Presently not much used
    /// </summary>
    Graffiti,
    /// <summary>
    /// Appearing (almost) only in Pliny Natural History
    /// </summary>
    Pliny
}