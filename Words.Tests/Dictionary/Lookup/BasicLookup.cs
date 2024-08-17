namespace Words.Tests.Dictionary.Lookup;

public class BasicLookup
{
    [Test(Description = "Check adjective")]
    public void LookupA() => CheckWord("nullius", """
    [Adjective]  null.us null.a null.um : no; none, not any; (PRONominal ADJ)
        null.ius - (1, 3) [Positive Singular Genitive Unknown]
    """);
    
    [Test(Description = "Check noun with part of speech changing suffix")]
    public void LookupB() => CheckWord("ludica", """
    [Noun]  lud.us lud.i : game, play, sport, pastime, entertainment, fun; school, elementary school;
        lud.a - (1, 1) [Positive Singular Nominative Feminine]
            + [Noun -> Adjective] Suffix ic - -ic; of, pertaining/belonging to; connected with; derived/coming from (place);
        lud.a - (1, 1) [Positive Singular Ablative Feminine]
            + [Noun -> Adjective] Suffix ic - -ic; of, pertaining/belonging to; connected with; derived/coming from (place);
        lud.a - (1, 1) [Positive Singular Vocative Feminine]
            + [Noun -> Adjective] Suffix ic - -ic; of, pertaining/belonging to; connected with; derived/coming from (place);
        lud.a - (1, 1) [Positive Plural Nominative Neuter]
            + [Noun -> Adjective] Suffix ic - -ic; of, pertaining/belonging to; connected with; derived/coming from (place);
        lud.a - (1, 1) [Positive Plural Accusative Neuter]
            + [Noun -> Adjective] Suffix ic - -ic; of, pertaining/belonging to; connected with; derived/coming from (place);
        lud.a - (1, 1) [Positive Plural Vocative Neuter]
            + [Noun -> Adjective] Suffix ic - -ic; of, pertaining/belonging to; connected with; derived/coming from (place);                                          
    """);

    [Test(Description = "Check active infinitive")]
    public void LookupC() => CheckWord("laudare", """
    [Verb] [Unknown] laud.o laud.are laudav.i laudat.us : recommend; praise, approve, extol; call upon, name; deliver eulogy on;
        laud.are - (1, 1) [Present Passive Indicative Second Person Singular]
        laud.are - (1, 1) [Present Passive Imperative Second Person Singular]
        laud.are - (1, 1) [Present Active Infinitive Unknown Person Unknown]
        laudare - (1, 1) [Perfect Active Indicative Third Person Plural]
            (laudav.ere => laudare): Syncopated perfect often drops the 'v' and contracts the vowel)                                                                                            
    """);

    [Test(Description = "Check basic 3rd declension")]
    public void LookupD() => CheckWord("rem", """
    [Noun]  r.es r.ei : thing; event/affair/business; fact; cause; property; [~ familiaris => property];
        r.em - (5, 1) [Singular Accusative Common]
    """);

    [Test(Description = "Check basic numeral")]
    public void LookupE() => CheckWord("unum", """
    [Numeral]  un.us prim.us : one;
        un.um - (1, 1) [Singular Accusative Masculine] [Cardinal 1]
        un.um - (1, 1) [Singular Nominative Neuter] [Cardinal 1]
        un.um - (1, 1) [Singular Accusative Neuter] [Cardinal 1]
        un.um - (1, 1) [Singular Vocative Neuter] [Cardinal 1]
    """);
    
    [Test]
    public void LookupE2() => CheckWord("unum", """
    [Adjective]  un.us un.a un.um : alone, a single/sole; some, some one; only (pl.); one set of (denoting entity);
        un.um - (1, 3) [Positive Singular Nominative Neuter]
        un.um - (1, 3) [Positive Singular Accusative Neuter]
        un.um - (1, 3) [Positive Singular Vocative Neuter]
        un.um - (1, 3) [Positive Singular Accusative Masculine]
    """);

