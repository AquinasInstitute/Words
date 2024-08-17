using System.Diagnostics;
using System.Text;
using Words.Data_Sources;
using Words.Flags;
using Words.Inflected;
using Words.Words;

namespace Words;

public static class Program
{
    private static readonly StringBuilder Buffer = new();
    
    public static string LookupEnglish(LatinDictionary latin, string englishWord)
    {
        Buffer.Clear();
        englishWord = englishWord.ToLower().Trim();
        
        var latinWords = latin.LookupEnglishWord(englishWord);

        foreach (var word in latinWords)
        {
            var presented = string.Join(" ", latin.Present(word).Select(form =>
                form?.Stem is not null && form.Ending is not null ?
                    $"{form.Stem}.{form.Ending}" :
                    form?.Form ?? "-"
                )
            ) + " : " + word.Meaning;
            Buffer.AppendLine(presented);
        }

        return Buffer.ToString();
    }
    public static string LookupLatin(LatinDictionary latin, string latinWord, bool printTime = true)
    {
        const string indent = "    ";
        
        Buffer.Clear();
        latinWord = latinWord.ToLower().Trim();
        
        var watch = new Stopwatch();
        watch.Start();
        
        var words = latin.LookupLatinForm(latinWord);
        
        watch.Stop();

        if (printTime)
        {
            Buffer.AppendLine($"Time: {watch.ElapsedMilliseconds}");
        }
        
        foreach (var (word, forms) in words)
        {
            if (word is null)
            {
                Buffer.AppendLine("[Unknown] ???");
            }
            else
            {
                var presentedForms =
                    string.Join(
                        " ",
                        latin.Present(word)
                            .Select(form =>
                                form?.Stem is not null && form.Ending is not null ?
                                    $"{form.Stem}.{form.Ending}" :
                                    form?.Form ?? "-"
                            )
                        );
                var presented = $"[{word.PartOfSpeech}] {(word.Info is Verb verbInfo ?  $"[{verbInfo.VerbKind}]" : "")} {presentedForms} : {word.Meaning}";

                Buffer.AppendLine(presented);    
            }
            
            foreach (var (form, addons) in forms)
            {
                var text = form.Stem is not null && form.Ending is not null ? form.Stem + "." + form.Ending : form.Form;
                var part = word is null ? $"[{form.PartOfSpeech}] " : "";
                var meaning = word is null ? " => " + form.Meaning : "";
                
                switch (form)
                {
                    case InflectedPronoun pronoun:
                        Buffer.AppendLine($"{indent}{part}{text} - ({pronoun.Declension}, {pronoun.DeclensionVariant}) [{pronoun.PronounKind} {pronoun.Number} {pronoun.Case} {pronoun.Gender}]{meaning}");
                        break;
                    case InflectedNumeral numeral:
                        Buffer.AppendLine($"{indent}{part}{text} - ({numeral.Declension}, {numeral.DeclensionVariant}) [{numeral.Number} {numeral.Case} {numeral.Gender}] [{numeral.Sorting} {numeral.Value}]{meaning}");
                        break;
                    case InflectedNoun noun:
                        Buffer.AppendLine(word is not null && word.PartOfSpeech == PartOfSpeech.Verb
                            ? $"{indent}{part}[Supine] {text} - ({noun.Declension}, {noun.DeclensionVariant}) [{noun.Number} {noun.Case} {noun.Gender}]{meaning}"
                            : $"{indent}{part}{text} - ({noun.Declension}, {noun.DeclensionVariant}) [{noun.Number} {noun.Case} {noun.Gender}]{meaning}");
                        break;
                    case InflectedParticiple participle:
                        Buffer.AppendLine($"{indent}{part}[Participle] {text} - ({participle.Declension}, {participle.DeclensionVariant}) [{participle.Tense} {participle.Voice} {participle.Case} {participle.Gender}]{meaning}");
                        break;
                    case InflectedAdjective adjective:
                        Buffer.AppendLine($"{indent}{part}{text} - ({adjective.Declension}, {adjective.DeclensionVariant}) [{adjective.Comparison} {adjective.Number} {adjective.Case} {adjective.Gender}]{meaning}");
                        break;
                    case InflectedVerb verb:
                        if (form.Stem is not null && form.Ending is not null && form.Stem + form.Ending != form.Form)
                        {
                            text = form.Form;
                        }
                        
                        Buffer.AppendLine($"{indent}{part}{text} - ({verb.Conjugation}, {verb.ConjugationVariant}) [{verb.Tense} {verb.Voice} {verb.Mood} {verb.Person} Person {verb.Number}]{meaning}");

                        if (verb.Syncope is not null)
                        {
                            var priorForm = verb.Syncope.Value.priorForm;
                            var presentedForm =
                                priorForm.Stem is not null && priorForm.Ending is not null
                                    ? $"{priorForm.Stem}.{priorForm.Ending}"
                                    : priorForm.Stem ?? "?";
                            
                            Buffer.AppendLine($"{indent}{indent}({presentedForm} => {verb.Form}): {verb.Syncope.Value.syncope.Explanation})");
                        }
                        break;
                    case InflectedAdverb adverb:
                        Buffer.AppendLine($"{indent}{part}{text} [{adverb.Comparison}]{meaning}");
                        break;
                    default:
                        Buffer.AppendLine($"{indent}{part}{text}{meaning}");
                        break;
                }
            
                foreach (var addon in addons)
                {
                    var from = addon.From == PartOfSpeech.Unknown ? "Any" : addon.From.ToString();
                    var to = addon.To == PartOfSpeech.Unknown ? "Any" : addon.To.ToString();
                    
                    Buffer.AppendLine($"{indent}{indent}+ [{from} -> {to}] {addon.Kind} {addon.Word} - {addon.Meaning}");
                }
            }
        }

        return Buffer.ToString();
    }
    
    public static void Main()
    {
        const bool interactive = true;
        const bool whitakers = true;
        
        var watch = new Stopwatch();
        watch.Start();
        var latin = new LatinDictionary(new LatinDictionarySettings(), new DatabaseDataSource(LatinDictionary.DatabaseConnectionString));
        watch.Stop();
        
        Console.WriteLine($"Time ({watch.ElapsedMilliseconds})");
        Console.WriteLine("Put in a Latin form to search for, or put in an English word prefixed by a colon to do a reverse search.");
        
        while (interactive)
        {
            Console.Write("> ");
            
            var input = Console.ReadLine() ?? "";

            if (input.StartsWith(':'))
            {
                watch.Reset();
                watch.Start();
                var englishAnswer = LookupEnglish(latin, input[1..]);
                watch.Stop();
                
                Console.WriteLine($"Time ({watch.ElapsedMilliseconds})");
                Console.WriteLine(englishAnswer);
                Console.WriteLine();
                continue;
            }

            watch.Reset();
            watch.Start();
            var answer = whitakers ? WhitakersCompatability.LookupLatin(latin, input) : LookupLatin(latin, input);
            watch.Stop();
            
            Console.WriteLine($"Time ({watch.ElapsedMilliseconds})");
            Console.WriteLine(answer);
            Console.WriteLine();
        }
    }
}