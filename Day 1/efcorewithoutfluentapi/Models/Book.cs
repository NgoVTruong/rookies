
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace efcorewithoutfluentapi.Models
{
   // [Table("BookInfo")]
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        [StringLength(50)]
        public string? Title { get; set; }
        public string? Description{get;set;}
        public int Price {get;set;}

        //public Author Author { get; set; }

        [ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
