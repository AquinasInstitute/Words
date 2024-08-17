namespace Words.Tests.Dictionary.Lookup.Pronouns.Demonstrative;

public class IpseIpsaIpsum
{
    [Test]
    public void LookupA() => CheckWord("ipse", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.e - (6, 2) [Unknown Singular Nominative Masculine]
    """);
    [Test]
    public void LookupB() => CheckWord("ipsa", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.a - (6, 2) [Unknown Singular Nominative Feminine]
        ips.a - (6, 2) [Unknown Plural Nominative Neuter]
        ips.a - (6, 2) [Unknown Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupC() => CheckWord("ipsum", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.um - (6, 2) [Unknown Singular Nominative Neuter]
        ips.um - (6, 2) [Unknown Singular Accusative Neuter]
        ips.um - (6, 2) [Unknown Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupD() => CheckWord("ipsius", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.ius - (6, 2) [Unknown Singular Genitive Unknown]
    """);
    
    [Test]
    public void LookupE() => CheckWord("ipsi", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.i - (6, 2) [Unknown Singular Dative Unknown]
        ips.i - (6, 2) [Unknown Plural Nominative Masculine]
    """);
    
    [Test]
    public void LookupF() => CheckWord("ipsam", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.am - (6, 2) [Unknown Singular Accusative Feminine]
    """);
    
    [Test]
    public void LookupG() => CheckWord("ipso", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.o - (6, 2) [Unknown Singular Ablative Masculine]
        ips.o - (6, 2) [Unknown Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupH() => CheckWord("ipsae", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.ae - (6, 2) [Unknown Plural Nominative Feminine]
    """);
    
    [Test]
    public void LookupI() => CheckWord("ipsorum", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.orum - (6, 2) [Unknown Plural Genitive Masculine]
        ips.orum - (6, 2) [Unknown Plural Genitive Neuter]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("ipsarum", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.arum - (6, 2) [Unknown Plural Genitive Feminine]
    """);
    
    [Test]
    public void LookupK() => CheckWord("ipsis", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.is - (6, 2) [Unknown Plural Dative Unknown]
        ips.is - (6, 2) [Unknown Plural Ablative Unknown]
        ips.is - (6, 2) [Unknown Plural Ablative Feminine]
    """);
    
    [Test]
    public void LookupL() => CheckWord("ipsos", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.os - (6, 2) [Unknown Singular Nominative Masculine]
        ips.os - (6, 2) [Unknown Plural Accusative Masculine]
    """);
    
    [Test]
    public void LookupM() => CheckWord("ipsas", """
    [Pronoun]  ips.e ips.a ips.um : himself/herself/itself; the very/real/actual one; in person; themselves (pl.);
        ips.as - (6, 2) [Unknown Plural Accusative Feminine]
    """);
}