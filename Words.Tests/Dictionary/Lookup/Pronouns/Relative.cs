namespace Words.Tests.Dictionary.Lookup.Pronouns;

public class Relative
{
    [Test]
    public void LookupA() => CheckWord("qui", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.i - (1, 0) [Relative Plural Nominative Masculine]
        qu.i - (1, 0) [Relative Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupB() => CheckWord("quae", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.ae - (1, 0) [Relative Plural Nominative Feminine]
        qu.ae - (1, 0) [Relative Singular Nominative Feminine]
    """);
    
    [Test]
    public void LookupC() => CheckWord("quod", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.od - (1, 0) [Relative Singular Nominative Neuter]
        qu.od - (1, 0) [Relative Singular Accusative Neuter]
    """);
    
    [Test]
    public void LookupD() => CheckWord("cuius", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        cu.jus - (1, 0) [Relative Singular Genitive Unknown]
    """);
    
    [Test]
    public void LookupE() => CheckWord("cui", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        cu.i - (1, 0) [Relative Singular Dative Unknown]
    """);
    
    [Test]
    public void LookupF() => CheckWord("quem", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.em - (1, 0) [Relative Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupG() => CheckWord("quam", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.am - (1, 0) [Relative Singular Accusative Feminine]
    """);
    
    [Test]
    public void LookupH() => CheckWord("quo", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.o - (1, 0) [Relative Singular Ablative Masculine]
        qu.o - (1, 0) [Relative Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupI() => CheckWord("qua", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.a - (1, 0) [Relative Singular Ablative Feminine]
        qu.a - (1, 0) [Relative Plural Nominative Neuter]
        qu.a - (1, 0) [Relative Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("quae", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.ae - (1, 0) [Relative Plural Nominative Feminine]
        qu.ae - (1, 0) [Relative Singular Nominative Feminine]
    """);
    
    [Test]
    public void LookupK() => CheckWord("quorum", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.orum - (1, 0) [Relative Plural Genitive Masculine]
        qu.orum - (1, 0) [Relative Plural Genitive Neuter]
    """);
    
    [Test]
    public void LookupL() => CheckWord("quarum", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.arum - (1, 0) [Relative Plural Genitive Feminine]
    """);
    
    [Test]
    public void LookupM() => CheckWord("quibus", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.ibus - (1, 0) [Relative Plural Dative Unknown]
        qu.ibus - (1, 0) [Relative Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupN() => CheckWord("quos", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.os - (1, 0) [Relative Plural Accusative Masculine]
    """);
    
    [Test]
    public void LookupO() => CheckWord("quas", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.as - (1, 0) [Relative Plural Accusative Feminine]
    """);
}