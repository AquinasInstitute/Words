namespace Words.Tests.Dictionary.Lookup.Gauntlet;

public class GauntletE
{
    [Test]
    public void LookupA() => CheckWord("cari", """
    [Noun]  car.os car.i : variety/seed of plant hypericum; heavy sleep, stupor, sleep of death (L+S);
        car.i - (2, 6) [Singular Genitive Unknown]
        car.i - (2, 6) [Singular Locative Unknown]
        car.i - (2, 6) [Plural Nominative Common]
        car.i - (2, 6) [Plural Vocative Common]
    """);
    
    [Test]
    public void LookupB() => CheckWord("decorum", """
    [Noun]  decor. decor.is : beauty/good looks, decent appearance; ornament; grace/elegance/charm; propriety;
        decor.um - (3, 1) [Plural Genitive Common]
    """);
    
    [Test]
    public void LookupC() => CheckWord("verum", """
    [Noun]  ver. ver.is : spring; spring-time of life, youth; [ver sacrum => sacrifice of spring-born];
        ver.um - (3, 2) [Plural Genitive Neuter]
    """);
    
    [Test]
    public void LookupD() => CheckWord("mare", """
    [Noun]  mas. mar.is : male (human/animal/plant); man;
        mar.e - (3, 3) [Singular Locative Unknown]
        mar.e - (3, 3) [Singular Dative Unknown]
        mar.e - (3, 3) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupE() => CheckWord("mare", """
    [Noun]  mare. mar.is : sea; sea water;
        mare. - (3, 4) [Singular Nominative Unknown]
        mare. - (3, 4) [Singular Vocative Unknown]
        mar.e - (3, 4) [Singular Locative Unknown]
        mar.e - (3, 4) [Singular Dative Unknown]
        mar.e - (3, 4) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupF() => CheckWord("heros", """
    [Noun]  heros. hero.is : hero; demigod;
        heros. - (3, 1) [Singular Nominative Unknown]
        heros. - (3, 1) [Singular Vocative Unknown]
    """);
    
    [Test]
    public void LookupG() => CheckWord("eumenidum", """
    [Noun]  euminis. eumenid.os : Fury/Eumenide; (usu. pl.); (euphemistically) the gracious/benevolent ones;
        eumenid.um - (3, 7) [Plural Genitive Unknown]
    """);
    
    [Test]
    public void LookupH() => CheckWord("titan", """
    [Noun]  titan.is titan.os : Titan; (one of race of gods/giants preceding Olympians);
        titan. - (3, 9) [Singular Nominative Unknown]
        titan. - (3, 9) [Singular Vocative Unknown]
    """);
    
    [Test]
    public void LookupI() => CheckWord("altum", """
    [Noun]  alt.us alt.us : nourishing, support;
        alt.um - (4, 1) [Singular Accusative Common]
        alt.um - (4, 1) [Plural Genitive Unknown]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("cornua", """
    [Noun]  corn.u corn.us : horn; hoof; beak/tusk/claw; bow; horn/trumpet; end, wing of army; mountain top;
        corn.ua - (4, 2) [Plural Nominative Neuter]
        corn.ua - (4, 2) [Plural Vocative Neuter]
        corn.ua - (4, 2) [Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupK() => CheckWord("die", """
    [Noun]  di.es di.ei : day; daylight; (sunlit hours); (24 hours from midnight); open sky; weather; specific day; day in question; date of letter; festival; lifetime, age; time;
        di.e - (5, 1) [Singular Genitive Common]
        di.e - (5, 1) [Singular Dative Common]
        di.e - (5, 1) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupL() => CheckWord("num", """
    [Noun]  num. : Numerius (Roman praenomen); (abb. N./Num.);
        num. - (9, 8) [Unknown Unknown Unknown]
    """);
    
    [Test]
    public void LookupM() => CheckWord("secus", """
    [Noun]  secus. : sex;
        secus. - (9, 9) [Unknown Unknown Unknown]
    """);
    
    [Test]
    public void LookupN() => CheckWord("primo", """
    [Numeral]  un.us prim.us : one;
        prim.o - (1, 1) [Singular Dative Masculine] [Ordinal 1]
        prim.o - (1, 1) [Singular Ablative Masculine] [Ordinal 1]
        prim.o - (1, 1) [Singular Dative Neuter] [Ordinal 1]
        prim.o - (1, 1) [Singular Ablative Neuter] [Ordinal 1]
    """);
    
    [Test]
    public void LookupO() => CheckWord("secunda", """
    [Numeral]  du.o secund.us : two (pl.);
        secund.a - (1, 2) [Singular Nominative Feminine] [Ordinal 2]
        secund.a - (1, 2) [Singular Ablative Feminine] [Ordinal 2]
        secund.a - (1, 2) [Singular Vocative Feminine] [Ordinal 2]
        secund.a - (1, 2) [Plural Nominative Neuter] [Ordinal 2]
        secund.a - (1, 2) [Plural Accusative Neuter] [Ordinal 2]
        secund.a - (1, 2) [Plural Vocative Neuter] [Ordinal 2]
    """);
    
    [Test]
    public void LookupP() => CheckWord("ter", """
    [Numeral]  tr.es terti.us : three;
        ter. - (1, 3) [Unknown Unknown Unknown] [Adverb 3]
    """);
    
    [Test]
    public void LookupQ() => CheckWord("senis", """
    [Numeral]  - sext.us : six;
        sen.is - (2, 0) [Plural Dative Unknown] [Distributive 6]
        sen.is - (2, 0) [Plural Ablative Unknown] [Distributive 6]
    """);
    
    [Test]
    public void LookupR() => CheckWord("dextra", """
    [Preposition]  dextra : on the right of; on the right-hand side of;
        dextra
    """);
    
    [Test]
    public void LookupS() => CheckWord("quo", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.o - (1, 0) [Relative Singular Ablative Masculine]
        qu.o - (1, 0) [Relative Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupT() => CheckWord("hic", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.ic - (3, 1) [Adjectival Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupU() => CheckWord("eo", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.o - (4, 1) [Personal Singular Ablative Masculine]
        e.o - (4, 1) [Personal Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupV() => CheckWord("mei", """
    [Pronoun]  ego. m.ei : I, me (PERS); myself (REFLEX);
        m.ei - (5, 1) [Personal Singular Genitive Common]
    """);
    
    [Test]
    public void LookupW() => CheckWord("te", """
    [Pronoun]  tu. t.ui : you (sing.); thou/thine/thee/thy (PERS); yourself/thyself (REFLEX);
        t.e - (5, 2) [Personal Singular Accusative Common]
        t.e - (5, 2) [Personal Singular Ablative Common]
    """);
    
    [Test]
    public void LookupX() => CheckWord("nostri", """
    [Pronoun]  n.os nostr.um : we (pl.), us;
        nostr.i - (5, 3) [Personal Plural Genitive Common]
    """);
    
    [Test]
    public void LookupY() => CheckWord("sibi", """
    [Pronoun]  - s.ui : him/her/it/ones-self; him/her/it; them (selves) (pl.); each other, one another;
        s.ibi - (5, 4) [Reflexive Unknown Dative Common]
    """);
    
    [Test]
    public void LookupZ() => CheckWord("illo", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.o - (6, 1) [Adjectival Singular Ablative Masculine]
        ill.o - (6, 1) [Adjectival Singular Ablative Neuter]
    """);
}