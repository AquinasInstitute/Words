using Words.Flags;

namespace Words.Inflected;

public abstract record InflectedForm
{
    /// <summary>
    /// The composed/inflected form.
    /// </summary>
    public string Form { get; internal set; } = "";

    /// <summary>
    /// The stem upon which the form was built.
    /// This value is null for completely irregular forms.
    /// Note that for syncopated forms the composition of stem + ending does not equal the composed form.
    /// </summary>
    public string? Stem { get; internal init; } = null;

    /// <summary>
    /// The ending added to the stem to create the inflected form.
    /// This value is null for completely irregular forms.
    /// Note that for syncopated forms the composition of stem + ending does not equal the composed form.
    /// </summary>
    public string? Ending { get; internal init; } = null;

    public string Meaning { get; internal set; } = "";

    public PartOfSpeech PartOfSpeech { get; internal set; }

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