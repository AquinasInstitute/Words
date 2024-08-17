namespace Words.Tests.Dictionary.Lookup.Gauntlet;

public class GauntletD
{
    [Test]
    public void LookupA() => CheckWord("vestigia", """
    [Noun]  vestigi.us vestigi. : step, track; trace; footstep;
        vestigi.a - (2, 4) [Plural Nominative Neuter]
        vestigi.a - (2, 4) [Plural Vocative Neuter]
        vestigi.a - (2, 4) [Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupB() => CheckWord("flammae", """
    [Noun]  flamm.a flamm.ae : flame, blaze; ardor, fire of love; object of love;
        flamm.ae - (1, 1) [Singular Genitive Common]
        flamm.ae - (1, 1) [Singular Locative Common]
        flamm.ae - (1, 1) [Singular Dative Common]
        flamm.ae - (1, 1) [Plural Nominative Common]
        flamm.ae - (1, 1) [Plural Vocative Common]
    """);
    
    [Test]
    public void LookupC() => CheckNotFound("erebi");
    
    [Test]
    public void LookupD() => CheckWord("ait", """
    [Verb] [Impersonal] ai.o - - - : he says (ait), it is said; they say (aiunt);
        a.it - (7, 1) [Present Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupE() => CheckWord("ocius", """
    [Adjective]  oci.or oci.or oci.us : swifter, more speedy/rapid; sooner, prompter; appearing/occurring earlier;
        oci.us - (0, 0) [Comparative Singular Nominative Neuter]
        oci.us - (0, 0) [Comparative Singular Accusative Neuter]
        oci.us - (0, 0) [Comparative Singular Vocative Neuter]
    """);
    
    [Test]
    public void LookupF() => CheckWord("verum", """
    [Adjective]  ver.us veri.or verissi.mus : true, real, genuine, actual; properly named; well founded; right, fair, proper;
        ver.um - (1, 1) [Positive Singular Nominative Neuter]
        ver.um - (1, 1) [Positive Singular Accusative Neuter]
        ver.um - (1, 1) [Positive Singular Vocative Neuter]
        ver.um - (1, 1) [Positive Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupG() => CheckWord("dextra", """
    [Adjective]  dexter. dexteri.or dexti.mus : right, on/to the right hand/side; skillful/dexterous/handy; favorable/fortunate/pretentious; opportune (L+S); proper/fitting/suitable;
        dextr.a - (1, 2) [Positive Singular Ablative Feminine]
        dextr.a - (1, 2) [Positive Plural Nominative Neuter]
        dextr.a - (1, 2) [Positive Plural Accusative Neuter]
        dextr.a - (1, 2) [Positive Plural Vocative Neuter]
    """);
    
    [Test]
    public void LookupH() => CheckWord("una", """
    [Adjective]  un.us un.a un.um : alone, a single/sole; some, some one; only (pl.); one set of (denoting entity);
        un.a - (1, 3) [Positive Singular Nominative Feminine]
        un.a - (1, 3) [Positive Singular Ablative Feminine]
        un.a - (1, 3) [Positive Singular Vocative Feminine]
        un.a - (1, 3) [Positive Plural Nominative Neuter]
        un.a - (1, 3) [Positive Plural Accusative Neuter]
        un.a - (1, 3) [Positive Plural Vocative Neuter]
    """);
    
    [Test]
    public void LookupI() => CheckWord("alia", """
    [Adjective]  ali.us ali.a ali.ud : other, another; different, changed; [alii...alii => some...others]; (A+G);
        ali.a - (1, 5) [Positive Singular Nominative Feminine]
        ali.a - (1, 5) [Positive Singular Ablative Feminine]
        ali.a - (1, 5) [Positive Singular Vocative Feminine]
        ali.a - (1, 5) [Positive Plural Nominative Neuter]
        ali.a - (1, 5) [Positive Plural Accusative Neuter]
        ali.a - (1, 5) [Positive Plural Vocative Neuter]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("egentem", """
    [Adjective]  egens. egens. egens. : needy, poor, in want of; very poor, destitute (of);
        egent.em - (3, 1) [Positive Singular Accusative Common]
    """);
    
    [Test]
    public void LookupK() => CheckWord("ocius", """
    [Adjective]  oc.is oci.or ocissi.mus : swift/rapid, at speed; (COMP) arriving/appearing/occurring earlier/sooner;
        oci.us - (3, 2) [Comparative Singular Nominative Neuter]
        oci.us - (3, 2) [Comparative Singular Accusative Neuter]
        oci.us - (3, 2) [Comparative Singular Vocative Neuter]
    """);
    
    [Test]
    public void LookupL() => CheckWord("celeris", """
    [Adjective]  celer. celeri.or celerri.mus : swift, quick, agile, rapid, speedy, fast; rash, hasty, hurried; lively; early;
        celer.is - (3, 3) [Positive Singular Nominative Feminine]
        celer.is - (3, 3) [Positive Singular Vocative Feminine]
        celer.is - (3, 3) [Positive Singular Genitive Unknown]
        celer.is - (3, 3) [Positive Plural Accusative Common]
    """);
    
    [Test]
    public void LookupM() => CheckWord("quot", """
    [Adjective]  - - - : how many; of what number; as many;
        quot. - (9, 9) [Unknown Unknown Unknown Unknown]
    """);
    
    [Test]
    public void LookupN() => CheckWord("verum", """
    [Adverb]  verum : yes; in truth; certainly; truly, to be sure; however;   (rare form, usu. vero);
        verum [Positive]
    """);
    
    [Test]
    public void LookupO() => CheckWord("alii", """
    [Conjunction]  alii : some ... others (alii ... alii);
        alii
    """);
    
    [Test]
    public void LookupP() => CheckWord("o", """
    [Interjection]  o : Oh!;
        o
    """);
    
    [Test]
    public void LookupQ() => CheckWord("africa", """
    [Noun]  afric.a afric.ae : Africa (North); (Roman province); Libya (Carthagenian); the continent;
        afric.a - (1, 1) [Singular Nominative Common]
        afric.a - (1, 1) [Singular Vocative Common]
        afric.a - (1, 1) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupR() => CheckWord("comas", """
    [Noun]  com.e com.es : one or more plants of genus Tragopogon, goat's beard or salsify;
        com.as - (1, 6) [Plural Accusative Common]
    """);
    
    [Test]
    public void LookupS() => CheckWord("orestes", """
    [Noun]  orest.es orest.ae : Orestes; son of Agamennon and Clytaemnestra; play by Euripides; book by Varro;
        orest.es - (1, 7) [Singular Nominative Common]
    """);
    
    [Test]
    public void LookupT() => CheckWord("orestes", """
    [Noun]  orestes. orest.is : Orestes; son of Agamennon and Clytaemnestra; play by Euripides; book by Varro;
        orest.es - (3, 3) [Plural Accusative Common]
        orestes. - (3, 3) [Singular Nominative Unknown]
        orestes. - (3, 3) [Singular Vocative Unknown]
        orest.es - (3, 3) [Plural Nominative Common]
        orest.es - (3, 3) [Plural Vocative Common]
    """);
    
    [Test]
    public void LookupU() => CheckWord("boreae", """
    [Noun]  bore.as bore.ae : north wind; the_North; Boreas (god of the north wind);
        bore.ae - (1, 8) [Singular Genitive Common]
        bore.ae - (1, 8) [Singular Locative Common]
        bore.ae - (1, 8) [Singular Dative Common]
        bore.ae - (1, 8) [Plural Nominative Common]
        bore.ae - (1, 8) [Plural Vocative Common]
    """);
    
    [Test]
    public void LookupV() => CheckWord("verum", """
    [Noun]  ver.us ver.i : Verus; (Emperor Lucius Verus 161-169);
        ver.um - (2, 1) [Singular Accusative Common]
        ver.um - (2, 1) [Plural Genitive Unknown]
    """);
    
    [Test]
    public void LookupW() => CheckWord("verum", """
    [Noun]  ver.um ver.i : truth, reality, fact;
        ver.um - (2, 2) [Singular Nominative Neuter]
        ver.um - (2, 2) [Singular Vocative Neuter]
        ver.um - (2, 2) [Singular Accusative Neuter]
        ver.um - (2, 2) [Singular Accusative Common]
        ver.um - (2, 2) [Plural Genitive Unknown]
    """);
    
    [Test]
    public void LookupX() => CheckWord("nostri", """
    [Noun]  noster. nostr.i : our men (pl.);
        nostr.i - (2, 3) [Singular Genitive Unknown]
        nostr.i - (2, 3) [Singular Locative Unknown]
        nostr.i - (2, 3) [Plural Nominative Common]
        nostr.i - (2, 3) [Plural Vocative Common]
    """);
    
    [Test]
    public void LookupY() => CheckWord("conjugium", """
    [Noun]  conjugi.us conjugi. : marriage/wedlock; husband/wife; couple; mating (animal), pair; close connection;
        conjugi.um - (2, 4) [Singular Nominative Neuter]
        conjugi.um - (2, 4) [Singular Vocative Neuter]
        conjugi.um - (2, 4) [Singular Accusative Unknown]
        conjugi.um - (2, 4) [Singular Accusative Common]
        conjugi.um - (2, 4) [Plural Genitive Unknown]
    """);
    
    [Test]
    public void LookupZ() => CheckWord("iuli", """
    [Noun]  juli.us juli. : Julius; (Roman gens name); (C. ~ Caesar 102-44 BC);
        juli. - (2, 5) [Singular Vocative Masculine]
        juli. - (2, 5) [Singular Genitive Masculine]
    """);
}