using Microsoft.EntityFrameworkCore;

namespace crud_dotnet_api.Data
{
    public class QuoteRepository
    {
        private readonly AppDbContext _appDbContext;

        public QuoteRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddQuoteAsync(Quote quote)
        {
            await _appDbContext.Set<Quote>().AddAsync(quote);
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<List<Quote>> GetAllQuoteAsync()
        {
            return await _appDbContext.Quotes.ToListAsync();
        }

        public async Task<Quote> GetQuoteByIdAsync(int id)
        {
            return await _appDbContext.Quotes.FindAsync(id);
        }

        public async Task UpdateQuoteAsync(int id, Quote model)
        {
            var quote = await _appDbContext.Quotes.FindAsync(id);
            if (quote == null)
            {
                throw new Exception("Quote not found");
            }
            quote.Author = model.Author;
            quote.Content = model.Content;

            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteQuoteAsnyc(int id)
        {
            var quote = await _appDbContext.Quotes.FindAsync(id);
            if (quote == null)
            {
                throw new Exception("Quote not found");
            }
            _appDbContext.Quotes.Remove(quote);
            await _appDbContext.SaveChangesAsync();
        }

    }
}
