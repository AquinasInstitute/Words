namespace Words.Tests.Dictionary.Lookup.Pronouns;


public class Reflexive
{
    [Test]
    public void LookupA() => CheckWord("sui", """
    [Pronoun]  - s.ui : him/her/it/ones-self; him/her/it; them (selves) (pl.); each other, one another;
        s.ui - (5, 4) [Reflexive Unknown Genitive Common]
    """);

    [Test]
    public void LookupB() => CheckWord("sibi", """
    [Pronoun]  - s.ui : him/her/it/ones-self; him/her/it; them (selves) (pl.); each other, one another;
        s.ibi - (5, 4) [Reflexive Unknown Dative Common]
    """);

    [Test]
    public void LookupC() => CheckWord("se", """
    [Pronoun]  - s.ui : him/her/it/ones-self; him/her/it; them (selves) (pl.); each other, one another;
        s.e - (5, 4) [Reflexive Unknown Accusative Common]
        s.e - (5, 4) [Reflexive Unknown Ablative Common]
    """);
}