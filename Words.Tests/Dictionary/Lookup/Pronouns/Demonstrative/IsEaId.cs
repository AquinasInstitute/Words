namespace Words.Tests.Dictionary.Lookup.Pronouns.Demonstrative;

public class IsEaId
{
    [Test]
    public void LookupA() => CheckWord("is", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        i.s - (4, 1) [Personal Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupB() => CheckWord("ea", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.a - (4, 1) [Personal Singular Nominative Feminine]
        e.a - (4, 1) [Personal Singular Ablative Feminine]
        e.a - (4, 1) [Personal Plural Nominative Neuter]
        e.a - (4, 1) [Personal Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupC() => CheckWord("id", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        i.d - (4, 1) [Personal Singular Nominative Neuter]
    """);
    
    [Test]
    public void LookupD() => CheckWord("eius", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.ius - (4, 1) [Personal Singular Genitive Unknown]
    """);
    
    [Test]
    public void LookupE() => CheckWord("ei", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.i - (4, 1) [Personal Singular Dative Unknown]
        e.i - (4, 1) [Personal Plural Nominative Masculine]
        e.i - (4, 1) [Personal Plural Nominative Masculine]
    """);
    
    [Test]
    public void LookupF() => CheckWord("eum", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.um - (4, 1) [Personal Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupG() => CheckWord("eam", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.am - (4, 1) [Personal Singular Accusative Feminine]
    """);
    
    [Test]
    public void LookupH() => CheckWord("eo", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.o - (4, 1) [Personal Singular Ablative Masculine]
        e.o - (4, 1) [Personal Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupI() => CheckWord("ei", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.i - (4, 1) [Personal Singular Dative Unknown]
        e.i - (4, 1) [Personal Plural Nominative Masculine]
        e.i - (4, 1) [Personal Plural Nominative Masculine]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("eae", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.ae - (4, 1) [Personal Plural Nominative Feminine]
    """);
    
    [Test]
    public void LookupK() => CheckWord("eorum", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.orum - (4, 1) [Personal Plural Genitive Masculine]
        e.orum - (4, 1) [Personal Plural Genitive Neuter]
    """);
    
    [Test]
    public void LookupL() => CheckWord("earum", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.arum - (4, 1) [Personal Plural Genitive Feminine]
    """);
    
    [Test]
    public void LookupM() => CheckWord("eis", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.is - (4, 1) [Personal Plural Dative Unknown]
        e.is - (4, 1) [Personal Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupN() => CheckWord("iis", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        i.is - (4, 1) [Personal Plural Dative Unknown]
        i.is - (4, 1) [Personal Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupO() => CheckWord("eos", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.os - (4, 1) [Personal Plural Accusative Masculine]
    """);
    
    [Test]
    public void LookupP() => CheckWord("eas", """
    [Pronoun]  i.s e.a i.d : he/she/it/they (by GENDER/NUMBER); DEMONST: that, he/she/it, they/them;
        e.as - (4, 1) [Personal Plural Accusative Feminine]
    """);
}