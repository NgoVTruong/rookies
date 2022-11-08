using EF_day2.Models;

namespace EF_day2.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ProductManagementContext context) : base(context)
        {

        }
    }
}