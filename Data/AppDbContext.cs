using Microsoft.EntityFrameworkCore;

namespace crud_dotnet_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for the Book entity
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Tipping Point", Author = "Malcolm Gladwell", PublishYear = "2000" },
                new Book { Id = 2, Title = "Darkmans", Author = "Nicola Barker", PublishYear = "2007" },
                new Book { Id = 3, Title = "The Siege", Author = "Helen Dunmore", PublishYear = "2001" },
                new Book { Id = 4, Title = "Light", Author = "M John Harrison", PublishYear = "2002" },
                new Book { Id = 5, Title = "Visitation", Author = "Jenny Erpenbeck", PublishYear = "2008" }
            );

            // Seed data for the Quote entity
            modelBuilder.Entity<Quote>().HasData(
                new Quote { Id = 1, Author = "Benjamin Disraeli", Content = "Det finns ingen bättre utbildning än motgångar." },
                new Quote { Id = 2, Author = "Gustaf Lindborg", Content = "Sjömannen ber inte om medvind, han lär sig segla." },
                new Quote { Id = 3, Author = "Jonathan Saffran Foer", Content = "Du kan inte skydda dig själv från sorg utan att skydda dig själv från lycka." },
                new Quote { Id = 4, Author = "Mignon McLaughlin", Content = "Mod kan inte se runt hörn, men går runt dem ändå." },
                new Quote { Id = 5, Author = "Philip Sidney", Content = "Antingen så hittar jag en väg, eller så skapar jag en." }
            );
        }
    }
}
