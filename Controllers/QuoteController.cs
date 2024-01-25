using crud_dotnet_api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace crud_dotnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]  //uncomment it to protect thr routes actions
    public class QuoteController : ControllerBase
    {
        private readonly QuoteRepository _quoteRepository;

        public QuoteController(QuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddQuote([FromBody] Quote model)
        {
            await _quoteRepository.AddQuoteAsync(model);
            return Ok();
        }

        [HttpGet]

        public async Task<ActionResult> GetQuoteList()
        {
            var quoteList = await _quoteRepository.GetAllQuoteAsync();
            return Ok(quoteList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetQuoteById([FromRoute] int id)
        {
            var quote = await _quoteRepository.GetQuoteByIdAsync(id);
            return Ok(quote);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteQuote([FromRoute] int id)
        {
            await _quoteRepository.DeleteQuoteAsnyc(id);
            return Ok();
        }
    }
}