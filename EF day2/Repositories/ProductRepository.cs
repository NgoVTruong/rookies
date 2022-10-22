using EF_day2.Models;

namespace EF_day2.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductManagementContext context) : base(context)
        {
            
        }
    }
}