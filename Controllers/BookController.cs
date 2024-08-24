using crud_dotnet_api.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace crud_dotnet_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]  //uncomment it to protect the routes actions
    public class BookController : ControllerBase
    {
        private readonly BookRepository _bookRepository;

        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpPost]
        public async Task<ActionResult> AddBook([FromBody] Book model)
        {
            await _bookRepository.AddBookAsync(model);
            return Ok();
        }

        [HttpGet]

        public async Task<ActionResult> GetBookList()
        {
            var bookList = await _bookRepository.GetAllBookAsync();
            return Ok(bookList);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookById([FromRoute] int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook([FromRoute] int id, [FromBody] Book model)
        {
            await _bookRepository.UpdateBookAsync(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook([FromRoute] int id)
        {
            await _bookRepository.DeleteBookAsnyc(id);
            return Ok();
        }
    }
}