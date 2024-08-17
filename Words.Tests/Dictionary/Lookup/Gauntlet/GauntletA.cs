namespace Words.Tests.Dictionary.Lookup.Gauntlet;

public class GauntletA
{
    [Test]
    public void LookupA() => CheckWord("at", """
    [Conjunction]  at : but, but on the other hand; on the contrary; while, whereas; but yet; at least;
        at
    """);
    
    [Test]
    public void LookupB() => CheckWord("regina", """
    [Noun]  regin.a regin.ae : queen;
        regin.a - (1, 1) [Singular Nominative Common]
        regin.a - (1, 1) [Singular Vocative Common]
        regin.a - (1, 1) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupC() => CheckWord("gravi", """
    [Adjective]  grav.is gravi.or gravissi.mus : heavy; painful; important; serious; pregnant; grave, oppressive, burdensome;
        grav.i - (3, 2) [Positive Singular Dative Unknown]
        grav.i - (3, 2) [Positive Singular Ablative Unknown]
    """);
    
    [Test]
    public void LookupD() => CheckWord("iamdudum", """
    [Adverb]  jamdudum : long ago/before/since; a long time ago; this long time; immediately, at once;
        jamdudum
    """);
    
    [Test]
    public void LookupE() => CheckWord("saucia", """
    [Adjective]  sauci.us sauci.a sauci.um : wounded; ill, sick;
        sauci.a - (1, 1) [Positive Singular Nominative Feminine]
        sauci.a - (1, 1) [Positive Singular Ablative Feminine]
        sauci.a - (1, 1) [Positive Singular Vocative Feminine]
        sauci.a - (1, 1) [Positive Plural Nominative Neuter]
        sauci.a - (1, 1) [Positive Plural Accusative Neuter]
        sauci.a - (1, 1) [Positive Plural Vocative Neuter]
    """);
    
    [Test]
    public void LookupF() => CheckWord("saucia", """
    [Verb] [Unknown] sauci.o sauci.are sauciav.i sauciat.us : wound, hurt; gash, stab;
        sauci.a - (1, 1) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupG() => CheckWord("cura", """
    [Noun]  cur.a cur.ae : concern, worry, anxiety, trouble; attention, care, pains, zeal; cure, treatment; office/task/responsibility/post; administration, supervision; command (army);
        cur.a - (1, 1) [Singular Nominative Common]
        cur.a - (1, 1) [Singular Vocative Common]
        cur.a - (1, 1) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupH() => CheckWord("cura", """
    [Verb] [Unknown] cur.o cur.are curav.i curat.us : arrange/see/attend to; take care of; provide for; worry/care about; heal/cure; undertake; procure; regard w/anxiety/interest; take trouble/interest; desire;
        cur.a - (1, 1) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupI() => CheckWord("volnus", """
    [Noun]  volnus. volner.is : wound; mental/emotional hurt; injury to one's interests; wound of love;
        volnus. - (3, 2) [Singular Accusative Neuter]
        volnus. - (3, 2) [Singular Nominative Unknown]
        volnus. - (3, 2) [Singular Vocative Unknown]
    """);
    
    [Test]
    public void LookupJ() => CheckWord("alit", """
    [Verb] [Transitive] al.o al.ere alu.i alit.us : feed, nourish, rear, nurse, suckle; cherish; support, maintain, develop;
        al.it - (3, 1) [Present Active Indicative Third Person Singular]
    [Verb] [Transitive] al.o al.ere alu.i alt.us : feed, nourish, rear, nurse, suckle; cherish; support, maintain, develop;
        al.it - (3, 1) [Present Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupK() => CheckWord("venis", """
    [Noun]  ven.a ven.ae : blood-vessel, vein; artery; pulse; fissure, pore, cavity; vein of ore/talent;
        ven.is - (1, 1) [Plural Locative Common]
        ven.is - (1, 1) [Plural Dative Common]
        ven.is - (1, 1) [Plural Ablative Common]
    """);
    
    [Test]
    public void LookupL() => CheckWord("venis", """
    [Noun]  ven.um ven.i : sale, purchase; (only sg. ACC/DAT w/dare); [venum dare => put up for sale];
        ven.is - (2, 2) [Plural Locative Unknown]
        ven.is - (2, 2) [Plural Dative Unknown]
        ven.is - (2, 2) [Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupM() => CheckWord("venis", """
    [Verb] [Unknown] vene.o veni.re veniv.i venit.us : go for sale, be sold (as slave), be disposed of for (dishonorable/venal) gain;
        veni.s - (6, 1) [Present Active Indicative Second Person Singular]
    """);
    
    [Test]
    public void LookupN() => CheckWord("venis", """
    [Verb] [Unknown] veni.o ven.ire ven.i vent.us : come;
        ven.is - (3, 4) [Present Active Indicative Second Person Singular]
    """);
    
    [Test]
    public void LookupP() => CheckWord("caeco", """
    [Noun]  caec.us caec.i : blind person;
        caec.o - (2, 1) [Singular Dative Unknown]
        caec.o - (2, 1) [Singular Ablative Unknown]
    """);
    
    [Test]
    public void LookupQ() => CheckWord("caeco", """
    [Verb] [Unknown] caec.o caec.are caecav.i caecat.us : blind; obscure, confuse, hide; morally blind; [stu ~ => throw dust, deceive];
        caec.o - (1, 1) [Present Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupR() => CheckWord("caeco", """
    [Adjective]  caec.us caeci.or caecissi.mus : blind; unseeing; dark, gloomy, hidden, secret; aimless, confused, random; rash;
        caec.o - (1, 1) [Positive Singular Dative Masculine]
        caec.o - (1, 1) [Positive Singular Dative Neuter]
        caec.o - (1, 1) [Positive Singular Ablative Masculine]
        caec.o - (1, 1) [Positive Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupS() => CheckWord("carpitur", """
    [Verb] [Transitive] carp.o carp.ere carps.i carpt.us : seize/pick/pluck/gather/browse/tear off; graze/crop; tease/pull out/card (wool); separate/divide, tear down; carve; despoil/fleece; pursue/harry; consume/erode;
        carp.itur - (3, 1) [Present Passive Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupT() => CheckWord("igni", """
    [Verb] [Unknown] igni.o ign.ire igniv.i ignit.us : ignite; make red-hot;
        ign.i - (3, 4) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupU() => CheckWord("igni", """
    [Noun]  ignis. ign.is : fire, brightness; passion, glow of passion;
        ign.i - (3, 3) [Singular Ablative Common]
        ign.i - (3, 3) [Singular Locative Unknown]
        ign.i - (3, 3) [Singular Dative Unknown]
    """);
    
    [Test]
    public void LookupV() => CheckWord("multa", """
    [Noun]  mult.a mult.ae : fine; penalty; penalty involving property (livestock, later money);
        mult.a - (1, 1) [Singular Nominative Common]
        mult.a - (1, 1) [Singular Vocative Common]
        mult.a - (1, 1) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupW() => CheckWord("multa", """
    [Noun]  mult.um mult.i : many things (pl.); much; many;
        mult.a - (2, 2) [Plural Nominative Neuter]
        mult.a - (2, 2) [Plural Vocative Neuter]
        mult.a - (2, 2) [Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupX() => CheckWord("multa", """
    [Verb] [Transitive] mult.o mult.are multav.i multat.us : punish, fine; extract as forfeit; sentence to pay;
        mult.a - (1, 1) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupY() => CheckWord("multa", """
    [Adjective]  mult.us mult.a mult.um : much, many, great, many a; large, intense, assiduous; tedious;
        mult.a - (1, 1) [Positive Singular Nominative Feminine]
        mult.a - (1, 1) [Positive Singular Ablative Feminine]
        mult.a - (1, 1) [Positive Singular Vocative Feminine]
        mult.a - (1, 1) [Positive Plural Nominative Neuter]
        mult.a - (1, 1) [Positive Plural Accusative Neuter]
        mult.a - (1, 1) [Positive Plural Vocative Neuter]
    """);
    
    [Test]
    public void LookupZ() => CheckWord("multa", """
    [Noun]  mult.ae mult.ae : many women (pl.);
        mult.a - (1, 1) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupZA() => CheckWord("viri", """
    [Noun]  vir.us vir.i : venom (sg.), poisonous secretion of snakes/creatures/plants; acrid element;
        vir.i - (2, 1) [Singular Genitive Unknown]
        vir.i - (2, 1) [Singular Locative Unknown]
        vir.i - (2, 1) [Plural Nominative Common]
        vir.i - (2, 1) [Plural Vocative Common]
    """);
    
    [Test]
    public void LookupZB() => CheckWord("viri", """
    [Noun]  vir.um vir.i : virus;
        vir.i - (2, 2) [Singular Genitive Neuter]
        vir.i - (2, 2) [Singular Locative Unknown]
        vir.i - (2, 2) [Plural Nominative Common]
        vir.i - (2, 2) [Plural Vocative Common]
    """);
    
    [Test]
    public void LookupZC() => CheckWord("viri", """
    [Noun]  vir. vir.i : man; husband; hero; person of courage, honor, and nobility;
        vir.i - (2, 3) [Singular Genitive Unknown]
        vir.i - (2, 3) [Singular Locative Unknown]
        vir.i - (2, 3) [Plural Nominative Common]
        vir.i - (2, 3) [Plural Vocative Common]
    """);
    
    [Test]
    public void LookupZD() => CheckWord("viri", """
    [Noun]  vis. vir.is : strength (bodily) (pl.), force, power, might, violence; resources; large body;
        vir.i - (3, 3) [Singular Ablative Common]
        vir.i - (3, 3) [Singular Locative Unknown]
        vir.i - (3, 3) [Singular Dative Unknown]
    """);
    
    [Test]
    public void LookupZE() => CheckWord("virtus", """
    [Noun]  virtus. virtut.is : strength/power; courage/bravery; worth/manliness/virtue/character/excellence; army; host; mighty works (pl.); class of Angels; [Dominus ~ => Lord of hosts];
        virtus. - (3, 1) [Singular Nominative Unknown]
        virtus. - (3, 1) [Singular Vocative Unknown]
    """);
    
    [Test]
    public void LookupZF() => CheckWord("animo", """
    [Noun]  anim.us anim.i : mind; intellect; soul; feelings; heart; spirit, courage, character, pride; air;
        anim.o - (2, 1) [Singular Dative Unknown]
        anim.o - (2, 1) [Singular Ablative Unknown]
    """);
    
    [Test]
    public void LookupZG() => CheckWord("animo", """
    [Verb] [Transitive] anim.o anim.are animav.i animat.us : animate, give/bring life; revive, refresh; rouse, animate; inspire; blow;
        anim.o - (1, 1) [Present Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupZH() => CheckWord("multusque", """
    [Adjective]  mult.us mult.a mult.um : much, many, great, many a; large, intense, assiduous; tedious;
        mult.us - (1, 1) [Positive Singular Nominative Masculine]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
        mult [Positive]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
            + [Adjective -> Adverb] Suffix us - -ly;
        mult [Comparative]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
            + [Adjective -> Adverb] Suffix us - more -ly; -lier;
    """);
    
    [Test]
    public void LookupZI() => CheckWord("recursat", """
    [Verb] [Unknown] recurs.o recurs.are recursav.i recursat.us : keep rebounding/recoiling; keep recurring to the mind;
        recurs.at - (1, 1) [Present Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupZJ() => CheckWord("gentis", """
    [Noun]  gens. gent.is : tribe, clan; nation, people; Gentiles;
        gent.is - (3, 3) [Plural Nominative Common]
        gent.is - (3, 3) [Plural Accusative Common]
        gent.is - (3, 3) [Singular Genitive Unknown]
    """);
    
    [Test]
    public void LookupZK() => CheckWord("honos", """
    [Noun]  honos. honor.is : honor; respect/regard; mark of esteem, reward; dignity/grace; public office;
        honos. - (3, 1) [Singular Nominative Unknown]
        honos. - (3, 1) [Singular Vocative Unknown]
    """);
    
    [Test]
    public void LookupZL() => CheckWord("haerent", """
    [Verb] [Unknown] haer.eo haer.ere haes.i haes.us : stick, adhere, cling to; hesitate; be in difficulties (sticky situation?);
        haer.ent - (2, 1) [Present Active Indicative Third Person Plural]
    """);
    
    [Test]
    public void LookupZM() => CheckWord("infixi", """
    [Verb] [Unknown] infig.o infig.ere infix.i infix.us : fasten (on), fix, implant, affix; impose; drive/thrust in;
        infix.i - (3, 1) [Perfect Active Indicative First Person Singular]
        [Participle] infix.i - (0, 0) [Perfect Passive Genitive Masculine]
        [Participle] infix.i - (0, 0) [Perfect Passive Nominative Masculine]
        [Participle] infix.i - (0, 0) [Perfect Passive Vocative Masculine]
        [Participle] infix.i - (0, 0) [Perfect Passive Genitive Neuter]
    """);
    
    [Test]
    public void LookupZN() => CheckWord("pectore", """
    [Noun]  pectus. pector.is : breast, heart; feeling, soul, mind;
        pector.e - (3, 2) [Singular Ablative Neuter]
        pector.e - (3, 2) [Singular Locative Unknown]
        pector.e - (3, 2) [Singular Dative Unknown]
        pector.e - (3, 2) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupZO() => CheckWord("voltus", """
    [Noun]  volt.us volt.us : face, expression; looks;
        volt.us - (4, 1) [Singular Nominative Common]
        volt.us - (4, 1) [Singular Vocative Common]
        volt.us - (4, 1) [Singular Genitive Common]
        volt.us - (4, 1) [Plural Nominative Common]
        volt.us - (4, 1) [Plural Vocative Common]
        volt.us - (4, 1) [Plural Accusative Common]
    """);
    
    [Test]
    public void LookupZP() => CheckWord("verbaque", """
    [Noun]  verb.um verb.i : word; proverb; [verba dare alicui => cheat/deceive someone];
        verb.a - (2, 2) [Plural Nominative Neuter]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
        verb.a - (2, 2) [Plural Vocative Neuter]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
        verb.a - (2, 2) [Plural Accusative Neuter]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
    """);
    
    [Test]
    public void LookupZQ() => CheckWord("nec", """
    [Adverb]  nec : nor; and not, not, neither, not even;
        nec
    """);
    
    [Test]
    public void LookupZR() => CheckWord("nec", """
    [Conjunction]  nec : nor, and..not; not..either, not even;
        nec
    """);
    
    [Test]
    public void LookupZS() => CheckWord("placidam", """
    [Adjective]  placid.us placid.a placid.um : gentle, calm, mild, peaceful, placid;
        placid.am - (1, 1) [Positive Singular Accusative Feminine]
    """);
    
    [Test]
    public void LookupZT() => CheckWord("membris", """
    [Noun]  membr.um membr.i : member, limb, organ; (esp.) male genital member; apartment, room; section;
        membr.is - (2, 2) [Plural Locative Unknown]
        membr.is - (2, 2) [Plural Dative Unknown]
        membr.is - (2, 2) [Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupZU() => CheckWord("dat", """
    [Verb] [Transitive] d.o d.are ded.i dat.us : give; dedicate; sell; pay; grant/bestow/impart/offer/lend; devote; allow; make; surrender/give over; send to die; ascribe/attribute; give birth/produce; utter;
        d.at - (1, 1) [Present Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupZV() => CheckWord("quietem", """
    [Noun]  quies. quiet.is : quiet, calm, rest, peace; sleep;
        quiet.em - (3, 1) [Singular Accusative Common]
    """);
    
    [Test]
    public void LookupZW() => CheckWord("postera", """
    [Adjective]  poster.us posteri.or postre.mus : coming after, following, next; COMP next in order, latter; SUPER last/hindmost;
        poster.a - (1, 1) [Positive Singular Nominative Feminine]
        poster.a - (1, 1) [Positive Singular Ablative Feminine]
        poster.a - (1, 1) [Positive Singular Vocative Feminine]
        poster.a - (1, 1) [Positive Plural Nominative Neuter]
        poster.a - (1, 1) [Positive Plural Accusative Neuter]
        poster.a - (1, 1) [Positive Plural Vocative Neuter]
    """);
    
    [Test]
    public void LookupZX() => CheckWord("phoebea", """
    [Noun]  phoeb.e phoeb.es : Diana; moon goddess;
        phoeb.a - (1, 1) [Positive Singular Nominative Feminine]
            + [Noun -> Adjective] Suffix e - make of;
        phoeb.a - (1, 1) [Positive Singular Ablative Feminine]
            + [Noun -> Adjective] Suffix e - make of;
        phoeb.a - (1, 1) [Positive Singular Vocative Feminine]
            + [Noun -> Adjective] Suffix e - make of;
        phoeb.a - (1, 1) [Positive Plural Nominative Neuter]
            + [Noun -> Adjective] Suffix e - make of;
        phoeb.a - (1, 1) [Positive Plural Accusative Neuter]
            + [Noun -> Adjective] Suffix e - make of;
        phoeb.a - (1, 1) [Positive Plural Vocative Neuter]
            + [Noun -> Adjective] Suffix e - make of;
    """);
    
    [Test]
    public void LookupZY() => CheckWord("lustrabat", """
    [Verb] [Unknown] lustr.o lustr.are lustrav.i lustrat.us : purify cermonially (w/procession), cleanse by sacrifice, expiate;
        lustr.abat - (1, 1) [Imperfect Active Indicative Third Person Singular]
    [Verb] [Unknown] lustr.o lustr.are lustrav.i lustrat.us : review/inspect, look around, seek; illuminate; traverse/roam/move over/through;
        lustr.abat - (1, 1) [Imperfect Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupZZ() => CheckWord("lampade", """
    [Noun]  lampas. lampad.is : lamp/lantern; light/torch/flame/flambeau/link; firebrand; meteor (like torch);
        lampad.e - (3, 1) [Singular Locative Unknown]
        lampad.e - (3, 1) [Singular Dative Unknown]
        lampad.e - (3, 1) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupZZA() => CheckWord("lampade", """
    [Noun]  lampas. lampad.os : lamp/lantern; light/torch/flame/flambeau/link; firebrand; meteor (like torch);
        lampad.e - (3, 7) [Singular Ablative Neuter]
        lampad.e - (3, 7) [Singular Locative Unknown]
        lampad.e - (3, 7) [Singular Dative Unknown]
        lampad.e - (3, 7) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupZZB() => CheckWord("terras", """
    [Noun]  terr.a terr.ae : earth, land, ground; country, region;
        terr.as - (1, 1) [Singular Nominative Masculine]
        terr.as - (1, 1) [Plural Accusative Common]
    """);
    
    [Test]
    public void LookupZZC() => CheckWord("umentemque", """
    [Verb] [Unknown] um.eo um.ere - - : be wet; be moist;
        [Participle] um.entem - (2, 0) [Present Active Accusative Common]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
        um.em - (3, 1) [Positive Singular Accusative Common]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
            + [Verb -> Adjective] Suffix ent - -ing, makes ADJ of verb, equivalent to PRES ACTIVE PPL ('e' stem is for V 2/3);
    """);
    
    [Test]
    public void LookupZZD() => CheckWord("umentemque", """
    [Adjective]  umens. umens. umens. : moist, wet;
        ument.em - (3, 1) [Positive Singular Accusative Common]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
    """);
    
    [Test]
    public void LookupZZE() => CheckWord("aurora", """
    [Noun]  auror.a auror.ae : dawn, daybreak, sunrise; goddess of the dawn; Orient/East, peoples of the East;
        auror.a - (1, 1) [Singular Nominative Common]
        auror.a - (1, 1) [Singular Vocative Common]
        auror.a - (1, 1) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupZZF() => CheckWord("aurora", """
    [Verb] [Intransitive] auror.o auror.are aurorav.i aurorat.us : shine like the sunrise;
        auror.a - (1, 1) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupZZG() => CheckWord("polo", """
    [Noun]  pol.us pol.i : pole (e.g., north pole), end of an axis; heaven, sky, celestial vault;
        pol.o - (2, 1) [Singular Dative Unknown]
        pol.o - (2, 1) [Singular Ablative Unknown]
    """);
    
    [Test]
    public void LookupZZH() => CheckWord("polo", """
    [Noun]  pol.um pol.i : little; small; (only a) small amount/quantity; a little bit; trifle;
        pol.o - (2, 2) [Singular Dative Unknown]
        pol.o - (2, 2) [Singular Ablative Unknown]
    """);
    
    [Test]
    public void LookupZZI() => CheckWord("polo", """
    [Adjective]  pol.us pol.a pol.um : little; small; (only a) small amount/quantity of/little bit of;
        pol.o - (1, 1) [Positive Singular Dative Masculine]
        pol.o - (1, 1) [Positive Singular Dative Neuter]
        pol.o - (1, 1) [Positive Singular Ablative Masculine]
        pol.o - (1, 1) [Positive Singular Ablative Neuter]
    """);
    
    [Test]
    public void LookupZZJ() => CheckWord("dimoverat", """
    [Verb] [Transitive] dimov.eo dimov.ere dimov.i dimot.us : put/set aside, dismiss, divert; displace/remove; exercise, move about; separate/divide; cleave; make a parting in/between;, part; disperse;
        dimov.erat - (2, 1) [Pluperfect Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupZZK() => CheckWord("umbram", """
    [Noun]  umbr.a umbr.ae : shade; ghost; shadow;
        umbr.am - (1, 1) [Singular Accusative Common]
    """);
    
    [Test]
    public void LookupZZL() => CheckWord("cum", """
    [Adverb]  cum : when, at the time/on each occasion/in the situation that; after; since/although; as soon; while, as (well as); whereas, in that, seeing that; on/during which;
        cum
    """);
    
    [Test]
    public void LookupZZM() => CheckWord("cum", """
    [Preposition]  cum : with, together/jointly/along/simultaneous with, amid; supporting; attached; under command/at the head of; having/containing/including; using/by means of;
        cum
    """);
    
    [Test]
    public void LookupZZN() => CheckWord("sic", """
    [Adverb]  sic : thus, so; as follows; in another way; in such a way;
        sic
    """);
    
    [Test]
    public void LookupZZO() => CheckWord("unanimam", """
    [Adjective]  unanim.us unanim.a unanim.um : acting in accord; sharing a single purpose; harmonious (L+S); unanimous;
        unanim.am - (1, 1) [Positive Singular Accusative Feminine]
    """);
    
    [Test]
    public void LookupZZP() => CheckWord("adloquitur", """
    [Verb] [Deponent] adloqu.or adloqu.i - adlocut.us : speak to (friendly); address, harangue, make a speech (to); call on; console;
        adloqu.itur - (3, 1) [Present Passive Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupZZQ() => CheckWord("male", """
    [Noun]  mal.us mal.i : mast; beam; tall pole, upright pole; standard, prop, staff;
        mal.e - (2, 1) [Singular Vocative Unknown]
        mal.e - (2, 1) [Plural Nominative Neuter]
        mal.e - (2, 1) [Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupZZR() => CheckWord("male", """
    [Noun]  mal.us mal.i : apple tree;
        mal.e - (2, 1) [Singular Vocative Unknown]
        mal.e - (2, 1) [Plural Nominative Neuter]
        mal.e - (2, 1) [Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupZZS() => CheckWord("male", """
    [Adjective]  mal.us mal.a mal.um : bad, evil, wicked; ugly; unlucky;
        mal.e - (1, 1) [Positive Singular Vocative Masculine]
    """);
    
    [Test]
    public void LookupZZT() => CheckWord("male", """
    [Adverb]  male : badly, ill, wrongly, wickedly, unfortunately; extremely;
        male
    """);
    
    [Test]
    public void LookupZZU() => CheckWord("sana", """
    [Adjective]  san.us san.a san.um : sound; healthy; sensible; sober; sane;
        san.a - (1, 1) [Positive Singular Nominative Feminine]
        san.a - (1, 1) [Positive Singular Ablative Feminine]
        san.a - (1, 1) [Positive Singular Vocative Feminine]
        san.a - (1, 1) [Positive Plural Nominative Neuter]
        san.a - (1, 1) [Positive Plural Accusative Neuter]
        san.a - (1, 1) [Positive Plural Vocative Neuter]
    """);
    
    [Test]
    public void LookupZZV() => CheckWord("sana", """
    [Verb] [Unknown] san.o san.are sanav.i sanat.us : cure, heal; correct; quiet;
        san.a - (1, 1) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupZZW() => CheckWord("sororem", """
    [Noun]  soror. soror.is : sister; (applied also to half sister, sister-in-law, and mistress!);
        soror.em - (3, 1) [Singular Accusative Common]
    """);
    
    [Test]
    public void LookupZZX() => CheckWord("anna", """
    [Noun]  ann.us ann.i : year (astronomical/civil); age, time of life; year's produce; circuit, course;
        ann.a - (2, 1) [Plural Nominative Neuter]
        ann.a - (2, 1) [Plural Vocative Neuter]
        ann.a - (2, 1) [Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupZZY() => CheckWord("anna", """
    [Verb] [Transitive] ann.o ann.are annav.i annat.us : pass/live through a year;
        ann.a - (1, 1) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupZZZ() => CheckWord("anna", """
    [Verb] [Intransitive] ann.o ann.are annav.i annat.us : swim to/towards, approach by swimming; sail to/towards; brought by sea (goods);
        ann.a - (1, 1) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupZZZA() => CheckWord("soror", """
    [Noun]  soror. soror.is : sister; (applied also to half sister, sister-in-law, and mistress!);
        soror. - (3, 1) [Singular Nominative Unknown]
        soror. - (3, 1) [Singular Vocative Unknown]
    """);
    
    [Test]
    public void LookupZZZB() => CheckWord("quae", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.ae - (1, 0) [Relative Plural Nominative Feminine]
        qu.ae - (1, 0) [Relative Singular Nominative Feminine]
    """);
    
    [Test]
    public void LookupZZZC() => CheckWord("quae", """
    [Pronoun]  qu.is qu.is qu.id : who/what/which?, what/which one/man/person/thing? what kind/type of?;
        qu.ae - (1, 0) [Interrogative Plural Nominative Feminine]
    """);
    
    [Test]
    public void LookupZZZD() => CheckWord("quae", """
    [Pronoun]  qu.i qu.ae qu.od : who/whatever, everyone who, all that, anything that;
        qu.ae - (1, 0) [Indefinite Plural Nominative Feminine]
        qu.ae - (1, 0) [Indefinite Singular Nominative Feminine]
    """);
    
    [Test]
    public void LookupZZZE() => CheckWord("quae", """
    [Pronoun]  qu.i qu.a qu.od : any; anyone/anything, any such; unspecified some; (after si/sin/sive/ne);
        qu.ae - (1, 0) [Adjectival Plural Nominative Feminine]
        qu.ae - (1, 0) [Adjectival Singular Nominative Feminine]
        qu.ae - (1, 0) [Adjectival Plural Nominative Neuter]
        qu.ae - (1, 0) [Adjectival Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupZZZF() => CheckWord("me", """
    [Pronoun]  ego. m.ei : I, me (PERS); myself (REFLEX);
        m.e - (5, 1) [Personal Singular Accusative Common]
        m.e - (5, 1) [Personal Singular Ablative Common]
    """);
    
    [Test]
    public void LookupZZZG() => CheckWord("suspensam", """
    [Verb] [Unknown] suspend.o suspend.ere suspend.i suspens.us : hang up, suspend;
        [Participle] suspens.am - (0, 0) [Perfect Passive Accusative Feminine]
    """);
    
    [Test]
    public void LookupZZZH() => CheckWord("suspensam", """
    [Adjective]  suspens.us suspens.a suspens.um : in a state of anxious uncertainty or suspense, light;
        suspens.am - (1, 1) [Positive Singular Accusative Feminine]
    """);
    
    [Test]
    public void LookupZZZI() => CheckWord("insomnia", """
    [Adjective]  insomn.is insomn.is insomn.e : sleepless;
        insomn.ia - (3, 2) [Positive Plural Nominative Neuter]
        insomn.ia - (3, 2) [Positive Plural Accusative Neuter]
        insomn.ia - (3, 2) [Positive Plural Vocative Neuter]
    """);
    
    [Test]
    public void LookupZZZJ() => CheckWord("insomnia", """
    [Noun]  insomni.us insomni. : wakefulness; vision, dream;
        insomni.a - (2, 4) [Plural Nominative Neuter]
        insomni.a - (2, 4) [Plural Vocative Neuter]
        insomni.a - (2, 4) [Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupZZZK() => CheckWord("terrent", """
    [Verb] [Unknown] terr.eo terr.ere terru.i territ.us : frighten, scare, terrify, deter;
        terr.ent - (2, 1) [Present Active Indicative Third Person Plural]
    """);
    
    [Test]
    public void LookupZZZL() => CheckWord("quis", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.is - (1, 0) [Relative Plural Dative Unknown]
        qu.is - (1, 0) [Relative Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupZZZM() => CheckWord("novus", """
    [Adjective]  nov.us novi.or novissi.mus : new, fresh, young; unusual, extraordinary;  (novae res, f. pl. = revolution);
        nov.us - (1, 1) [Positive Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupZZZN() => CheckWord("hic", """
    [Adverb]  hic : here, in this place; in the present circumstances;
        hic
    """);
    
    [Test]
    public void LookupZZZO() => CheckWord("hic", """
    [Pronoun]  h.ic h.aec h.oc : this; these (pl.); (also DEMONST);
        h.ic - (3, 1) [Adjectival Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupZZZP() => CheckWord("nostris", """
    [Noun]  noster. nostr.i : our men (pl.);
        nostr.is - (2, 3) [Plural Locative Unknown]
        nostr.is - (2, 3) [Plural Dative Unknown]
        nostr.is - (2, 3) [Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupZZZQ() => CheckWord("nostris", """
    [Adjective]  noster. noster.a noster.um : our;
        nostr.is - (1, 2) [Positive Plural Dative Unknown]
        nostr.is - (1, 2) [Positive Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupZZZR() => CheckWord("successit", """
    [Verb] [Unknown] succed.o succed.ere success.i success.us : climb; advance; follow; succeed in;
        success.it - (3, 1) [Perfect Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupZZZS() => CheckWord("sedibus", """
    Noun]  sedes. sed.is : seat; home, residence; settlement, habitation; chair;
        sed.ibus - (3, 3) [Plural Locative Unknown]
        sed.ibus - (3, 3) [Plural Dative Unknown]
        sed.ibus - (3, 3) [Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupZZZT() => CheckWord("hospes", """
    [Noun]  hospes. hospit.is : host; guest, visitor, stranger; soldier in billets; one who billets soldiers;
        hospes. - (3, 1) [Singular Nominative Unknown]
        hospes. - (3, 1) [Singular Vocative Unknown]
    """);
    
    [Test]
    public void LookupZZZU() => CheckWord("hospes", """
    [Adjective]  hospes. hospes. hospes. : of relation between host and guest; that hosts; that guests; foreign, alien;
        hospes. - (3, 1) [Positive Singular Nominative Unknown]
        hospes. - (3, 1) [Positive Singular Vocative Unknown]
        hospes. - (3, 1) [Positive Singular Accusative Neuter]
    """);
    
    [Test]
    public void LookupZZZV() => CheckWord("quem", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.em - (1, 0) [Relative Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupZZZW() => CheckWord("sese", """
    [Pronoun]  - s.ui : him/her/it/ones-self; him/her/it; them (selves) (pl.); each other, one another;
        s.ese - (5, 4) [Reflexive Unknown Accusative Common]
        s.ese - (5, 4) [Reflexive Unknown Ablative Common]
    """);
    
    [Test]
    public void LookupZZZX() => CheckWord("ore", """
    [Verb] [Unknown] or.o or.ere - - : burn;
        or.e - (3, 1) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupZZZY() => CheckWord("ore", """
    [Noun]  os. or.is : mouth, speech, expression; face; pronunciation;
        or.e - (3, 2) [Singular Ablative Neuter]
        or.e - (3, 2) [Singular Locative Unknown]
        or.e - (3, 2) [Singular Dative Unknown]
        or.e - (3, 2) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupZZZZ() => CheckWord("quam", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.am - (1, 0) [Relative Singular Accusative Feminine]
    """);
    
    [Test]
    public void LookupZZZZA() => CheckWord("ferens", """
    [Verb] [Unknown] fer.o fer.re tul.i lat.us : bring, bear; tell/speak of; consider; carry off, win, receive, produce; get;
        [Participle] fer.ens - (3, 0) [Present Active Nominative Unknown]
        [Participle] fer.ens - (3, 0) [Present Active Vocative Unknown]
        [Participle] fer.ens - (3, 0) [Present Active Accusative Neuter]
    """);
    
    [Test]
    public void LookupZZZZB() => CheckWord("forti", """
    [Noun]  fors. fort.is : chance; luck, fortune; accident;
        fort.i - (3, 3) [Singular Ablative Common]
        fort.i - (3, 3) [Singular Locative Unknown]
        fort.i - (3, 3) [Singular Dative Unknown]
    """);
    
    [Test]
    public void LookupZZZZC() => CheckWord("forti", """
    [Adjective]  fort.is forti.or fortissi.mus : strong, powerful, mighty, vigorous, firm, steadfast, courageous, brave, bold;
        fort.i - (3, 2) [Positive Singular Dative Unknown]
        fort.i - (3, 2) [Positive Singular Ablative Unknown]
    """);
    
    [Test]
    public void LookupZZZZD() => CheckWord("pectore", """
    [Noun]  pectus. pector.is : breast, heart; feeling, soul, mind;
        pector.e - (3, 2) [Singular Ablative Neuter]
        pector.e - (3, 2) [Singular Locative Unknown]
        pector.e - (3, 2) [Singular Dative Unknown]
        pector.e - (3, 2) [Singular Ablative Common]
    """);
    
    [Test]
    public void LookupZZZZE() => CheckWord("armis", """
    [Noun]  arm.us arm.i : forequarter (of an animal), shoulder; upper arm; side, flank; shoulder cut meat;
        arm.is - (2, 1) [Plural Locative Unknown]
        arm.is - (2, 1) [Plural Dative Unknown]
        arm.is - (2, 1) [Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupZZZZF() => CheckWord("armis", """
    [Noun]  arm.um arm.i : arms (pl.), weapons, armor, shield; close fighting weapons; equipment; force;
        arm.is - (2, 2) [Plural Locative Unknown]
        arm.is - (2, 2) [Plural Dative Unknown]
        arm.is - (2, 2) [Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupZZZZG() => CheckWord("credo", """
    [Verb] [Unknown] cred.o cred.ere credid.i credit.us : trust, entrust; commit/consign; believe, trust in, rely on, confide; suppose; lend (money) to, make loans/give credit; believe/think/accept as true/be sure;
        cred.o - (3, 1) [Present Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupZZZZH() => CheckWord("equidem", """
    [Adverb]  equidem : truly, indeed; for my part;
        equidem
    """);
    
    [Test]
    public void LookupZZZZI() => CheckWord("vana", """
    [Adjective]  van.us van.a van.um : empty, vain; false, untrustworthy;
        van.a - (1, 1) [Positive Singular Nominative Feminine]
        van.a - (1, 1) [Positive Singular Ablative Feminine]
        van.a - (1, 1) [Positive Singular Vocative Feminine]
        van.a - (1, 1) [Positive Plural Nominative Neuter]
        van.a - (1, 1) [Positive Plural Accusative Neuter]
        van.a - (1, 1) [Positive Plural Vocative Neuter]
    """);
    
    [Test]
    public void LookupZZZZJ() => CheckWord("fides", """
    [Noun]  fid.es fid.ei : faith, loyalty; honesty; credit; confidence, trust, belief; good faith;
        fid.es - (5, 1) [Singular Nominative Common]
        fid.es - (5, 1) [Singular Vocative Common]
        fid.es - (5, 1) [Plural Nominative Common]
        fid.es - (5, 1) [Plural Vocative Common]
        fid.es - (5, 1) [Plural Accusative Common]
    """);
    
    [Test]
    public void LookupZZZZK() => CheckWord("fides", """
    [Verb] [SemiDeponent] fid.o fid.ere - fis.us : trust (in), have confidence (in) (w/DAT or ABL);
        fid.es - (3, 1) [Future Active Indicative Second Person Singular]
    """);
    
    [Test]
    public void LookupZZZZL() => CheckWord("fides", """
    [Noun]  fides. fid.is : chord, instrument string; constellation Lyra; stringed instrument (pl.); lyre;
        fid.es - (3, 3) [Plural Accusative Common]
        fides. - (3, 3) [Singular Nominative Unknown]
        fides. - (3, 3) [Singular Vocative Unknown]
        fid.es - (3, 3) [Plural Nominative Common]
        fid.es - (3, 3) [Plural Vocative Common]
    """);
    
    [Test]
    public void LookupZZZZM() => CheckWord("genus", """
    [Noun]  gen.u gen.us : knee;
        gen.us - (4, 2) [Singular Genitive Neuter]
    """);
    
    [Test]
    public void LookupZZZZN() => CheckWord("genus", """
    [Noun]  genus. gener.is : birth/descent/origin; race/family/house/stock/ancestry; offspring/descent; noble birth; kind/sort/variety; class/rank; mode/method/style/fashion/way;
        genus. - (3, 2) [Singular Accusative Neuter]
        genus. - (3, 2) [Singular Nominative Unknown]
        genus. - (3, 2) [Singular Vocative Unknown]
    """);
    
    [Test]
    public void LookupZZZZO() => CheckWord("esse", """
    [Verb] [Transitive] ed.o ed.ere ed.i ess.us : eat/consume/devour; eat away (fire/water/disease); destroy; spend money on food;
        [Participle] ess.e - (0, 0) [Perfect Passive Vocative Masculine]
    [Verb] [Transitive] - es.se - - : eat/consume/devour; eat away (fire/water/disease); destroy; spend money on food;
        es.se - (7, 3) [Present Active Infinitive Unknown Person Unknown]
    """);
    
    [Test]
    public void LookupZZZZP() => CheckWord("esse", """
    [Verb] [ToBe] s.um .esse fu.i fut.urus : be; exist; (also used to form verb perfect passive tenses) with NOM PERF PPL
        .esse - (5, 1) [Present Active Infinitive Unknown Person Unknown]
    """);
    
    [Test]
    public void LookupZZZZQ() => CheckWord("esse", """
    [Verb] [Transitive] ed.o ed.ere ed.i ess.us : eat/consume/devour; eat away (fire/water/disease); destroy; spend money on food;
        [Participle] ess.e - (0, 0) [Perfect Passive Vocative Masculine]
    """);
    
    [Test]
    public void LookupZZZZR() => CheckWord("deorum", """
    Noun]  de.us de.i : God (Christian text); god; divine essence/being, supreme being; statue of god;
        de.orum - (2, 1) [Plural Genitive Unknown]
    """);
    
    [Test]
    public void LookupZZZZS() => CheckWord("degeneres", """
    [Adjective]  degener. degener. degener. : degenerate/base; inferior to ancestors; ignoble, unworthy, untrue, contemptible; low-born, of/belonging to inferior stock/breed/variety; soft/weak; softened;
        degener.es - (3, 1) [Positive Plural Nominative Common]
        degener.es - (3, 1) [Positive Plural Accusative Common]
        degener.es - (3, 1) [Positive Plural Vocative Common]
    """);
    
    [Test]
    public void LookupZZZZT() => CheckWord("degeneres", """
    [Verb] [Transitive] degener.o degener.are degenerav.i degenerat.us : be unworthy (of), fall short of the standard set by; cause deterioration in;
        degener.es - (1, 1) [Present Active Subjunctive Second Person Singular]
    """);
    
    [Test]
    public void LookupZZZZU() => CheckWord("degeneres", """
    [Verb] [Intransitive] degener.o degener.are degenerav.i degenerat.us : be inferior to ancestors/unworthy; deteriorate/decline; lower oneself; sink (to); fall away from/below the level; degenerate/revert (breeding);
        degener.es - (1, 1) [Present Active Subjunctive Second Person Singular]
    """);
    
    [Test]
    public void LookupZZZZV() => CheckWord("animos", """
    [Noun]  anim.us anim.i : mind; intellect; soul; feelings; heart; spirit, courage, character, pride; air;
        anim.os - (2, 1) [Singular Nominative Common]
        anim.os - (2, 1) [Plural Accusative Common]
    """);
    
    [Test]
    public void LookupZZZZW() => CheckWord("timor", """
    [Noun]  timor. timor.is : fear; dread;
        timor. - (3, 1) [Singular Nominative Unknown]
        timor. - (3, 1) [Singular Vocative Unknown]
    """);
    
    [Test]
    public void LookupZZZZX() => CheckWord("arguit", """
    [Verb] [Transitive] argu.o argu.ere argu.i argut.us : prove, argue, allege; disclose; accuse, complain of, charge, blame, convict;
        argu.it - (3, 1) [Present Active Indicative Third Person Singular]
        argu.it - (3, 1) [Perfect Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupZZZZY() => CheckWord("heu", """
    [Interjection]  heu : oh! ah! alas! (an expression of dismay or pain);
        heu
    """);
    
    [Test]
    public void LookupZZZZZ() => CheckWord("quibus", """
    [Pronoun]  qu.i qu.ae qu.od : who; that; which, what; of which kind/degree; person/thing/time/point that;
        qu.ibus - (1, 0) [Relative Plural Dative Unknown]
        qu.ibus - (1, 0) [Relative Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupZZZZZA() => CheckWord("ille", """
    [Pronoun]  ill.e ill.a ill.ud : that; those (pl.); also DEMONST; that person/thing; the well known; the former;
        ill.e - (6, 1) [Adjectival Singular Nominative Masculine]
    """);
    
    [Test]
    public void LookupZZZZZB() => CheckWord("iactatus", """
    [Verb] [Unknown] jact.o jact.are jactav.i jactat.us : throw away, throw out, throw, jerk about; disturb; boast, discuss;
        [Participle] jactat.us - (0, 0) [Perfect Passive Nominative Masculine]
    """);
    
    [Test]
    public void LookupZZZZZC() => CheckWord("fatis", """
    [Verb] [Deponent] f.or f.ari - fat.us : speak, talk; say;
        [Participle] fat.is - (0, 0) [Perfect Passive Dative Unknown]
        [Participle] fat.is - (0, 0) [Perfect Passive Ablative Unknown]
    """);
    
    [Test]
    public void LookupZZZZZD() => CheckWord("FATIS", """
    Noun]  fat.um fat.i : utterance, oracle; fate, destiny; natural term of life; doom, death, calamity;
        fat.is - (2, 2) [Plural Locative Unknown]
        fat.is - (2, 2) [Plural Dative Unknown]
        fat.is - (2, 2) [Plural Ablative Unknown]
    """);
    
    [Test]
    public void LookupZZZZZE() => CheckWord("bella", """
    [Noun]  bell.um bell.i : war, warfare; battle, combat, fight; (at/in) (the) war(s); military force, arms;
        bell.a - (2, 2) [Plural Nominative Neuter]
        bell.a - (2, 2) [Plural Vocative Neuter]
        bell.a - (2, 2) [Plural Accusative Neuter]
    """);
    
    [Test]
    public void LookupZZZZZF() => CheckWord("bella", """
    [Verb] [Intransitive] bell.o bell.are bellav.i bellat.us : fight, wage war, struggle; take part in war/battle/fight (also animals/games);
        bell.a - (1, 1) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupZZZZZG() => CheckWord("bella", """
    [Adjective]  bell.us belli.or bellissi.mus : pretty, handsome, charming, pleasant, agreeable, polite; nice, fine, excellent;
        bell.a - (1, 1) [Positive Singular Nominative Feminine]
        bell.a - (1, 1) [Positive Singular Ablative Feminine]
        bell.a - (1, 1) [Positive Singular Vocative Feminine]
        bell.a - (1, 1) [Positive Plural Nominative Neuter]
        bell.a - (1, 1) [Positive Plural Accusative Neuter]
        bell.a - (1, 1) [Positive Plural Vocative Neuter]
    """);
    
    [Test]
    public void LookupZZZZZH() => CheckWord("exhausta", """
    [Verb] [Unknown] exhauri.o exhaur.ire exhaus.i exhaust.us : draw out; drain, drink up, empty; exhaust, impoverish; remove; end;
        [Participle] exhaust.a - (0, 0) [Perfect Passive Nominative Feminine]
        [Participle] exhaust.a - (0, 0) [Perfect Passive Ablative Feminine]
        [Participle] exhaust.a - (0, 0) [Perfect Passive Vocative Feminine]
        [Participle] exhaust.a - (0, 0) [Perfect Passive Nominative Neuter]
        [Participle] exhaust.a - (0, 0) [Perfect Passive Accusative Neuter]
        [Participle] exhaust.a - (0, 0) [Perfect Passive Vocative Neuter]
    """);
    
    [Test]
    public void LookupZZZZZI() => CheckWord("exhausta", """
    [Adjective]  exhaust.us exhaust.a exhaust.um : exhausted;
        exhaust.a - (1, 1) [Positive Singular Nominative Feminine]
        exhaust.a - (1, 1) [Positive Singular Ablative Feminine]
        exhaust.a - (1, 1) [Positive Singular Vocative Feminine]
        exhaust.a - (1, 1) [Positive Plural Nominative Neuter]
        exhaust.a - (1, 1) [Positive Plural Accusative Neuter]
        exhaust.a - (1, 1) [Positive Plural Vocative Neuter]
    """);
    
    [Test]
    public void LookupZZZZZJ() => CheckWord("canebat", """
    [Verb] [Unknown] can.o can.ere can.i canit.us : sing, celebrate, chant; crow; recite; play (music)/sound (horn); foretell;
        can.ebat - (3, 1) [Imperfect Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupZZZZZK() => CheckWord("canebat", """
    [Verb] [Unknown] can.eo can.ere canu.i - : be/become covered in white; be hoary, be white/gray (with age);
        can.ebat - (2, 1) [Imperfect Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupZZZZZL() => CheckWord("canebat", """
    [Verb] [Unknown] can.o can.ere cecin.i cant.us : sing, celebrate, chant; crow; recite; play (music)/sound (horn); foretell;
        can.ebat - (3, 1) [Imperfect Active Indicative Third Person Singular]
    """);
    
    [Test]
    public void LookupZZZZZM() => CheckWord("si", """
    [Conjunction]  si : if, if only; whether; [quod si/si quis or quid => but if/if anyone or anything];
        si
    """);
    
    [Test]
    public void LookupZZZZZN() => CheckWord("mihi", """
    [Pronoun]  ego. m.ei : I, me (PERS); myself (REFLEX);
        m.ihi - (5, 1) [Personal Singular Dative Common]
    """);
    
    [Test]
    public void LookupZZZZZO() => CheckWord("non", """
    [Noun]  non. : Nones (pl.), abb. Non.; 7th of month, March, May, July, Oct., 5th elsewhen;
        non. - (9, 8) [Unknown Unknown Unknown]
    """);
    
    [Test]
    public void LookupZZZZZP() => CheckWord("non", """
    [Adverb]  non : not, by no means, no; [non modo ... sed etiam => not only ... but also];
        non
    """);
    
    [Test]
    public void LookupZZZZZQ() => CheckWord("animo", """
    [Noun]  anim.us anim.i : mind; intellect; soul; feelings; heart; spirit, courage, character, pride; air;
        anim.o - (2, 1) [Singular Dative Unknown]
        anim.o - (2, 1) [Singular Ablative Unknown]
    """);
    
    [Test]
    public void LookupZZZZZR() => CheckWord("animo", """
    [Verb] [Transitive] anim.o anim.are animav.i animat.us : animate, give/bring life; revive, refresh; rouse, animate; inspire; blow;
        anim.o - (1, 1) [Present Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupZZZZZS() => CheckWord("fixum", """
    [Verb] [Unknown] fig.o fig.ere fix.i fix.us : fasten, fix; pierce, transfix; establish;
        [Supine] fix.um - (0, 0) [Singular Accusative Neuter]
        [Participle] fix.um - (0, 0) [Perfect Passive Accusative Masculine]
        [Participle] fix.um - (0, 0) [Perfect Passive Nominative Neuter]
        [Participle] fix.um - (0, 0) [Perfect Passive Accusative Neuter]
        [Participle] fix.um - (0, 0) [Perfect Passive Vocative Neuter]
    """);
    
    [Test]
    public void LookupZZZZZT() => CheckWord("fixum", """
    [Noun]  fix.um fix.i : fixtures (pl.), fittings;
        fix.um - (2, 2) [Singular Nominative Neuter]
        fix.um - (2, 2) [Singular Vocative Neuter]
        fix.um - (2, 2) [Singular Accusative Neuter]
        fix.um - (2, 2) [Singular Accusative Common]
        fix.um - (2, 2) [Plural Genitive Unknown]
    """);
    
    [Test]
    public void LookupZZZZZU() => CheckWord("fixum", """
    [Adjective]  fix.us fix.a fix.um : fixed; firmly established (decision/ordinance), unhangable, irrevocable; unwavering (person); immovable; constant; fitted/set with;
        fix.um - (1, 1) [Positive Singular Nominative Neuter]
        fix.um - (1, 1) [Positive Singular Accusative Neuter]
        fix.um - (1, 1) [Positive Singular Vocative Neuter]
        fix.um - (1, 1) [Positive Singular Accusative Masculine]
    """);
    
    [Test]
    public void LookupZZZZZV() => CheckWord("immotumque", """
    [Adjective]  immot.us immot.a immot.um : unmoved, unchanged; immovable; inflexible;
        immot.um - (1, 1) [Positive Singular Nominative Neuter]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
        immot.um - (1, 1) [Positive Singular Accusative Neuter]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
        immot.um - (1, 1) [Positive Singular Vocative Neuter]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
        immot.um - (1, 1) [Positive Singular Accusative Masculine]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
        immot [Positive]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
            + [Adjective -> Adverb] Suffix um - -ly;
    """);
    
    [Test]
    public void LookupZZZZZW() => CheckWord("sederet", """
    [Verb] [Unknown] sed.eo sed.ere sed.i sess.us : sit, remain; settle; encamp;
        sed.eret - (2, 1) [Imperfect Active Subjunctive Third Person Singular]
    """);
    
    [Test]
    public void LookupZZZZZX() => CheckWord("ne", """
    [Verb] [Unknown] n.eo n.ere nev.i net.us : spin; weave; produce by spinning;
        n.e - (2, 1) [Present Active Imperative Second Person Singular]
    """);
    
    [Test]
    public void LookupZZZZZY() => CheckWord("ne", """
    [Adverb]  ne : not; (intro clause of purpose with subj verb); [ne....quidem => not even]; truly, indeed, verily, assuredly; (particle of assurance); (w/personal PRON);
        ne
    """);
    
    [Test]
    public void LookupZZZZZZ() => CheckWord("ne", """
    [Conjunction]  ne : that not, lest; (for negative of IMP);
        ne
    """);
}