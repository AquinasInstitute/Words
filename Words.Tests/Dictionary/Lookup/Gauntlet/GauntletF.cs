namespace Words.Tests.Dictionary.Lookup.Gauntlet;

public class GauntletF
{
    [Test]
    public void LookupA() => CheckWord("ipsa", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.a - (6, 2) [Unknown Singular Nominative Feminine]
        ips.a - (6, 2) [Unknown Plural Nominative Neuter]
        ips.a - (6, 2) [Unknown Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupB() => CheckWord("adfatu", """
    [Verb] [Deponent] adf.or adf.ari - adfat.us : speak to, address; be spoked to/addressed (PASS), be decreed by fate;
        [Supine] adfat.u - (0, 0) [Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupC() => CheckWord("fletu", """
    [Verb] [Unknown] fl.eo fl.ere flev.i flet.us : cry for; cry, weep;
        [Supine] flet.u - (0, 0) [Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupD() => CheckWord("casu", """
    [Verb] [Intransitive] cad.o cad.ere cecid.i cas.us : fall, sink, drop, plummet, topple; be slain, die; end, cease, abate; decay;
        [Supine] cas.u - (0, 0) [Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupE() => CheckWord("stygius", """
    [Adjective]  stygi.us stygi.a stygi.um : Stygian; of the river Styx; of the underworld;
        stygi.us - (1, 1) [Positive Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupF() => CheckWord("eo", """
    [Verb] [Unknown] e.o e.are ev.i et.us : go, walk; march, advance; pass; flow; pass (time); ride; be in the middle;
        e.o - (1, 1) [Present Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupG() => CheckWord("liceat", """
    [Verb] [Impersonal] lic.eo lic.ere licu.i licit.us : it is permitted, one may; it is all right, lawful, allowed, permitted;
        lic.eat - (2, 1) [Present Active Subjunctive Third Person Singular]
    """);
    
    [Test]
    public void LookupH() => CheckWord("cari", """
    [Verb] [Transitive] car.o car.ere - - : card/comb (wool/flax/etc.);
        car.i - (3, 1) [Present Passive Infinitive Unknown Person Unknown]
    """);
    
    [Test]
    public void LookupI() => CheckWord("feras", """
    [Verb] [Unknown] fer.o fer.re tul.i lat.us : bring, bear; tell/speak of; consider; carry off, win, receive, produce; get;
        fer.as - (3, 2) [Present Active Subjunctive Second Person Singular]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("confieri", """
    [Verb] [SemiDeponent] confi.o conf.ieri - confact.us : be made/constructed/prepared/completed/accomplished/caused/performed/done; be composed/amassed/collected/raised (troops); be consumed/expended/spent; be finished off/killed/dispatched/subdued/reduced/pacified/defeated finally; be chopped/cut up; be recorded/written; come about/happen; (conficio PASS);
        conf.ieri - (3, 3) [Present Active Infinitive Unknown Person Unknown]
    """);
    
    [Test]
    public void LookupK() => CheckWord("patior", """
    [Verb] [Deponent] pati.or pat.i - pass.us : suffer; allow; undergo, endure; permit;
        pati.or - (3, 1) [Present Passive Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupL() => CheckWord("fore", """
    [Verb] [ToBe] s.um .esse fu.i fut.urus : be; exist; (also used to form verb perfect passive tenses) with NOM PERF PPL
        .fore - (5, 1) [Future Active Infinitive Unknown Person Unknown]
    """);
    
    [Test]
    public void LookupM() => CheckWord("potes", """
    [Verb] [ToBeing] poss.um poss.e potu.i - : be able, can; [multum  posse => have much/more/most influence/power];
        pot.es - (5, 2) [Imperfect Active Subjunctive Second Person Singular]
        pot.es - (5, 2) [Present Active Indicative Second Person Singular]
    """);
    
    [Test]
    public void LookupN() => CheckWord("eo", """
    [Verb] [Unknown] e.o i.re iv.i it.us : go, walk; march, advance; pass; flow; pass (time); ride; sail;
        e.o - (6, 1) [Present Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupO() => CheckWord("malis", """
    [Verb] [Unknown] mal.o mal.le malu.i - : prefer; incline toward, wish rather;
        mal.is - (6, 2) [Present Active Subjunctive Second Person Singular]
    """);
    
    [Test]
    public void LookupP() => CheckWord("ait", """
    [Verb] [Unknown] ai.o - - - : say (defective), assert; say yes/so, affirm, assent; prescribe/lay down (law);
        a.it - (7, 1) [Present Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupQ() => CheckWord("esto", """
    [Verb] [Transitive] - es.se - - : eat/consume/devour; eat away (fire/water/disease); destroy; spend money on food;
        es.to - (7, 3) [Future Active Imperative Second Person Singular]
        es.to - (7, 3) [Future Active Imperative Third Person Singular]
    """);
    
    [Test]
    public void LookupR() => CheckWord("volans", """
    [Verb] [Unknown] vol.o vol.are volav.i volat.us : fly;
        [Participle] vol.ans - (1, 0) [Present Active Nominative Unknown]
        [Participle] vol.ans - (1, 0) [Present Active Vocative Unknown]
        [Participle] vol.ans - (1, 0) [Present Active Accusative Neuter]
    """);
    
    [Test]
    public void LookupS() => CheckWord("egentem", """
    [Verb] [Unknown] eg.eo eg.ere egu.i - : need (w/GEN/ABL), lack, want; require, be without;
        [Participle] eg.entem - (2, 0) [Present Active Accusative Common]
    """);
    
    [Test]
    public void LookupT() => CheckWord("agens", """
    [Verb] [Unknown] ag.o ag.ere eg.i act.us : drive/urge/conduct/act; spend (time w/cum); thank (w/gratias); deliver (speech);
        [Participle] ag.ens - (3, 0) [Present Active Nominative Unknown]
        [Participle] ag.ens - (3, 0) [Present Active Vocative Unknown]
        [Participle] ag.ens - (3, 0) [Present Active Accusative Neuter]
    """);
    
    [Test]
    public void LookupU() => CheckWord("late", """
    [Verb] [Unknown] fer.o fer.re tul.i lat.us : bring, bear; tell/speak of; consider; carry off, win, receive, produce; get;
        [Participle] lat.e - (0, 0) [Perfect Passive Vocative Masculine]
    """);
    
    [Test]
    public void LookupV() => CheckWord("factum", """
    [Verb] [SemiDeponent] fi.o f.ieri - fact.us : happen, come about; result (from); take place, be held, occur, arise (event); be made/created/instituted/elected/appointed/given; be prepared/done; develop; be made/become; (facio PASS); [fiat => so be it, very well; it is being done];
        [Supine] fact.um - (0, 0) [Singular Accusative Neuter]
        [Participle] fact.um - (0, 0) [Perfect Passive Accusative Masculine]
        [Participle] fact.um - (0, 0) [Perfect Passive Nominative Neuter]
        [Participle] fact.um - (0, 0) [Perfect Passive Accusative Neuter]
        [Participle] fact.um - (0, 0) [Perfect Passive Vocative Neuter]
    """);
    
    [Test]
    public void LookupW() => CheckWord("sancte", """
    [Verb] [Transitive] sanci.o sanc.ire sanx.i sanct.us : confirm, ratify; sanction; fulfill (prophesy); enact (law); ordain; dedicate;
        [Participle] sanct.e - (0, 0) [Perfect Passive Vocative Masculine]
    """);
    
    [Test]
    public void LookupX() => CheckWord("futuros", """
    [Verb] [ToBe] s.um .esse fu.i fut.urus : be; exist; (also used to form verb perfect passive tenses) with NOM PERF PPL
        [Participle] fut.uros - (0, 0) [Future Active Accusative Masculine]
    """);
    
    [Test]
    public void LookupY() => CheckWord("citi", """
    [Verb] [Transitive] ci.o ci.re civ.i cit.us : move, set in motion; excite/rouse/stir up; urge on; summon/muster/call up; disturb, shake; provoke (war); invoke, call on by name; cite; raise/produce;
        [Participle] cit.i - (0, 0) [Perfect Passive Genitive Masculine]
        [Participle] cit.i - (0, 0) [Perfect Passive Nominative Masculine]
        [Participle] cit.i - (0, 0) [Perfect Passive Vocative Masculine]
        [Participle] cit.i - (0, 0) [Perfect Passive Genitive Neuter]
    """);
    
    [Test]
    public void LookupZ() => CheckWord("a.", """
    [Noun]  a. : year; abb. ann./a.; [regnavit a(nnis). XLIIII => he reigned for 44 years];
        a. - (9, 8) [Unknown Unknown Unknown]
    """);
}