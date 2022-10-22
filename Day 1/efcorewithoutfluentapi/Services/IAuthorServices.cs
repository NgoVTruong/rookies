using efcorewithoutfluentapi.Models;

namespace efcorewithoutfluentapi.Services
{
    public interface IAuthorServices
    {
        public List<Author> GetAllAuthors();
        public Author GetById(int id);
        public void CreateAuthor(Author author);
        public void UpdateAuthor(Author author);
        public void DeleteAuthor(int authorId);
    }
}
