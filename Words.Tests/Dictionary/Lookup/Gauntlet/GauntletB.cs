namespace Words.Tests.Dictionary.Lookup.Gauntlet;

public class GauntletB
{
    [Test]
    public void LookupA() => CheckWord("vincl.o", """
    [Noun]  vincl.um vincl.i : chain, bond, fetter; imprisonment (pl.);
        vincl.o - (2, 2) [Singular Dative Unknown]
        vincl.o - (2, 2) [Singular Ablative Unknown]
    """);
    
    [Test]
    public void LookupB() => CheckWord("vellem", """
    [Verb] [Unknown] vol.o vel.le volu.i - : wish, want, prefer; be willing, will;
        vel.lem - (6, 2) [Imperfect Active Subjunctive First Person Singular]
    """);
    
    [Test]
    public void LookupC() => CheckWord("iugali", """
    [Adjective]  jugal.is jugal.is jugal.e : yoked together; nuptial;
        jugal.i - (3, 2) [Positive Singular Dative Unknown]
        jugal.i - (3, 2) [Positive Singular Ablative Unknown]
    """);
    
    [Test]
    public void LookupD() => CheckWord("postquam", """
    [Conjunction]  postquam : after;
        postquam
    """);
    
    [Test]
    public void LookupE() => CheckWord("amor", """
    [Verb] [Unknown] am.o am.are amav.i amat.us : love, like; fall in love with; be fond of; have a tendency to;
        am.or - (1, 1) [Present Passive Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupF() => CheckWord("amor", """
    [Noun]  amor. amor.is : love; affection; the beloved; Cupid; affair; sexual/illicit/homosexual passion;
        amor. - (3, 1) [Singular Nominative Unknown]
        amor. - (3, 1) [Singular Vocative Unknown]
    """);
    
    [Test]
    public void LookupG() => CheckWord("deceptam", """
    [Verb] [Transitive] decipi.o decip.ere decep.i decept.us : cheat/deceive/mislead/dupe/trap; elude/escape notice; disappoint/frustrate/foil;
        [Participle] decept.am - (0, 0) [Perfect Passive Accusative Feminine]
    """);
    
    [Test]
    public void LookupH() => CheckWord("morte", """
    [Noun]  mors. mort.is : death; corpse; annihilation;
        mort.e - (3, 3) [Singular Locative Unknown]
        mort.e - (3, 3) [Singular Dative Unknown]
        mort.e - (3, 3) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupI() => CheckWord("fefellit", """
    [Verb] [Unknown] fall.o fall.ere fefell.i fals.us : deceive; slip by; disappoint; be mistaken, beguile, drive away; fail; cheat;
        fefell.it - (3, 1) [Perfect Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("thalami", """
    [Noun]  thalam.us thalam.i : bedroom; marriage;
        thalam.i - (2, 1) [Singular Genitive Unknown]
        thalam.i - (2, 1) [Singular Locative Unknown]
        thalam.i - (2, 1) [Plural Nominative Common]
        thalam.i - (2, 1) [Plural Vocative Common]
    """);
    
    [Test]
    public void LookupK() => CheckWord("fuisset", """
    [Verb] [ToBe] s.um .esse fu.i fut.urus : be; exist; (also used to form verb perfect passive tenses) with NOM PERF PPL
        fu.isset - (5, 1) [Pluperfect Active Subjunctive Third Person Singular]
    """);
    
    [Test]
    public void LookupL() => CheckWord("forsan", """
    [Adverb]  forsan : perhaps;
        forsan
    """);
    
    [Test]
    public void LookupM() => CheckWord("sociare", """
    [Verb] [Unknown] soci.o soci.are sociav.i sociat.us : unite, join, ally; share in;
        soci.are - (1, 1) [Present Passive Indicative Second Person Singular]
        soci.are - (1, 1) [Present Passive Imperative Second Person Singular]
        soci.are - (1, 1) [Present Active Infinitive Unknown Person Unknown]
        sociare - (1, 1) [Perfect Active Indicative Third Person Plural]
            (sociav.ere => sociare): Syncopated perfect often drops the 'v' and contracts the vowel)
    """);
    
    [Test]
    public void LookupN() => CheckWord("primus", """
    [Adjective]  prim.us prim.a prim.um : first, foremost/best, chief, principal; nearest/next; [in primis => especially];
        prim.us - (1, 1) [Positive Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupO() => CheckWord("primus", """
    [Noun]  prim.us prim.i : chiefs (pl.), nobles;
        prim.us - (2, 1) [Singular Nominative Unknown]
        prim.us - (2, 1) [Singular Accusative Neuter]
    """);
    
    [Test]
    public void LookupQ() => CheckWord("pertaesum", """
    [Verb] [Impersonal] pertaed.eo pertaed.ere pertaedu.i pertaes.us : it wearies; it disgusts; it bores;
        [Supine] pertaes.um - (0, 0) [Singular Accusative Neuter]
        [Participle] pertaes.um - (0, 0) [Perfect Passive Accusative Masculine]
        [Participle] pertaes.um - (0, 0) [Perfect Passive Nominative Neuter]
        [Participle] pertaes.um - (0, 0) [Perfect Passive Accusative Neuter]
        [Participle] pertaes.um - (0, 0) [Perfect Passive Vocative Neuter]
    """);
    
    [Test]
    public void LookupR() => CheckWord("uni", """
    [Adjective]  un.us un.a un.um : alone, a single/sole; some, some one; only (pl.); one set of (denoting entity);
        un.i - (1, 3) [Positive Singular Dative Unknown]
        un.i - (1, 3) [Positive Plural Nominative Masculine]
        un.i - (1, 3) [Positive Plural Vocative Masculine]
    """);
    
    [Test]
    public void LookupS() => CheckWord("uni", """
    [Verb] [Transitive] uni.o un.ire univ.i unit.us : unite, combine into one;
        un.i - (3, 4) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupT() => CheckWord("potui", """
    [Verb] [ToBeing] poss.um poss.e potu.i - : be able, can; [multum  posse => have much/more/most influence/power];
        potu.i - (5, 2) [Perfect Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupU() => CheckWord("potui", """
    [Noun]  pot.us pot.us : drink/draught; something to drink; (action of) drinking (intoxicating drink);
        pot.ui - (4, 1) [Singular Dative Common]
    """);
    
    [Test]
    public void LookupV() => CheckWord("succumbere", """
    [Verb] [Intransitive] succumb.o succumb.ere succubu.i succubit.us : sink/fall/lie/break down; succumb/collapse (w/weight); suffer/concede defeat; surrender; yield; lay under; lie under/submit (female to male); cohabit (L+S); give in/way; lower itself (animal to take load); be rival to (DAT of a woman);
        succumb.ere - (3, 1) [Present Passive Indicative Second Person Singular]
        succumb.ere - (3, 1) [Present Passive Imperative Second Person Singular]
        succumb.ere - (3, 1) [Present Active Infinitive Unknown Person Unknown]
        succumb.ere - (3, 1) [Future Passive Indicative Second Person Singular]
    """);
    
    [Test]
    public void LookupW() => CheckWord("culpae", """
    [Noun]  culp.a culp.ae : fault/blame/responsibility (w/GEN); crime (esp. against chastity); negligence; offense; error; (sense of) guilt; fault/defect (moral/other); sickness/injury;
        culp.ae - (1, 1) [Singular Genitive Common]
        culp.ae - (1, 1) [Singular Locative Common]
        culp.ae - (1, 1) [Singular Dative Common]
        culp.ae - (1, 1) [Plural Nominative Common]
        culp.ae - (1, 1) [Plural Vocative Common]
    """);
    
    [Test]
    public void LookupX() => CheckWord("fatebor", """
    [Verb] [Deponent] fat.eor fat.eri - fass.us : admit, confess (w/ACC); disclose; acknowledge; praise (w/DAT);
        fat.ebor - (2, 1) [Future Passive Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupY() => CheckWord("enim", """
    [Conjunction]  enim : namely (postpos.); indeed; in fact; for; I mean, for instance, that is to say;
        enim
    """);
    
    [Test]
    public void LookupZ() => CheckWord("miseri", """
    [Noun]  miser. miser.i : wretched people (pl.);
        miser.i - (2, 3) [Singular Genitive Unknown]
        miser.i - (2, 3) [Singular Locative Unknown]
        miser.i - (2, 3) [Plural Nominative Common]
        miser.i - (2, 3) [Plural Vocative Common]
    """);
    
    [Test]
    public void LookupZ2() => CheckWord("miseri", """
    [Adjective]  miser. miseri.or miserri.mus : poor, miserable, wretched, unfortunate, unhappy, distressing;
        miser.i - (1, 2) [Positive Singular Genitive Masculine]
        miser.i - (1, 2) [Positive Singular Genitive Neuter]
        miser.i - (1, 2) [Positive Plural Nominative Masculine]
        miser.i - (1, 2) [Positive Plural Vocative Masculine]
    """);
}