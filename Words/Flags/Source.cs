namespace Words.Flags;

public enum Source
{
    /// <summary>
    /// General or unknown or too common to say
    /// </summary>
    Unknown,
    /// <summary>
    /// C.H.Beeson, A Primer of Medieval Latin, 1925 (Bee)
    /// </summary>
    APrimerOfMedievalLatin,
    /// <summary>
    /// Charles Beard, Cassell's Latin Dictionary 1892 (Cas)
    /// </summary>
    CassellsLatinDictionary,
    /// <summary>
    /// J.N.Adams, Latin Sexual Vocabulary, 1982 (Sex)
    /// </summary>
    LatinSexualVocabulary,
    /// <summary>
    /// L.F.Stelten, Dictionary of Eccles. Latin, 1995 (Ecc)
    /// </summary>
    DictionaryOfEccles,
    /// <summary>
    /// Roy J. Deferrari, Dictionary of St. Thomas Aquinas, 1960 (DeF)
    /// </summary>
    DictionaryOfStThomasAquinas,
    /// <summary>
    /// Gildersleeve + Lodge, Latin Grammar 1895 (G+L)
    /// </summary>
    LatinGrammar1895,
    /// <summary>
    /// Collatinus Dictionary by Yves Ouvrard
    /// </summary>
    CollatinusDictionary,
    /// <summary>
    /// Leverett, F.P., Lexicon of the Latin Language, Boston 1845
    /// </summary>
    LexiconOfTheLatinLanguage,
    /// <summary>
    /// Bracton: De Legibus Et Consuetudinibus Angliæ
    /// </summary>
    DeLegibusEtConsuetudinibusAngliae,
    /// <summary>
    /// Calepinus Novus, modern Latin, by Guy Licoppe (Cal)
    /// </summary>
    CalephinusNovus,
    /// <summary>
    /// Lewis, C.S., Elementary Latin Dictionary 1891
    /// </summary>
    ElementaryLatuinDictionary,
    /// <summary>
    /// Latham, Revised Medieval Word List, 1980 (Latham)
    /// </summary>
    RevisedMedievalWordList,
    /// <summary>
    /// Lynn Nelson, Wordlist (Nel)
    /// </summary>
    Wordlist,
    /// <summary>
    /// Oxford Latin Dictionary, 1982 (OLD)
    /// </summary>
    OxfordLatinDictionary,
    /// <summary>
    /// Souter, A Glossary of Later Latin to 600 A.D., Oxford 1949 (Souter)
    /// </summary>
    AGlossaryOfLaterLatinTo600AD,
    /// <summary>
    /// Other, cited or unspecified dictionaries
    /// </summary>
    Unspecified,
    /// <summary>
    /// Plater + White, A Grammar of the Vulgate, Oxford 1926 (Plater)
    /// </summary>
    AGrammarOfTheVulgate,
    /// <summary>
    /// Lewis and Short, A Latin Dictionary, 1879 (L+S)
    /// </summary>
    ALatinDictionary1879,
    /// <summary>
    /// Found in a translation - no dictionary reference
    /// </summary>
    FoundInTranslation,
    /// <summary>
    /// Vademecum in opus Saxonis - Franz Blatt (Saxo)
    /// </summary>
    VademecumInOpusSaxonis,
    /// <summary>
    /// My personal guess, mostly obvious extrapolation (Whitaker or W)
    /// </summary>
    PersonalGuess,
    /// <summary>
    /// The meaning of this flag is unclear in the original Whitakers program.
    /// It is nevertheless preserved as it is used for a few words in the dictionary.
    /// </summary>
    Temporary,
    /// <summary>
    /// Sent by user - no dictionary reference, mostly John White of Blitz Latin
    /// </summary>
    SentByUser
}