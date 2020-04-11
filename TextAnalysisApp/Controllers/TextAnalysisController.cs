using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TextAnalysisApp.Models;

namespace TextAnalysisApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TextAnalysisController : Controller
    {
        private readonly ITextAnalysisService _textAnalysisService;

        public TextAnalysisController(ITextAnalysisService textAnalysisService)
        {
            _textAnalysisService = textAnalysisService;
        }

        [HttpPost]
        public async Task<ActionResult> ResultText([FromBody]TextAnalysisIntput text)
        {
            List<TextAnalysisOutput> listResult = new List<TextAnalysisOutput>
            {
                await _textAnalysisService.GetCharactersCountAsync(text),
                await _textAnalysisService.GetWordsCountAsync(text)
            };
            var test = listResult;
            //if (result == null)
            //{
            //    return NotFound();
            //}
            return  Ok(listResult);
        }
    }
}
