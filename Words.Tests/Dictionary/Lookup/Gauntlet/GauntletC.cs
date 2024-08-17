namespace Words.Tests.Dictionary.Lookup.Gauntlet;

public class GauntletC
{
    [Test]
    public void LookupA() => CheckWord("post", """
    [Adverb]  post : behind, afterwards, after;
        post [Positive]
    """);
    
    [Test]
    public void LookupB() => CheckWord("post", """
    [Preposition]  post : behind (space), after (time); subordinate to (rank);
        post
    """);
    
    [Test]
    public void LookupC() => CheckWord("fata", """
    [Verb] [Deponent] f.or f.ari - fat.us : speak, talk; say;
        [Participle] fat.a - (0, 0) [Perfect Passive Nominative Feminine]
        [Participle] fat.a - (0, 0) [Perfect Passive Ablative Feminine]
        [Participle] fat.a - (0, 0) [Perfect Passive Vocative Feminine]
        [Participle] fat.a - (0, 0) [Perfect Passive Nominative Neuter]
        [Participle] fat.a - (0, 0) [Perfect Passive Accusative Neuter]
        [Participle] fat.a - (0, 0) [Perfect Passive Vocative Neuter]
    """);
    
    [Test]
    public void LookupD() => CheckWord("fata", """
    [Noun]  fat.um fat.i : utterance, oracle; fate, destiny; natural term of life; doom, death, calamity;
        fat.a - (2, 2) [Plural Nominative Neuter]
        fat.a - (2, 2) [Plural Vocative Neuter]
    """);
    
    [Test]
    public void LookupE() => CheckNotFound("sychaei");
    
    [Test]
    public void LookupF() => CheckWord("conjugis", """
    [Noun]  conjug.a conjug.ae : wife; spouse; consort (L+S);
        conjug.is - (1, 1) [Plural Locative Common]
        conjug.is - (1, 1) [Plural Dative Common]
        conjug.is - (1, 1) [Plural Ablative Common]
    """);
    
    [Test]
    public void LookupG() => CheckWord("conjugis", """
    [Noun]  conjunx. conjug.is : spouse/mate/consort; husband/wife/bride/fiancee/intended; concubine; yokemate;
        conjug.is - (3, 1) [Plural Accusative Common]
        conjug.is - (3, 1) [Singular Genitive Unknown]
    """);
    
    [Test]
    public void LookupH() => CheckWord("conjugis", """
    [Adjective]  conjunx. conjunx. conjunx. : yoked together; paired; linked as a pair;
        conjug.is - (3, 1) [Positive Singular Genitive Unknown]
        conjug.is - (3, 1) [Positive Plural Accusative Common]
    """);
    
