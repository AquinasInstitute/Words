namespace Words.Tests.Dictionary.Lookup.Pronouns.Personal;

public class FirstPerson
{
    [Test]
    public void LookupA() => CheckWord("ego", """
    [Pronoun]  ego. m.ei : I, me (PERS); myself (REFLEX);
        ego. - (5, 1) [Personal Singular Nominative Common]
    """);

    [Test]
    public void LookupB() => CheckWord("mei", """
    [Pronoun]  ego. m.ei : I, me (PERS); myself (REFLEX);
        m.ei - (5, 1) [Personal Singular Genitive Common]
    """);

    [Test]
    public void LookupC() => CheckWord("mihi", """
    [Pronoun]  ego. m.ei : I, me (PERS); myself (REFLEX);
        m.ihi - (5, 1) [Personal Singular Dative Common]
    """);
    
    [Test]
    public void LookupD() => CheckWord("me", """
    [Pronoun]  ego. m.ei : I, me (PERS); myself (REFLEX);
        m.e - (5, 1) [Personal Singular Accusative Common]
        m.e - (5, 1) [Personal Singular Ablative Common]
    """);
    
    [Test]
    public void LookupE() => CheckWord("nos", """
    [Pronoun]  n.os nostr.um : we (pl.), us;
        n.os - (5, 3) [Personal Plural Nominative Common]
        n.os - (5, 3) [Personal Plural Vocative Common]
        n.os - (5, 3) [Personal Plural Accusative Common]
    """);
    
    [Test]
    public void LookupF() => CheckWord("nostrum", """
    [Pronoun]  n.os nostr.um : we (pl.), us;
        nostr.um - (5, 3) [Personal Plural Genitive Common]
    """);
    
    [Test]
    public void LookupG() => CheckWord("nostri", """
    [Pronoun]  n.os nostr.um : we (pl.), us;
        nostr.i - (5, 3) [Personal Plural Genitive Common]
    """);
    
    [Test]
    public void LookupH() => CheckWord("nobis", """
    [Pronoun]  n.os nostr.um : we (pl.), us;
        n.obis - (5, 3) [Personal Plural Dative Common]
        n.obis - (5, 3) [Personal Plural Ablative Common]
    """);
}