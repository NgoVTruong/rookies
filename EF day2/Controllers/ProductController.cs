using EF_day2.DTOs.Product;
using EF_day2.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF_day2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpPost]
        public AddProductResponse? Add([FromBody] AddProduct addModel)
        {
            return _productServices.Add(addModel);
        }
    }
}