    [Test]
    public void LookupI() => CheckWord("sparsos", """
    [Verb] [Unknown] sparg.o sparg.ere spars.i spars.us : scatter, strew, sprinkle; spot;
        [Participle] spars.os - (0, 0) [Perfect Passive Accusative Masculine]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("fraterna", """
    [Adjective]  fratern.us fratern.a fratern.um : brotherly/brother's; of/belonging to a brother; fraternal; friendly; of cousin;
        fratern.a - (1, 1) [Positive Singular Nominative Feminine]
        fratern.a - (1, 1) [Positive Singular Ablative Feminine]
        fratern.a - (1, 1) [Positive Singular Vocative Feminine]
        fratern.a - (1, 1) [Positive Plural Nominative Neuter]
        fratern.a - (1, 1) [Positive Plural Accusative Neuter]
        fratern.a - (1, 1) [Positive Plural Vocative Neuter]
    """);
    
    [Test]
    public void LookupK() => CheckWord("caede", """
    [Verb] [Transitive] caed.o caed.ere caecid.i caes.us : chop, hew, cut out/down/to pieces; strike, smite, murder; slaughter; sodomize;
        caed.e - (3, 1) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupL() => CheckWord("caede", """
    [Verb] [Transitive] caed.o caed.ere cecid.i caes.us : chop, hew, cut out/down/to pieces; strike, smite, murder; slaughter; sodomize;
        caed.e - (3, 1) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupM() => CheckWord("caede", """
    [Noun]  caedes. caed.is : murder/slaughter/massacre; assassination; feuding; slain/victims; blood/gore;
        caed.e - (3, 3) [Singular Locative Unknown]
        caed.e - (3, 3) [Singular Dative Unknown]
        caed.e - (3, 3) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupN() => CheckWord("caede", """
    [Noun]  caedis. caed.is : murder/slaughter/massacre; assassination; feuding; slain/victims; blood/gore;
        caed.e - (3, 3) [Singular Locative Unknown]
        caed.e - (3, 3) [Singular Dative Unknown]
        caed.e - (3, 3) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupO() => CheckWord("penatis", """
    [Noun]  penas. penat.is : Penates; (usu. pl.); gods of home/larder/family; home/dwelling; family/line;
        penat.is - (3, 1) [Plural Accusative Common]
        penat.is - (3, 1) [Singular Genitive Unknown]
    """);
    
    [Test]
    public void LookupP() => CheckWord("solus", """
    [Adjective]  sol.us sol.a sol.um : only, single; lonely; alone, having no companion/friend/protector; unique;
        sol.us - (1, 3) [Positive Singular Nominative Masculine]
        sol.us - (1, 3) [Positive Singular Vocative Masculine]
    """);
    
    [Test]
    public void LookupQ() => CheckWord("inflexit", """
    [Verb] [Unknown] inflect.o inflect.ere inflex.i inflex.us : bend; curve; change;
        inflex.it - (3, 1) [Perfect Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupR() => CheckWord("sensus", """
    [Noun]  sens.us sens.us : feeling, sense;
        sens.us - (4, 1) [Singular Nominative Common]
        sens.us - (4, 1) [Singular Vocative Common]
        sens.us - (4, 1) [Singular Genitive Common]
        sens.us - (4, 1) [Plural Nominative Common]
        sens.us - (4, 1) [Plural Vocative Common]
        sens.us - (4, 1) [Plural Accusative Common]
    """);
    
    [Test]
    public void LookupS() => CheckWord("sensus", """
    [Verb] [Unknown] senti.o sent.ire sens.i sens.us : perceive, feel, experience; think, realize, see, understand;
        [Participle] sens.us - (0, 0) [Perfect Passive Nominative Masculine]
    """);
    
    [Test]
    public void LookupT() => CheckWord("labantem", """
    [Verb] [Unknown] lab.o lab.are labav.i labat.us : totter, be ready to fall; begin to sink; give way; waver, decline, sink; err;
        [Participle] lab.antem - (1, 0) [Present Active Accusative Common]
    """);
    
    [Test]
    public void LookupU() => CheckWord("impulit", """
    [Verb] [Transitive] impell.o impell.ere impul.i impuls.us : drive/persuade/impel; urge on/action; push/thrust/strike against; overthrow;
        impul.it - (3, 1) [Perfect Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupV() => CheckWord("adgnosco", """
    [Verb] [Unknown] adgnosc.o adgnosc.ere adgnov.i adgnit.us : recognize, realize, discern; acknowledge, claim, admit to/responsibility;
        adgnosc.o - (3, 1) [Present Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupW() => CheckWord("veteris", """
    [Verb] [Transitive] vet.o vet.are vetav.i vetat.us : forbid, prohibit; reject, veto; be an obstacle to; prevent;
        vet.eris - (1, 1) [Present Passive Subjunctive Second Person Singular]
        vet.eris - (1, 1) [FuturePerfect Active Indicative Second Person Singular]
    """);
    
    [Test]
    public void LookupX() => CheckWord("veteris", """
    [Verb] [Transitive] vet.o vet.are vetu.i vetit.us : forbid, prohibit; reject, veto; be an obstacle to; prevent;
        vet.eris - (1, 1) [Present Passive Subjunctive Second Person Singular]
        vet.eris - (1, 1) [FuturePerfect Active Indicative Second Person Singular]
    """);
    
    [Test]
    public void LookupY() => CheckWord("veteris", """
    [Adjective]  veter. veter.a veter.um : old; long established; veteran, bygone; chronic;
        veter.is - (1, 2) [Positive Plural Dative Unknown]
        veter.is - (1, 2) [Positive Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupZ() => CheckWord("veteris", """
    [Noun]  vetus. veter.is : ancients (pl.), men of old, forefathers;
        veter.is - (3, 1) [Plural Accusative Common]
        veter.is - (3, 1) [Singular Genitive Unknown]
    """);
    
    [Test]
    public void LookupZA() => CheckWord("veteris", """
    [Noun]  vetus. veter.is : old/ancient times (pl.), antiquity; earlier events; old traditions/ways;
        veter.is - (3, 2) [Singular Genitive Unknown]
    """);
    
    [Test]
    public void LookupZB() => CheckWord("veteris", """
    [Adjective]  vetus. veteri.or veterri.mus : old, aged, ancient; former; veteran, experienced; long standing, chronic;
        veter.is - (3, 1) [Positive Singular Genitive Unknown]
        veter.is - (3, 1) [Positive Plural Accusative Common]
    """);
}