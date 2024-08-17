namespace Words.Tests.Dictionary.Lookup.Pronouns.Personal;

public class SecondPerson
{
    [Test]
    public void LookupA() => CheckWord("tu", """
    [Pronoun]  tu. t.ui : you (sing.); thou/thine/thee/thy (PERS); yourself/thyself (REFLEX);
        tu. - (5, 2) [Personal Singular Nominative Common]
    """);

    [Test]
    public void LookupB() => CheckWord("tui", """
    [Pronoun]  tu. t.ui : you (sing.); thou/thine/thee/thy (PERS); yourself/thyself (REFLEX);
        t.ui - (5, 2) [Personal Singular Genitive Common]
    """);

    [Test]
    public void LookupC() => CheckWord("tibi", """
    [Pronoun]  tu. t.ui : you (sing.); thou/thine/thee/thy (PERS); yourself/thyself (REFLEX);
        t.ibi - (5, 2) [Personal Singular Dative Common]
    """);
    
    [Test]
    public void LookupD() => CheckWord("te", """
    [Pronoun]  tu. t.ui : you (sing.); thou/thine/thee/thy (PERS); yourself/thyself (REFLEX);
        t.e - (5, 2) [Personal Singular Accusative Common]
        t.e - (5, 2) [Personal Singular Ablative Common]
    """);
    
    [Test]
    public void LookupE() => CheckWord("vos", """
    [Pronoun]  v.os vestr.um : you (pl.), ye;
        v.os - (5, 3) [Personal Plural Nominative Common]
        v.os - (5, 3) [Personal Plural Vocative Common]
        v.os - (5, 3) [Personal Plural Accusative Common]
    """);
    
    [Test]
    public void LookupF() => CheckWord("vestrum", """
    [Pronoun]  v.os vestr.um : you (pl.), ye;
        vestr.um - (5, 3) [Personal Plural Genitive Common]
    """);
    
    [Test]
    public void LookupG() => CheckWord("vestri", """
    [Pronoun]  v.os vestr.um : you (pl.), ye;
        vestr.i - (5, 3) [Personal Plural Genitive Common]
    """);
    
    [Test]
    public void LookupH() => CheckWord("vostrum", """
    [Pronoun]  v.os vostr.um : you (pl.), ye;
        vostr.um - (5, 3) [Personal Plural Genitive Common]
    """);
    
    [Test]
    public void LookupI() => CheckWord("vobis", """
    [Pronoun]  v.os vestr.um : you (pl.), ye;
        v.obis - (5, 3) [Personal Plural Dative Common]
        v.obis - (5, 3) [Personal Plural Ablative Common]
    """);
}