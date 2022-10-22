using efcorewithoutfluentapi.Models;
using efcorewithoutfluentapi.Repositories;

namespace efcorewithoutfluentapi.Services
{
    public class AuthorServices:IAuthorServices
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorServices(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public List<Author> GetAllAuthors()
        {
            return _authorRepository.GetAllAuthors();
        }

        public Author GetById(int id)
        {
            return _authorRepository.GetById(id);
        }

        public void CreateAuthor(Author author)
        {
            _authorRepository.CreateAuthor(author);
        }

        public void UpdateAuthor(Author author)
        {
            _authorRepository.UpdateAuthor(author);
        }

        public void DeleteAuthor(int authorId)
        {
            throw new NotImplementedException();
        }
    }
}
