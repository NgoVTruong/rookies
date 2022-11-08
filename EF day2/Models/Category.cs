using System.ComponentModel.DataAnnotations;

namespace EF_day2.Models
{
    public class Category
    {
        public Category()
        {

        }

        public Category(int categoryId, string categoryName)
        {
            CategoryId = categoryId;
            CategoryName = categoryName;
        }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}