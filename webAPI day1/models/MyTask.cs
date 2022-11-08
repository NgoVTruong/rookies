using System.ComponentModel.DataAnnotations;
namespace webAPI_day1.Models
{
    public class MyTask
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public bool IsCompleted { get; set; }
    }
}