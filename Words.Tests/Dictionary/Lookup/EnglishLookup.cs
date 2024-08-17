namespace Words.Tests.Dictionary.Lookup;

public class EnglishLookup
{
    [Test]
    public void LookupA() => CheckEnglish("praise", "laud.o laud.are laudav.i laudat.us");

    [Test]
    public void LookupB() => CheckEnglish("worship", "or.o or.are orav.i orat.us");

    [Test]
    public void LookupC() => CheckEnglish("king", "rex. reg.is");

    [Test]
    public void LookupD() => CheckEnglish("horse", "equ.us equ.i");
    
    [Test]
    public void LookupE() => CheckEnglish("throw", "jaci.o jac.ere jec.i jact.us");
}