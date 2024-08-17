using Words.Flags;

namespace Words.Tricks;

internal static class TrickTables
{
    public static readonly Trick[] AnyTricks =
    [
        new Trick(0, TrickKind.Replace, "ae", "e"),
        new Trick(0, TrickKind.Replace, "bul", "bol"),
        new Trick(0, TrickKind.Replace, "bol", "bul"),
        new Trick(0, TrickKind.Replace, "cl", "cul"),
        new Trick(0, TrickKind.Replace, "cu", "quu"),
        new Trick(0, TrickKind.Replace, "f", "ph"),
        new Trick(0, TrickKind.Replace, "ph", "f"),
        //Causes "interesting" results.
        //new Trick(0, TrickKind.Replace, "h", ""),
        new Trick(0, TrickKind.Replace, "oe", "e"),
        new Trick(0, TrickKind.Replace, "vul", "vol"),
        new Trick(0, TrickKind.Replace, "vol", "vul"),
        new Trick(0, TrickKind.Replace, "uol", "vul")
    ];

    public static readonly Trick[] Mediaeval_Tricks =
    [
        //  Harrington/Elliott    1.1.1
        new Trick(0, TrickKind.Replace, "col", "caul"),
        //  Harrington/Elliott    1.3
        new Trick(0, TrickKind.Replace, "e", "ae"),
        new Trick(0, TrickKind.Replace, "o", "u"),
        new Trick(0, TrickKind.Replace, "i", "y"),
        //  Harrington/Elliott    1.3.1
        new Trick(0, TrickKind.Replace, "ism", "sm"),
        new Trick(0, TrickKind.Replace, "isp", "sp"),
        new Trick(0, TrickKind.Replace, "ist", "st"),
        new Trick(0, TrickKind.Replace, "iz", "z"),
        new Trick(0, TrickKind.Replace, "esm", "sm"),
        new Trick(0, TrickKind.Replace, "esp", "sp"),
        new Trick(0, TrickKind.Replace, "est", "st"),
        new Trick(0, TrickKind.Replace, "ez", "z"),
        //  Harrington/Elliott    1.4
        new Trick(0, TrickKind.Replace, "di", "z"),
        new Trick(0, TrickKind.Replace, "f", "ph"),
        new Trick(0, TrickKind.Replace, "is", "ix"),
        new Trick(0, TrickKind.Replace, "b", "p"),
        new Trick(0, TrickKind.Replace, "d", "t"),
        new Trick(0, TrickKind.Replace, "v", "b"),
        new Trick(0, TrickKind.Replace, "v", "f"),
        new Trick(0, TrickKind.Replace, "v", "f"),
        new Trick(0, TrickKind.Replace, "s", "x"),
        //  Harrington/Elliott    1.4.1
        new Trick(0, TrickKind.Replace, "ci", "ti"),
        //  Harrington/Elliott    1.4.2
        new Trick(0, TrickKind.Replace, "nt", "nct"),
        new Trick(0, TrickKind.Replace, "s", "ns"),
        //  Others
        new Trick(0, TrickKind.Replace, "ch", "c"),
        new Trick(0, TrickKind.Replace, "c", "ch"),
        new Trick(0, TrickKind.Replace, "th", "t"),
        new Trick(0, TrickKind.Replace, "t", "th")
    ];

    public static readonly string[] Common_Prefixes = ["dis", "ex", "in", "per", "prae", "pro", "re", "si", "sub", "super", "trans"
    ];

