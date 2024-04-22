using Microsoft.EntityFrameworkCore;

namespace crud_dotnet_api.Data
{
    public class BookRepository
    {
        private readonly AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddBookAsync(Book book)
        {
            await _appDbContext.Set<Book>().AddAsync(book);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Book>> GetAllBookAsync()
        {
            return await _appDbContext.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _appDbContext.Books.FindAsync(id);
        }

        public async Task UpdateBookAsync(int id, Book model)
        {
            var book = await _appDbContext.Books.FindAsync(id);
            if (book == null)
            {
                throw new Exception("Book not found");
            }
            book.Title = model.Title;
            book.Author = model.Author;
            book.PublishYear = model.PublishYear;
          
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteBookAsnyc(int id)
        {
            var book = await _appDbContext.Books.FindAsync(id);
            if (book == null)
            {
                throw new Exception("Book not found");
            }
            _appDbContext.Books.Remove(book);
            await _appDbContext.SaveChangesAsync();
        }

    }
}