    [Test(Description = "Check basic participle")]
    public void LookupF() => CheckWord("laudatus", """
    [Verb] [Unknown] laud.o laud.are laudav.i laudat.us : recommend; praise, approve, extol; call upon, name; deliver eulogy on;
        [Participle] laudat.us - (0, 0) [Perfect Passive Nominative Masculine]
    """);

    [Test(Description = "Check basic interjection")]
    public void LookupG() => CheckWord("heu", """
    [Interjection]  heu : oh! ah! alas! (an expression of dismay or pain);
        heu
    """);

    [Test(Description = "Check basic adverb")]
    public void LookupH() => CheckWord("cum", """
    [Adverb]  cum : when, at the time/on each occasion/in the situation that; after; since/although; as soon; while, as (well as); whereas, in that, seeing that; on/during which;
        cum [Positive]
    """);

    [Test(Description = "Check basic conjunctions")]
    public void LookupI() => CheckWord("et", """
    [Conjunction]  et : and, and even; also, even;  (et ... et = both ... and);
        et
    """);
    
    [Test(Description = "Check basic conjunctions")]
    public void LookupJ() => CheckWord("sed", """
    [Conjunction]  sed : but, but also; yet; however, but in fact/truth; not to mention; yes but;
        sed
    """);

    [Test(Description = "Check basic prepositions")]
    public void LookupK() => CheckWord("apud", """
    [Preposition]  apud : at, by, near, among; at the house of; before, in the presence/writings/view of;
        apud
    """);
    
    [Test(Description = "Verb + tackon")]
    public void LookupL() => CheckWord("vocatque", """
    [Verb] [Unknown] voc.o voc.are vocav.i vocat.us : call, summon; name; call upon;
        voc.at - (1, 1) [Present Active Indicative Third Person Singular]
            + [Any -> Any] Tackon que - -que = and (enclitic, translated before attached word); completes plerus/uter;
    """);
    
    [Test(Description = "Future participle of verb")]
    public void LookupM() => CheckWord("suscipienda", """
    [Verb] [Unknown] suscipi.o suscip.ere suscep.i suscept.us : undertake; support; accept, receive, take up;
        [Participle] suscipi.enda - (3, 0) [Future Passive Nominative Feminine]
        [Participle] suscipi.enda - (3, 0) [Future Passive Ablative Feminine]
        [Participle] suscipi.enda - (3, 0) [Future Passive Vocative Feminine]
        [Participle] suscipi.enda - (3, 0) [Future Passive Nominative Neuter]
        [Participle] suscipi.enda - (3, 0) [Future Passive Accusative Neuter]
        [Participle] suscipi.enda - (3, 0) [Future Passive Vocative Neuter]
    """);
    
    [Test(Description = "Syncopated verb")]
    public void LookupN() => CheckWord("quaesieris", """
    [Verb] [Unknown] quaer.o quaer.ere quaesiv.i quaesit.us : search for, seek, strive for; obtain; ask, inquire, demand;
        quaesieris - (3, 1) [Perfect Active Subjunctive Second Person Singular]
            (quaesiv.eris => quaesieris): Syncopated perfect often drops the 'v' and contracts the vowel)
    """);
    
    [Test(Description = "Suffix that changes part of speech")]
    public void LookupO() => CheckWord("cognoscibilia", """
    [Verb] [Transitive] cognosc.o cognosc.ere cognov.i cognit.us : become acquainted with/aware of; recognize; learn, find to be; inquire/examine;
        cognosc.ia - (3, 2) [Positive Plural Nominative Neuter]
            + [Verb -> Adjective] Suffix ibil - -able, -ble; having the passive quality, able to, able to be; -ful;
        cognosc.ia - (3, 2) [Positive Plural Accusative Neuter]
            + [Verb -> Adjective] Suffix ibil - -able, -ble; having the passive quality, able to, able to be; -ful;
        cognosc.ia - (3, 2) [Positive Plural Vocative Neuter]
            + [Verb -> Adjective] Suffix ibil - -able, -ble; having the passive quality, able to, able to be; -ful;
    """);
    
