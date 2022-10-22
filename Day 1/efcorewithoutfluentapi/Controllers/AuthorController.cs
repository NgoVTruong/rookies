using Microsoft.AspNetCore.Mvc;
using efcorewithoutfluentapi.Models;
using efcorewithoutfluentapi.Services;

namespace efcorewithoutfluentapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthorController : ControllerBase
    {
        private  readonly  IAuthorServices _authorServices;
        public AuthorController(IAuthorServices authorServices)
        {
            _authorServices = authorServices;
        }

        [HttpGet(Name = "get-list-all-authors")]
        public List<Author> GetListAllAuthors()
        {
            return _authorServices.GetAllAuthors();
        }

        [HttpPost(Name = "create-author")]
        public void CreateAuthor(Author author)
        {
            _authorServices.CreateAuthor(author);
        }

        [HttpPut(Name = "update-author")]
        public void UpdateAuthor(Author author)
        {
            _authorServices.UpdateAuthor(author);
        }
    }
}
