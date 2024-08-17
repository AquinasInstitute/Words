namespace Words.Tests.Dictionary.Lookup.Pronouns;

public class Interrogative
{
    [Test]
    public void LookupA() => CheckWord("quis", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        qu.is - (1, 0) [Interrogative Plural Dative Unknown]
        qu.is - (1, 0) [Interrogative Plural Ablative Unknown]
        qu.is - (1, 0) [Interrogative Singular Nominative Common]
    """);
    
    [Test]
    public void LookupB() => CheckWord("quid", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        qu.id - (1, 0) [Interrogative Singular Nominative Neuter]
        qu.id - (1, 0) [Interrogative Singular Accusative Neuter]
    """);
    
    [Test]
    public void LookupC() => CheckWord("cuius", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        cu.jus - (1, 0) [Interrogative Singular Genitive Unknown]
    """);
    
    [Test]
    public void LookupD() => CheckWord("cui", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        cu.i - (1, 0) [Interrogative Singular Dative Unknown]
    """);
    
    [Test]
    public void LookupE() => CheckWord("quem", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        qu.em - (1, 0) [Interrogative Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupF() => CheckWord("quo", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        qu.o - (1, 0) [Interrogative Singular Ablative Masculine]
        qu.o - (1, 0) [Interrogative Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupG() => CheckWord("qui", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        qu.i - (1, 0) [Interrogative Plural Nominative Masculine]
    """);
    
    [Test]
    public void LookupH() => CheckWord("quae", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        qu.ae - (1, 0) [Interrogative Plural Nominative Feminine]
    """);
    
    [Test]
    public void LookupI() => CheckWord("quorum", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        qu.orum - (1, 0) [Interrogative Plural Genitive Masculine]
        qu.orum - (1, 0) [Interrogative Plural Genitive Neuter]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("quarum", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        qu.arum - (1, 0) [Interrogative Plural Genitive Feminine]
    """);
    
    [Test]
    public void LookupK() => CheckWord("quibus", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        qu.ibus - (1, 0) [Interrogative Plural Dative Unknown]
        qu.ibus - (1, 0) [Interrogative Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupL() => CheckWord("quos", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        qu.os - (1, 0) [Interrogative Plural Accusative Masculine]
    """);
    
    [Test]
    public void LookupM() => CheckWord("quas", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        qu.as - (1, 0) [Interrogative Plural Accusative Feminine]
    """);
}