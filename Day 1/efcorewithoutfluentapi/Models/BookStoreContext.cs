
using Microsoft.EntityFrameworkCore;

namespace efcorewithoutfluentapi.Models
{
    public class BookStoreContext : DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
        : base(options)
        {
        }
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
    }
}

