using efcorewithoutfluentapi.Models;

namespace efcorewithoutfluentapi.Repositories
{
    public class BookRepository : IBookRepository
    {
         private BookStoreContext _bookStoreContext;
         public BookRepository(BookStoreContext bookStoreContext){
            _bookStoreContext = bookStoreContext;
         }
        public void CreateBook(Book book)
        {
            _bookStoreContext.Books.Add(book);
            _bookStoreContext.SaveChanges();
        }

        public void DeleteBook(int bookId)
        {
            
        }

        public List<Book> GetAllBooks()
        {
            return _bookStoreContext.Books.ToList();
            //Select * from Book
        }

        public void UpdateBook(Book book)
        {
            var bookTemp = _bookStoreContext.Books
                                    .Where(x =>x.BookId == book.BookId)
                                    .FirstOrDefault();
            //Select * from book where bookid = ''
            if(bookTemp !=null){
                bookTemp.Title = book.Title;
                bookTemp.Description = book.Description;
                bookTemp.Price = book.Price;
                _bookStoreContext.SaveChanges();
            }
            //_bookStoreContext.Books.Update(book);
        }
    }
}