    [Test(Description = "Deponent verbs")]
    public void LookupP() => CheckWord("prosequi", """
    [Verb] [Deponent] prosequ.or prosequ.i - prosecut.us : pursue; escort; describe in detail;
        prosequ.i - (3, 1) [Present Passive Infinitive Unknown Person Unknown]
    """);
    
    [Test]
    public void LookupQ() => CheckWord("dicendum", """
    [Verb] [Unknown] dic.o dic.ere dix.i dict.us : say, declare, state; allege, declare positively; assert; plead (case); talk/speak; make speech; play (instrument); pronounce, articulate; utter; mean; name/call; appoint, fix/set (date); designate, declare intention of giving;
        [Participle] dic.endum - (3, 0) [Future Passive Accusative Masculine]
        [Participle] dic.endum - (3, 0) [Future Passive Nominative Neuter]
        [Participle] dic.endum - (3, 0) [Future Passive Accusative Neuter]
        [Participle] dic.endum - (3, 0) [Future Passive Vocative Neuter]
    """);
    
    [Test]
    public void LookupR() => CheckWord("sum", """
    [Verb] [ToBe] s.um .esse fu.i fut.urus : be; exist; (also used to form verb perfect passive tenses) with NOM PERF PPL
        s.um - (5, 1) [Present Active Indicative First Person Singular]
    """);
    
    [Test]
    public void LookupS() => CheckWord("sim", """
    [Verb] [ToBe] s.um .esse fu.i fut.urus : be; exist; (also used to form verb perfect passive tenses) with NOM PERF PPL
        s.im - (5, 1) [Present Active Subjunctive First Person Singular]
    """);
    
    [Test]
    public void LookupT() => CheckWord("essemus", """
    [Verb] [ToBe] s.um .esse fu.i fut.urus : be; exist; (also used to form verb perfect passive tenses) with NOM PERF PPL
        .essemus - (5, 1) [Imperfect Active Subjunctive First Person Plural]
    """);
    
    [Test]
    public void LookupU() => CheckWord("fuerunt", """
    [Verb] [ToBe] s.um .esse fu.i fut.urus : be; exist; (also used to form verb perfect passive tenses) with NOM PERF PPL
        fu.erunt - (5, 1) [Perfect Active Indicative Third Person Plural]
    """);
    
    [Test]
    public void LookupV() => CheckWord("ens", """
    [Noun]  ens. ent.is : being; something having esse/existence; (basic concept of St. Thomas Aquinas);
        ens. - (3, 2) [Singular Accusative Neuter]
        ens. - (3, 2) [Singular Nominative Unknown]
        ens. - (3, 2) [Singular Vocative Unknown]
    """);
    
    [Test]
    public void LookupW() => CheckWord("maior", """
    [Adjective]  magn.us maj.or maxi.mus : large/great/big/vast/huge; much; powerful; tall/long/broad; extensive/spacious; great (achievement); mighty; distinguished; skilled; bold/confident; proud; full/complete/utter/pure; intense; loud; at high price; notable/famous; old;
        maj.or - (1, 1) [Comparative Singular Nominative Common]
        maj.or - (1, 1) [Comparative Singular Vocative Common]
    """);
    
    [Test]
    public void LookupX() => CheckWord("peius", """
    [Adjective]  mal.us mal.a mal.um : bad, evil, wicked; ugly; unlucky;
        pej.us - (1, 1) [Comparative Singular Nominative Neuter]
        pej.us - (1, 1) [Comparative Singular Accusative Neuter]
        pej.us - (1, 1) [Comparative Singular Vocative Neuter]
    """);
    
    [Test]
    public void LookupY() => CheckWord("pessimus", """
    [Adjective]  pessi.mus pessi.ma pessi.mum : worst, most incapable; wickedest; most disloyal/unkind; lowest in quality/rank;
        pessi.mus - (0, 0) [Superlative Singular Nominative Masculine]
    """);
}