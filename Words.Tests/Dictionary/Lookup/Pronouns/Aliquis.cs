namespace Words.Tests.Dictionary.Lookup.Pronouns;

public class Aliquis
{
    [Test]
    public void LookupA() => CheckWord("aliqua", """
    [Pronoun]  aliqu.is aliqu.a aliqu.id : anyone/anybody/anything; someone; some/few; some (particular) thing;
        aliqu.a - (1, 0) [Indefinite Singular Nominative Feminine]
        aliqu.a - (1, 0) [Indefinite Singular Ablative Feminine]
    """);
    
    [Test]
    public void LookupB() => CheckWord("aliquae", """
    [Pronoun]  aliqu.is aliqu.a aliqu.id : anyone/anybody/anything; someone; some/few; some (particular) thing;
        aliqu.ae - (1, 0) [Indefinite Plural Nominative Feminine]
        aliqu.ae - (1, 0) [Indefinite Plural Nominative Neuter]
        aliqu.ae - (1, 0) [Indefinite Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupC() => CheckWord("aliquid", """
    [Pronoun]  aliqu.is aliqu.a aliqu.id : anyone/anybody/anything; someone; some/few; some (particular) thing;
        aliqu.id - (1, 0) [Indefinite Singular Nominative Neuter]
        aliqu.id - (1, 0) [Indefinite Singular Accusative Neuter]
    """);
    
    [Test]
    public void LookupD() => CheckWord("aliquod", """
    [Pronoun]  aliqu.is aliqu.a aliqu.id : anyone/anybody/anything; someone; some/few; some (particular) thing;
        aliqu.od - (1, 0) [Indefinite Singular Nominative Neuter]
        aliqu.od - (1, 0) [Indefinite Singular Accusative Neuter]
    """);
}