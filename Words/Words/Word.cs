using Words.Flags;

namespace Words.Words;

public record Word
{
    /// <summary>
    /// The stem for the present, active, indicative.
    /// </summary>
    public string? StemA { get; internal init; } = "";
    /// <summary>
    /// The infinitive stem.
    /// </summary>
    public string? StemB { get; internal set; } = "";
    /// <summary>
    /// The perfect stem.
    /// </summary>
    public string? StemC { get; internal init; } = "";
    /// <summary>
    /// The stem of the past participle.
    /// </summary>
    public string? StemD { get; internal init; } = "";

    /// <summary>
    /// The information that is specific to nouns, adjectives, verbs, or whatever kind of word is being represented.
    /// </summary>
    public WordInfo Info = WordInfo.Null;

    /// <summary>
    /// The translation of the word.
    /// </summary>
    public string Meaning { get; internal set; } = "";
    
    public PartOfSpeech PartOfSpeech;
    
    /// <summary>
    /// The time period during which a word was first introduced.
    /// </summary>
    public Age Age { get; internal set; } = Age.Unknown;
    /// <summary>
    /// The subject area the word is from (agriculture, music, mythology, etc.)
    /// </summary>
    public Subject Subject { get; internal set; } = Subject.None;
    /// <summary>
    /// The geographical origin of a word, that is, the place where it originated.
    /// </summary>
    public GeographicalSource GeographicalSource { get; internal set; } = GeographicalSource.None;
    /// <summary>
    /// How common or frequent the usage of a word is.
    /// </summary>
    public Frequency Frequency { get; internal set; } = Frequency.Unspecified;
    /// <summary>
    /// The textual source of a word.
    /// </summary>
    public Source Source { get; internal set; } = Source.Unknown;
}