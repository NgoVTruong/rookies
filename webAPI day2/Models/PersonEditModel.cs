using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace webAPI_day2.Models
{
    public class PersonEditModel
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required!")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "First Name is required!")]
        public string? LastName { get; set; }

        [DisplayName("DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [DisplayName("BirthPlace")]
        public string? BirthPlace { get; set; }
    }
}