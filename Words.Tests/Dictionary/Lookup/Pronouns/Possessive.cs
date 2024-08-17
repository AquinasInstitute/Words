namespace Words.Tests.Dictionary.Lookup.Pronouns;

public class Possessive
{
    [Test]
    public void LookupA() => CheckWord("meus", """
    [Adjective]  me.us me.a me.um : my (personal possession); mine, of me, belonging to me; my own; to me;
        me.us - (1, 1) [Positive Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupB() => CheckWord("meum", """
    [Adjective]  me.us me.a me.um : my (personal possession); mine, of me, belonging to me; my own; to me;
        me.um - (1, 1) [Positive Singular Nominative Neuter]
        me.um - (1, 1) [Positive Singular Accusative Neuter]
        me.um - (1, 1) [Positive Singular Vocative Neuter]
        me.um - (1, 1) [Positive Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupC() => CheckWord("tuus", """
    [Adjective]  tu.us tu.a tu.um : your (sing.);
        tu.us - (1, 1) [Positive Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupD() => CheckWord("tuum", """
    [Adjective]  tu.us tu.a tu.um : your (sing.);
        tu.um - (1, 1) [Positive Singular Nominative Neuter]
        tu.um - (1, 1) [Positive Singular Accusative Neuter]
        tu.um - (1, 1) [Positive Singular Vocative Neuter]
        tu.um - (1, 1) [Positive Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupE() => CheckWord("suus", """
    [Adjective]  su.us su.a su.um : his/one's (own), her (own), hers, its (own); (pl.) their (own), theirs;
        su.us - (1, 1) [Positive Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupF() => CheckWord("suum", """
    [Adjective]  su.us su.a su.um : his/one's (own), her (own), hers, its (own); (pl.) their (own), theirs;
        su.um - (1, 1) [Positive Singular Nominative Neuter]
        su.um - (1, 1) [Positive Singular Accusative Neuter]
        su.um - (1, 1) [Positive Singular Vocative Neuter]
        su.um - (1, 1) [Positive Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupG() => CheckWord("noster", """
    [Adjective]  noster. noster.a noster.um : our;
        noster. - (1, 2) [Positive Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupH() => CheckWord("vester", """
    [Adjective]  vester. vester.a vester.um : your (pl.), of/belonging to/associated with you;
        vester. - (1, 2) [Positive Singular Nominative Masculine]
    """);
}