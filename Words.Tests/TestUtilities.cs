namespace Words.Tests;

public class TestUtilities
{
    /*
    [Test]
    public void LookupA() => CheckWord("", """

    """);
    
    [Test]
    public void LookupB() => CheckWord("", """

    """);
    
    [Test]
    public void LookupC() => CheckWord("", """

    """);
    
    [Test]
    public void LookupD() => CheckWord("", """

    """);
    
    [Test]
    public void LookupE() => CheckWord("", """

    """);
    
    [Test]
    public void LookupF() => CheckWord("", """

    """);
    
    [Test]
    public void LookupG() => CheckWord("", """

    """);
    
    [Test]
    public void LookupH() => CheckWord("", """

    """);
    
    [Test]
    public void LookupI() => CheckWord("", """

    """);
    
    [Test]
    public void LookupJ() => CheckWord("", """

    """);
    
    [Test]
    public void LookupK() => CheckWord("", """

    """);
    
    [Test]
    public void LookupL() => CheckWord("", """

    """);
    
    [Test]
    public void LookupM() => CheckWord("", """

    """);
    
    [Test]
    public void LookupN() => CheckWord("", """

    """);
    
    [Test]
    public void LookupO() => CheckWord("", """

    """);
    
    [Test]
    public void LookupP() => CheckWord("", """

    """);
    
    [Test]
    public void LookupQ() => CheckWord("", """

    """);
    
    [Test]
    public void LookupR() => CheckWord("", """

    """);
    
    [Test]
    public void LookupS() => CheckWord("", """

    """);
    
    [Test]
    public void LookupT() => CheckWord("", """

    """);
    
    [Test]
    public void LookupU() => CheckWord("", """

    """);
    
    [Test]
    public void LookupV() => CheckWord("", """

    """);
    
    [Test]
    public void LookupW() => CheckWord("", """

    """);
    
    [Test]
    public void LookupX() => CheckWord("", """

    """);
    
    [Test]
    public void LookupY() => CheckWord("", """

    """);
    
    [Test]
    public void LookupZ() => CheckWord("", """

    """);
    */
    
    private static LatinDictionary? _normal;
    private static LatinDictionary? _extended;

    public static void LoadDictionaries()
    {
        if (_normal is not null && _extended is not null) return;
        
        _normal = new LatinDictionary();
        _extended = new LatinDictionary(new LatinDictionarySettings()
        {
            UseExtendedLookupTable = true
        }, 
            LatinDictionary.CanonicalDataSource
        );
    }
    
    public static void CheckWord(string word, string expected)
    {
        if (_normal is null || _extended is null)
        {
            Assert.Fail("Load the dictionaries in setup before running any tests.");
            return;
        }

        if (string.IsNullOrWhiteSpace(word)) return;
        
        var a = Program.LookupLatin(_normal, word, false).Trim();
        var b = Program.LookupLatin(_extended, word, false).Trim();
        
        Assert.Multiple(() =>
        {
            Assert.That(b, Is.EqualTo(a), "Normal and extended lookup should be the same");
            Assert.That(a, Contains.Substring(expected.Trim()));
        });
    }

    public static void CheckNotFound(string word)
    {
        if (_normal is null || _extended is null)
        {
            Assert.Fail("Load the dictionaries in setup before running any tests.");
            return;
        }
        
        var a = _normal.LookupLatinForm(word);
        var b = _extended.LookupLatinForm(word);
        
        Assert.Multiple(() =>
        {
            Assert.That(a, Is.Empty);
            Assert.That(b, Is.Empty);
        });
    }

    public static void CheckEnglish(string word, string expected)
    {
        if (_normal is null || _extended is null)
        {
            Assert.Fail("Load the dictionaries in setup before running any tests.");
            return;
        }
        
        var a = Program.LookupEnglish(_normal, word);
        var b = Program.LookupEnglish(_extended, word);
        
        Assert.That(a, Is.EqualTo(b), "Normal and extended lookup should be the same");
        Assert.That(a, Contains.Substring(expected));
    }
}