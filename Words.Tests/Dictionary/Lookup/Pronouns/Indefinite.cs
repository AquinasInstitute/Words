namespace Words.Tests.Dictionary.Lookup.Pronouns;

public class Indefinite
{
    [Test]
    public void LookupA() => CheckWord("quidam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        qu.idam - (1, 6) [Indefinite Plural Nominative Masculine]
    """);
    
    [Test]
    public void LookupB() => CheckWord("quaedam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        qu.aedam - (1, 6) [Indefinite Plural Nominative Feminine]
    """);
    
    [Test]
    public void LookupC() => CheckWord("quiddam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        qu.iddam - (1, 6) [Indefinite Singular Nominative Neuter]
        qu.iddam - (1, 6) [Indefinite Singular Accusative Neuter]
    """);
    
    [Test]
    public void LookupE() => CheckWord("cuiusdam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        cu.jusdam - (1, 6) [Indefinite Singular Genitive Unknown]
    """);
    
    [Test]
    public void LookupF() => CheckWord("cuidam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        cu.idam - (1, 6) [Indefinite Singular Dative Unknown]
    """);
    
    [Test]
    public void LookupG() => CheckWord("quendam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        qu.emdam - (1, 6) [Indefinite Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupH() => CheckWord("quandam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        qu.amdam - (1, 6) [Indefinite Singular Accusative Feminine]
    """);
    
    [Test]
    public void LookupI() => CheckWord("quodam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        qu.odam - (1, 6) [Indefinite Singular Ablative Masculine]
        qu.odam - (1, 6) [Indefinite Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("quadam", """
    [Packon]  qu.i qu.ae qu.od : certain; as INDEF a certain thing; somebody, one, something;
        qu.a - (1, 0) [Adjectival Singular Ablative Feminine]
            + [Packon -> Packon] Tackon dam - PACKON w/qui => certain; a certain (one); a certain thing;
        qu.a - (1, 0) [Adjectival Plural Nominative Neuter]
            + [Packon -> Packon] Tackon dam - PACKON w/qui => certain; a certain (one); a certain thing;
        qu.a - (1, 0) [Adjectival Plural Accusative Neuter]
            + [Packon -> Packon] Tackon dam - PACKON w/qui => certain; a certain (one); a certain thing;
    """);
    
    [Test]
    public void LookupK() => CheckWord("quaedam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        qu.aedam - (1, 6) [Indefinite Plural Nominative Feminine]
    """);
    
    [Test]
    public void LookupL() => CheckWord("quorundam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        qu.orumdam - (1, 6) [Indefinite Plural Genitive Masculine]
        qu.orumdam - (1, 6) [Indefinite Plural Genitive Neuter]
    """);
    
    [Test]
    public void LookupM() => CheckWord("quarundam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        qu.arumdam - (1, 6) [Indefinite Plural Genitive Feminine]
    """);
    
    [Test]
    public void LookupN() => CheckWord("quibusdam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        qu.ibusdam - (1, 6) [Indefinite Plural Dative Unknown]
        qu.ibusdam - (1, 6) [Indefinite Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupO() => CheckWord("quisdam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        qu.isdam - (1, 6) [Indefinite Plural Dative Unknown]
        qu.isdam - (1, 6) [Indefinite Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupP() => CheckWord("quosdam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        qu.osdam - (1, 6) [Indefinite Plural Accusative Masculine]
    """);
    
    [Test]
    public void LookupQ() => CheckWord("quasdam", """
    [Packon]  qu.idam qu.aedam qu.iddam : a certain (one), a certain thing; somebody, one, something;
        qu.asdam - (1, 6) [Indefinite Plural Accusative Feminine]
    """);
}