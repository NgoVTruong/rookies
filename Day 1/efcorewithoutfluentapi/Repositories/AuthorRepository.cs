using efcorewithoutfluentapi.Models;

namespace efcorewithoutfluentapi.Repositories
{
    public class AuthorRepository: IAuthorRepository
    {
        private BookStoreContext _bookStoreContext;

        public AuthorRepository(BookStoreContext bookStoreContext)
        {
            _bookStoreContext = bookStoreContext;
        }

        public List<Author> GetAllAuthors()
        {
            return _bookStoreContext.Authors.ToList();
        }

        public Author GetById(int id)
        {
            return _bookStoreContext.Authors.Where(x => x.AuthorId == id).FirstOrDefault();
        }

        public void CreateAuthor(Author author)
        {
            _bookStoreContext.Authors.Add(author);
            _bookStoreContext.SaveChanges();
        }

        public void UpdateAuthor(Author author)
        {
            var authorTemp = _bookStoreContext.Authors.Where(x => x.AuthorId == author.AuthorId).FirstOrDefault();
            if (authorTemp != null)
            {
                authorTemp.FirstName = author.FirstName;
                authorTemp.LastName = author.LastName;
                _bookStoreContext.SaveChanges();
            }

        }

        public void DeleteAuthor(int authorId)
        {
            throw new NotImplementedException();
        }
    }
}

