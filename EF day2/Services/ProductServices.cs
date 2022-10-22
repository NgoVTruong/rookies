using EF_day2.DTOs.Product;
using EF_day2.Models;
using EF_day2.Repositories;

namespace EF_day2.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _categoryRepo;

        public ProductServices(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepo = productRepository;
            _categoryRepo = categoryRepository;
        }


        public AddProductResponse? Add(AddProduct addModel)
        {
            using (var transaction = _productRepo.DatabaseTransaction())

                try
                {
                    var category = _categoryRepo.Get(c => c.CategoryId == addModel.CategoryId);
                    if (category != null)
                    {
                        var addProduct = new Product
                        {
                            ProductName = addModel.ProductName,
                            CategoryId = category.CategoryId,
                        };

                        var newDummyProduct = _productRepo.Create(addProduct);

                        _productRepo.SaveChanges();

                        transaction.Commit();

                        return new AddProductResponse
                        {
                            ProductId = newDummyProduct.Id,
                            ProductName = newDummyProduct.ProductName,
                            CategoryId = newDummyProduct.CategoryId
                        };
                    }

                    return null;
                }
                catch (Exception )
                {
                    transaction.Rollback();
                    return null;
                }
        }
    }
}