    public static readonly Dictionary<char, Trick[]> TricksTable = new()
    {
        ['a'] =
        [
            new Trick(0, TrickKind.DoubleReplaceHead, "adgn", "agn"),
            new Trick(0, TrickKind.DoubleReplaceHead, "adsc", "asc"),
            new Trick(0, TrickKind.DoubleReplaceHead, "adsp", "asp"),
            new Trick(0, TrickKind.DoubleReplaceHead, "arqui", "arci"),
            new Trick(0, TrickKind.DoubleReplaceHead, "arqu", "arcu"),
            new Trick(0, TrickKind.ReplaceHead, "ae", "e"),
            new Trick(0, TrickKind.ReplaceHead, "al", "hal"),
            new Trick(0, TrickKind.ReplaceHead, "am", "ham"),
            new Trick(0, TrickKind.ReplaceHead, "ar", "har"),
            new Trick(0, TrickKind.ReplaceHead, "aur", "or")
        ],

        ['d'] =
        [
            new Trick(0, TrickKind.ReplaceHead, "dampn", "damn"),
            //  OLD p.54,
            new Trick(0, TrickKind.DoubleReplaceHead, "dij", "disj"),
            //  OLD p.55,
            new Trick(0, TrickKind.DoubleReplaceHead, "dir", "disr"),
            //  OLD p.54,
            new Trick(0, TrickKind.DoubleReplaceHead, "dir", "der"),
            //  OLD p.507/54,
            new Trick(0, TrickKind.DoubleReplaceHead, "del", "dil")
        ],

        ['e'] =
        [
            new Trick(0, TrickKind.DoubleReplaceHead, "ecf", "eff"),
            new Trick(0, TrickKind.DoubleReplaceHead, "ecs", "exs"),
            new Trick(0, TrickKind.DoubleReplaceHead, "es", "ess"),
            new Trick(0, TrickKind.DoubleReplaceHead, "ex", "exs"),
            new Trick(0, TrickKind.ReplaceHead, "eid", "id"),
            new Trick(0, TrickKind.ReplaceHead, "el", "hel"),
            new Trick(0, TrickKind.ReplaceHead, "e", "ae")
        ],

        ['f'] =
        [
            new Trick(0, TrickKind.DoubleReplaceHead, "faen", "fen"),
            new Trick(0, TrickKind.DoubleReplaceHead, "faen", "foen"),
            new Trick(0, TrickKind.DoubleReplaceHead, "fed", "foed"),
            new Trick(0, TrickKind.DoubleReplaceHead, "fet", "foet"),
            new Trick(0, TrickKind.ReplaceHead, "f", "ph")
        ], // Try lead then all

        ['g'] =
        [
            new Trick(0, TrickKind.ReplaceHead, "gna", "na")
        ],

        ['h'] =
        [
            new Trick(0, TrickKind.ReplaceHead, "har", "ar"),
            new Trick(0, TrickKind.ReplaceHead, "hal", "al"),
            new Trick(0, TrickKind.ReplaceHead, "ham", "am"),
            new Trick(0, TrickKind.ReplaceHead, "hel", "el"),
            new Trick(0, TrickKind.ReplaceHead, "hol", "ol"),
            new Trick(0, TrickKind.ReplaceHead, "hum", "um")
        ],

        ['k'] =
        [
            new Trick(0, TrickKind.ReplaceHead, "k", "c"),
            new Trick(0, TrickKind.ReplaceHead, "c", "k")
        ],

        ['l'] =
        [
            new Trick(1, TrickKind.DoubleReplaceHead, "lub", "lib")
        ],

        ['m'] =
        [
            new Trick(1, TrickKind.DoubleReplaceHead, "mani", "manu")
        ],

        ['n'] =
        [
            new Trick(0, TrickKind.ReplaceHead, "na", "gna"),
            new Trick(0, TrickKind.DoubleReplaceHead, "nihil", "nil")
        ],

        ['o'] =
        [
            new Trick(1, TrickKind.DoubleReplaceHead, "obt", "opt"),
            new Trick(1, TrickKind.DoubleReplaceHead, "obs", "ops"),
            new Trick(0, TrickKind.ReplaceHead, "ol", "hol"),
            new Trick(1, TrickKind.ReplaceHead, "opp", "op"),
            new Trick(0, TrickKind.ReplaceHead, "or", "aur")
        ],

        ['p'] =
        [
            new Trick(0, TrickKind.ReplaceHead, "ph", "f"),
            new Trick(1, TrickKind.DoubleReplaceHead, "pre", "prae")
        ],

        //  From Oxford Latin Dictionary p.1835 "sub-"
        ['s'] =
        [
            new Trick(0, TrickKind.DoubleReplaceHead, "subsc", "susc"),
            new Trick(0, TrickKind.DoubleReplaceHead, "subsp", "susp"),
            new Trick(0, TrickKind.DoubleReplaceHead, "subc", "susc"),
            new Trick(0, TrickKind.DoubleReplaceHead, "succ", "susc"),
            new Trick(0, TrickKind.DoubleReplaceHead, "subt", "supt"),
            new Trick(0, TrickKind.DoubleReplaceHead, "subt", "sust")
        ],

        ['t'] =
        [
            new Trick(0, TrickKind.DoubleReplaceHead, "transv", "trav")
        ],

        ['u'] =
        [
            new Trick(0, TrickKind.ReplaceHead, "ul", "hul"),
            new Trick(0, TrickKind.ReplaceHead, "uol", "vul")
            //  u is not v for this purpose
        ],

        ['y'] =
        [
            new Trick(0, TrickKind.ReplaceHead, "y", "i")
        ],

        ['z'] =
        [
            new Trick(0, TrickKind.ReplaceHead, "z", "di")
        ]
    };

