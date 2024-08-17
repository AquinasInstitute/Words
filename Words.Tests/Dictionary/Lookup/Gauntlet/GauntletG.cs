namespace Words.Tests.Dictionary.Lookup.Gauntlet;

public class GauntletG
{
    [Test]
    public void LookupA() => CheckWord("altare", """
    [Noun]  altare. altar.is : altar (usu. pl.), fitting for burnt offerings; burnt offering; high altar;
        altare. - (3, 4) [Singular Nominative Unknown]
        altare. - (3, 4) [Singular Vocative Unknown]
        altar.e - (3, 4) [Singular Locative Unknown]
        altar.e - (3, 4) [Singular Dative Unknown]
        altar.e - (3, 4) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupB() => CheckWord("amos", """
    [Noun]  amos. amor.is : love, affection; the beloved; Cupid; affair; sexual/illicit/homosexual passion;
        amos. - (3, 1) [Singular Nominative Unknown]
        amos. - (3, 1) [Singular Vocative Unknown]
    """);
    
    [Test]
    public void LookupC() => CheckWord("anno", """
    [Verb] [Intransitive] ann.o ann.are annav.i annat.us : swim to/towards, approach by swimming; sail to/towards; brought by sea (goods);
        ann.o - (1, 1) [Present Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupD() => CheckWord("arx", """
    [Noun]  arx. arc.is : citadel, stronghold, city; height, hilltop; Capitoline hill; defense, refuge;
        arx. - (3, 3) [Singular Nominative Unknown]
        arx. - (3, 3) [Singular Vocative Unknown]
    """);
    
    [Test]
    public void LookupE() => CheckWord("bacchus", """
    [Noun]  bacch.us bacch.i : kind of sea-fish (myxon L+S);
        bacch.us - (2, 1) [Singular Nominative Unknown]
        bacch.us - (2, 1) [Singular Accusative Neuter]
    """);
    
    [Test]
    public void LookupF() => CheckWord("carin.o", """
    [Verb] [Intransitive] carin.o carin.are carinav.i carinat.us : curse, abuse, revile, blame; use abusive language;
        carin.o - (1, 1) [Present Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupG() => CheckWord("comitor", """
    [Verb] [Deponent] comit.or comit.ari - comitat.us : join as an attendant, guard/escort; accompany, follow; attend (funeral); go/be carried with; be retained/stay/grow/join with; be connected with; occur;
        comit.or - (1, 1) [Present Passive Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupH() => CheckWord("complector", """
    [Verb] [Deponent] complect.or complect.i - complex.us : embrace, hug; welcome; encircle, encompass; attain; include, bring in, involve; lay hold of, grip; seize; grasp, take in/up; sum up; include in scope, cover;
        complect.or - (3, 1) [Present Passive Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupI() => CheckWord("convenit", """
    [Verb] [Impersonal] conveni.o conven.ire conven.i convent.us : it agrees/came together/is agreed/asserted; [bene ~ nobis=>we're on good terms];
        conven.it - (3, 4) [Present Active Indicative Third Person Singular]
        conven.it - (3, 4) [Perfect Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("deficio", """
    [Verb] [Intransitive] defici.o defic.ere defec.i defect.us : fail/falter; run short/out; grow weak/faint; come to end; revolt/rebel, defect; pass away; become extinct, die/fade out; subside/sink; suffer eclipse, wane;
        defici.o - (3, 1) [Present Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupK() => CheckWord("dexter", """
    [Adjective]  dexter. dexteri.or dexti.mus : right, on/to the right hand/side; skillful/dexterous/handy; favorable/fortunate/pretentious; opportune (L+S); proper/fitting/suitable;
        dexter. - (1, 2) [Positive Singular Nominative Masculine]
        dexter. - (1, 2) [Positive Singular Vocative Masculine]
    """);
    
    [Test]
    public void LookupL() => CheckWord("anna", """
    [Verb] [Transitive] ann.o ann.are annav.i annat.us : pass/live through a year;
        ann.a - (1, 1) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupM() => CheckWord("incensus", """
    [Adjective]  incens.us incensi.or incensissi.mus : ardent, impassioned; radiant, glowing; inflamed, fiery, burning, hot (L+S);
        incens.us - (1, 1) [Positive Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupN() => CheckWord("spes", """
    [Noun]  sp.es sp.ei : hope/anticipation/expectation; prospect/hope/promise; (inheriting/succeeding); object/embodiment of hope; [optio ad ~ => junior hoping to make centurion];
        sp.es - (5, 1) [Singular Nominative Common]
        sp.es - (5, 1) [Singular Vocative Common]
        sp.es - (5, 1) [Plural Nominative Common]
        sp.es - (5, 1) [Plural Vocative Common]
        sp.es - (5, 1) [Plural Accusative Common]
    """);
    
    [Test]
    public void LookupO() => CheckWord("sumo", """
    [Verb] [Unknown] sum.o sum.ere sums.i sumt.us : accept; begin; suppose; select; purchase; obtain; (sumpsi, sumptum);
        sum.o - (3, 1) [Present Active Indicative First Person Singular]
    """);
}