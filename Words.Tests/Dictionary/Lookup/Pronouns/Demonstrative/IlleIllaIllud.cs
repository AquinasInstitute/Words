namespace Words.Tests.Dictionary.Lookup.Pronouns.Demonstrative;

public class IlleIllaIllud
{
    [Test]
    public void LookupA() => CheckWord("ille", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.e - (6, 1) [Adjectival Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupB() => CheckWord("illa", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.a - (6, 1) [Adjectival Singular Nominative Feminine]
        ill.a - (6, 1) [Adjectival Plural Nominative Neuter]
        ill.a - (6, 1) [Adjectival Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupC() => CheckWord("illud", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.ud - (6, 1) [Adjectival Singular Nominative Neuter]
        ill.ud - (6, 1) [Adjectival Singular Accusative Neuter]
    """);
    
    [Test]
    public void LookupD() => CheckWord("illius", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.ius - (6, 1) [Adjectival Singular Genitive Unknown]
    """);
    
    [Test]
    public void LookupE() => CheckWord("illi", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.i - (6, 1) [Adjectival Singular Dative Unknown]
        ill.i - (6, 1) [Adjectival Plural Nominative Masculine]
    """);
    
    [Test]
    public void LookupF() => CheckWord("illum", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.um - (6, 1) [Adjectival Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupG() => CheckWord("illam", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.am - (6, 1) [Adjectival Singular Accusative Feminine]
    """);
    
    [Test]
    public void LookupH() => CheckWord("illo", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.o - (6, 1) [Adjectival Singular Ablative Masculine]
        ill.o - (6, 1) [Adjectival Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupI() => CheckWord("illae", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.ae - (6, 1) [Adjectival Plural Nominative Feminine]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("illorum", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.orum - (6, 1) [Adjectival Plural Genitive Masculine]
        ill.orum - (6, 1) [Adjectival Plural Genitive Neuter]
    """);
    
    [Test]
    public void LookupK() => CheckWord("illarum", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.arum - (6, 1) [Adjectival Plural Genitive Feminine]
    """);
    
    [Test]
    public void LookupL() => CheckWord("illis", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.is - (6, 1) [Adjectival Plural Dative Unknown]
        ill.is - (6, 1) [Adjectival Plural Ablative Unknown]
        ill.is - (6, 1) [Adjectival Plural Ablative Feminine]
    """);
    
    [Test]
    public void LookupM() => CheckWord("illos", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.os - (6, 1) [Adjectival Plural Accusative Masculine]
    """);
    
    [Test]
    public void LookupN() => CheckWord("illas", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.as - (6, 1) [Adjectival Plural Accusative Feminine]
    """);
}