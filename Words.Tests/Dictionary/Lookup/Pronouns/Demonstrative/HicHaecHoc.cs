namespace Words.Tests.Dictionary.Lookup.Pronouns.Demonstrative;

public class HicHaecHoc
{
    [Test]
    public void LookupA() => CheckWord("hic", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.ic - (3, 1) [Adjectival Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupB() => CheckWord("haec", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.aec - (3, 1) [Adjectival Singular Nominative Feminine]
        h.aec - (3, 1) [Adjectival Plural Nominative Neuter]
        h.aec - (3, 1) [Adjectival Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupC() => CheckWord("hoc", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.oc - (3, 1) [Adjectival Singular Nominative Neuter]
        h.oc - (3, 1) [Adjectival Singular Accusative Neuter]
        h.oc - (3, 1) [Adjectival Singular Ablative Masculine]
        h.oc - (3, 1) [Adjectival Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupD() => CheckWord("huius", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        hu.ius - (3, 1) [Adjectival Singular Genitive Unknown]
    """);
    
    [Test]
    public void LookupE() => CheckWord("huic", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        hu.ic - (3, 1) [Adjectival Singular Dative Unknown]
    """);
    
    [Test]
    public void LookupF() => CheckWord("hunc", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.unc - (3, 1) [Adjectival Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupG() => CheckWord("hanc", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.anc - (3, 1) [Adjectival Singular Accusative Feminine]
    """);
    
    [Test]
    public void LookupH() => CheckWord("hoc", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.oc - (3, 1) [Adjectival Singular Nominative Neuter]
        h.oc - (3, 1) [Adjectival Singular Accusative Neuter]
        h.oc - (3, 1) [Adjectival Singular Ablative Masculine]
        h.oc - (3, 1) [Adjectival Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupI() => CheckWord("hi", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.i - (3, 1) [Adjectival Plural Nominative Masculine]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("hae", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.ae - (3, 1) [Adjectival Plural Nominative Feminine]
    """);
    
    [Test]
    public void LookupK() => CheckWord("horum", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.orum - (3, 1) [Adjectival Plural Genitive Masculine]
        h.orum - (3, 1) [Adjectival Plural Genitive Neuter]
    """);
    
    [Test]
    public void LookupL() => CheckWord("his", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.is - (3, 1) [Adjectival Plural Dative Unknown]
        h.is - (3, 1) [Adjectival Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupM() => CheckWord("hos", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.os - (3, 1) [Adjectival Plural Accusative Masculine]
    """);
    
    [Test]
    public void LookupN() => CheckWord("has", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.as - (3, 1) [Adjectival Plural Accusative Feminine]
    """);
}