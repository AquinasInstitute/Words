namespace Words;

public record LatinDictionarySettings
{
    /// <summary>
    /// Whether or not to skip more unlikely inflection candidates.
    /// This can only be changed at startup.
    /// </summary>
    public bool SkipUnlikelyInflections { get; init; }
    /// <summary>
    /// If true, load alternative forms created by addons into their own lookup table to avoid the potentially costly overhead for such searches.
    /// This can only be changed at startup.
    /// </summary>
    public bool UseExtendedLookupTable { get; init; }

    /// <summary>
    /// If true, when a new word is seen, it's inflections will be added to the inflection cache.
    /// This only occurs when not finding a word with a suffix that changes the part of speech when UseExtendedLookupTable is false.
    /// This value is false by default as it can mean memory usage slowly creeps up as such words are found and cached.
    /// </summary>
    public bool DynamicallyExpandInflectionCache { get; set; } = false;
    
    /// <summary>
    /// When doing lookup, if no hits are found, also check the version replacing i with j, u with v, and so on.
    /// This value can be changed at any time.
    /// </summary>
    public bool DoBasicTricks { get; set; } = true;
    /// <summary>
    /// Performs generic tricks to widen the search.
    /// This value can be changed at any time.
    /// </summary>
    public bool DoGenericTricks { get; set; } = true;
    /// <summary>
    /// Performs tricks mostly helpful when dealing with medieval texts.
    /// This value can be changed at any time.
    /// </summary>
    public bool DoMedievalTricks { get; set; } = false;
    /// <summary>
    /// Perform "tricks" that ignore potentially meaningful parts of words to widen the search and potentially find the underlying root word instead.
    /// This value can be changed at any time.
    /// </summary>
    public bool DoSlurTricks { get; set; } = false;
}