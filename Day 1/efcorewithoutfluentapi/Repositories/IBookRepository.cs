using efcorewithoutfluentapi.Models;

namespace efcorewithoutfluentapi.Repositories
{
     public interface IBookRepository
    {
        public List<Book> GetAllBooks();
        public void CreateBook(Book book);
        public void UpdateBook(Book book);
        public void DeleteBook(int bookId);
    }
}