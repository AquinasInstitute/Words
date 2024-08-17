using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Words.Web.Controllers
{
    [Route("api/Words/Lookup")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        // This shouldn't be called, but is included for ease of API use by anyone else.
        [HttpGet("")]
        public async Task<ActionResult<string>> Lookup()
        {
            return Ok(JsonSerializer.Serialize(new { latin = "", english = "" }));
        }
        
        [HttpGet("{inputWord}")]
        public async Task<ActionResult<string>> Lookup(string inputWord)
        {
            var latinAnswer = WhitakersCompatability.LookupLatin(App.Instance, inputWord, true, false);
            var englishAnswer = WhitakersCompatability.LookupEnglish(App.Instance, inputWord, true);

            return Ok(JsonSerializer.Serialize(new { latin = latinAnswer, english = englishAnswer}));
        }
    }
}
