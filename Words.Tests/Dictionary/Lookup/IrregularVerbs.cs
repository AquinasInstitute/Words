namespace Words.Tests.Dictionary.Lookup;

public class IrregularVerbs
{
    [Test]
    public void LookupA() => CheckWord("volo", """
    [Verb] [Unknown] vol.o vel.le volu.i - : wish, want, prefer; be willing, will;
        vol.o - (6, 2) [Present Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupB() => CheckWord("vis", """
    [Unknown] ???
        [Verb] vis - (6, 2) [Present Active Indicative Second Person Singular] => be willing; wish;
    """);
    
    [Test]
    public void LookupC() => CheckWord("volumus", """
    [Verb] [Unknown] vol.o vel.le volu.i - : wish, want, prefer; be willing, will;
        vol.umus - (6, 2) [Present Active Indicative First Person Plural]
    """);
    
    [Test]
    public void LookupD() => CheckWord("nolo", """
    [Verb] [Unknown] nol.o nol.le nolu.i - : be unwilling; wish not to; refuse to;
        nol.o - (6, 2) [Present Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupE() => CheckWord("malunt", """
    [Verb] [Unknown] mal.o mal.le malu.i - : prefer; incline toward, wish rather;
        mal.unt - (6, 2) [Present Active Indicative Third Person Plural]
    """);
    
    [Test]
    public void LookupF() => CheckWord("fert", """
    [Verb] [Unknown] fer.o fer.re tul.i lat.us : bring, bear; tell/speak of; consider; carry off, win, receive, produce; get;
        fer.t - (3, 2) [Present Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupG() => CheckWord("do", """
    [Verb] [Transitive] d.o d.are ded.i dat.us : give; dedicate; sell; pay; grant/bestow/impart/offer/lend; devote; allow; make; surrender/give over; send to die; ascribe/attribute; give birth/produce; utter;
        d.o - (1, 1) [Present Active Indicative First Person Singular]
    """);
}