    public static readonly Dictionary<char, Trick[]> SlursTable = new()
    {
        ['a'] =
        [
            new Trick(0, TrickKind.DoubleReplaceHead, "abs", "aps"),
            new Trick(0, TrickKind.DoubleReplaceHead, "acq", "adq"),
            new Trick(0, TrickKind.DoubleReplaceHead, "ante", "anti"),
            new Trick(0, TrickKind.DoubleReplaceHead, "auri", "aure"),
            new Trick(0, TrickKind.DoubleReplaceHead, "auri", "auru"),
            new Trick(0, TrickKind.Remove, "ad", "")
        ],

        ['c'] =
        [
            new Trick(0, TrickKind.ReplaceHead, "circum", "circun"),
            new Trick(0, TrickKind.DoubleReplaceHead, "con", "com"),
            new Trick(0, TrickKind.ReplaceHead, "co", "com"),
            new Trick(0, TrickKind.ReplaceHead, "co", "con"),
            new Trick(0, TrickKind.DoubleReplaceHead, "conl", "coll")
        ],
        
        // Reclassified from the any tricks table.
        ['h'] =
        [
            new Trick(0, TrickKind.Replace, "h", ""),
        ],

        ['i'] =
        [
            new Trick(1, TrickKind.Remove, "in", ""),
            new Trick(1, TrickKind.DoubleReplaceHead, "inb", "imb"),
            new Trick(1, TrickKind.DoubleReplaceHead, "inp", "imp")
            // for some forms of eo the stem "i" grates with
            // an "is .. ." ending
        ],

        ['n'] =
        [
            new Trick(0, TrickKind.ReplaceHead, "nun", "non")
        ],

        ['o'] =
        [
            new Trick(0, TrickKind.Remove, "ob", "")
        ],

        ['q'] =
        [
            new Trick(0, TrickKind.DoubleReplaceHead, "quadri", "quadru")
        ],

        ['s'] =
        [
            //  Latham,
            new Trick(0, TrickKind.ReplaceHead, "se", "ce"),
            //  From Oxford Latin Dictionary p.1835 "sub-"
            new Trick(0, TrickKind.Remove, "sub", "")
        ],
    };

    public static readonly Dictionary<char, string> VowelMap = new()
    {
        ['ā'] = "a", ['Ā'] = "A", ['ă'] = "a", ['á'] = "a",
        ['ē'] = "e", ['Ē'] = "E", ['ĕ'] = "e", ['ë'] = "e", ['é'] = "e",
        ['ī'] = "i", ['Ī'] = "I", ['ĭ'] = "i", ['ï'] = "i",
        ['ō'] = "o", ['Ō'] = "O", ['ŏ'] = "o", ['ö'] = "o",
        ['ū'] = "u", ['Ū'] = "U", ['ŭ'] = "u", ['ü'] = "u", ['ú'] = "u", ['ù'] = "u",
        ['ȳ'] = "y", ['ў'] = "y", ['ÿ'] = "y",
        ['^'] = "",
        ['œ'] = "oe", ['æ'] = "ae"
    };

    public static bool IsTrickRelevant(Trick trick, string text)
    {
        switch (trick.Kind)
        {
            case TrickKind.Replace:
                return text.Contains(trick.Before);
            case TrickKind.ReplaceHead:
                return text.StartsWith(trick.Before);
            case TrickKind.DoubleReplaceHead:
                
                if (text.StartsWith(trick.Before))
                {
                    text = string.Concat(trick.After, text.AsSpan(trick.Before.Length));
                }
                if (text.StartsWith(trick.After))
                {
                    text = string.Concat(trick.Before, text.AsSpan(trick.After.Length));
                }

                return text.StartsWith(trick.After);
            case TrickKind.Remove:
                return text.Contains(trick.Before);
            default:
                throw new ArgumentOutOfRangeException(nameof(trick), "Invalid trick kind found while attempting to check validity of trick.");
        }
    }
    public static string PerformTrick(Trick trick, string text)
    {
        switch (trick.Kind)
        {
            case TrickKind.Replace:
                return text.Replace(trick.Before, trick.After);
            
            case TrickKind.ReplaceHead:
                return text.StartsWith(trick.Before) ? string.Concat(trick.After, text.AsSpan(trick.Before.Length)) : text;
            case TrickKind.DoubleReplaceHead:
                if (text.StartsWith(trick.Before))
                {
                    text = string.Concat(trick.After, text.AsSpan(trick.Before.Length));
                }
                if (text.StartsWith(trick.After))
                {
                    text = string.Concat(trick.Before, text.AsSpan(trick.After.Length));
                }

                return text;
            case TrickKind.Remove:
                return text.Replace(trick.Before, trick.After);
            default:
                throw new ArgumentOutOfRangeException(nameof(trick.Kind), "Invalid trick kind found while attempting to perform trick.");
        }
    }
    
    // Syncopes
    
    private const string DropButDontContract = "Syncopated perfect ivi can drop 'v' without contracting the vowel";
    private const string DropAndContract = "Syncopated perfect often drops the 'v' and contracts the vowel";
    
    public static Syncope[] Syncopes =
    [
        new Syncope(DropButDontContract, "ii", "ivi"),
        
        new Syncope(DropAndContract, "avis", "as"),
        new Syncope(DropAndContract, "evis", "es"),
        new Syncope(DropAndContract, "ivis", "is"),
        new Syncope(DropAndContract, "ovis", "os"),
        
        new Syncope(DropAndContract, "aver", "ar"),
        new Syncope(DropAndContract, "ever", "er"),
        
        new Syncope(DropAndContract, "iver", "ier"),
        
        new Syncope("Syncopated perfect sometimes drops the 'is' after 's' or 'x'", "sis", "s"),
        new Syncope("Syncopated perfect sometimes drops the 'is' after 's' or 'x'", "xis", "x")
    ];
}