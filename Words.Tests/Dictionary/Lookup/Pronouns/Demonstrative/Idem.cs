namespace Words.Tests.Dictionary.Lookup.Pronouns.Demonstrative;

public class Idem
{
    [Test]
    public void LookupA() => CheckWord("idem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        i.dem - (4, 2) [Demonstrative Singular Nominative Masculine]
        i.dem - (4, 2) [Demonstrative Singular Nominative Neuter]
        i.dem - (4, 2) [Demonstrative Singular Accusative Neuter]
    """);
    
    [Test]
    public void LookupB() => CheckWord("eadem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        e.adem - (4, 2) [Demonstrative Plural Nominative Neuter]
        e.adem - (4, 2) [Demonstrative Plural Accusative Neuter]
        e.adem - (4, 2) [Demonstrative Singular Nominative Feminine]
        e.adem - (4, 2) [Demonstrative Singular Ablative Feminine]
    """);
    
    [Test]
    public void LookupC() => CheckWord("eiusdem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        e.iusdem - (4, 2) [Demonstrative Singular Genitive Unknown]
    """);
    
    [Test]
    public void LookupD() => CheckWord("eidem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        e.idem - (4, 2) [Demonstrative Singular Dative Unknown]
    """);
    
    [Test]
    public void LookupE() => CheckWord("eundem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        e.undem - (4, 2) [Demonstrative Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupF() => CheckWord("eandem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        e.andem - (4, 2) [Demonstrative Singular Accusative Feminine]
    """);
    
    [Test]
    public void LookupG() => CheckWord("eodem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        e.odem - (4, 2) [Demonstrative Singular Ablative Masculine]
        e.odem - (4, 2) [Demonstrative Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupH() => CheckWord("eaedem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        e.aedem - (4, 2) [Demonstrative Plural Nominative Feminine]
    """);
    
    [Test]
    public void LookupI() => CheckWord("eorundem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        e.orundem - (4, 2) [Demonstrative Plural Genitive Masculine]
        e.orundem - (4, 2) [Demonstrative Plural Genitive Neuter]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("earundem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        e.arundem - (4, 2) [Demonstrative Plural Genitive Feminine]
    """);
    
    [Test]
    public void LookupK() => CheckWord("eisdem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        e.isdem - (4, 2) [Demonstrative Plural Dative Unknown]
        e.isdem - (4, 2) [Demonstrative Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupL() => CheckWord("isdem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        .isdem - (4, 2) [Demonstrative Plural Dative Unknown]
        .isdem - (4, 2) [Demonstrative Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupM() => CheckWord("eosdem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        e.osdem - (4, 2) [Demonstrative Plural Accusative Masculine]
    """);
    
    [Test]
    public void LookupN() => CheckWord("easdem", """
    [Pronoun]  i.dem e.adem i.dem : (w/-dem ONLY, idem, eadem, idem) same, the same, the very same, also;
        e.asdem - (4, 2) [Demonstrative Plural Accusative Feminine]
    """);
}