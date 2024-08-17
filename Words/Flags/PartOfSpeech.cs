namespace Words.Flags;

public enum PartOfSpeech
{
    Unknown = 0,
    Noun = 1,
    Pronoun = 2,
    /// <summary>
    /// A specific kind of pronoun. The meaning is not entirely clear, but Whitaker uses it, so so do we.
    /// </summary>
    Packon = 3,
    Adjective = 4,
    Numeral = 5,
    Adverb = 6,
    Verb = 7,
    VerbParticiple = 8,
    Supine = 9,
    Preposition = 10,
    Conjunction = 11,
    Interjection = 12
}