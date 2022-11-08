using System.ComponentModel.DataAnnotations;

namespace EF_day2.DTOs.Product
{
    public class AddProduct
    {
        [Required]
        public string ProductName { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}