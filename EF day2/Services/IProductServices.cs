using EF_day2.DTOs.Product;
using EF_day2.Models;

namespace EF_day2.Services
{
    public interface IProductServices
    {
        AddProductResponse? Add(AddProduct addModel);
        AddProductResponse? Add2(AddProduct addModel);
    }
}