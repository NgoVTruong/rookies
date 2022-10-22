using efcorewithoutfluentapi.Models;

namespace efcorewithoutfluentapi.Repositories
{
    public interface IAuthorRepository
    {
        public List<Author> GetAllAuthors();
        public Author GetById(int id);
        public void CreateAuthor(Author author);
        public void UpdateAuthor(Author author);
        public void DeleteAuthor(int authorId);

    }
}
