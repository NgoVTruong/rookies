using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dotnet_core_assignment_day1.Models
{
    public class PersonCreateModel
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First Name is required!")]
        public string? FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "First Name is required!")]
        public string? LastName { get; set; }

        [DisplayName("Gender")]
        public string? Gender { get; set; }

        [DisplayName("DateOfBirth")]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("PhoneNumber")]
        public string? PhoneNumber { get; set; }

        [DisplayName("BirthPlace")]
        public string? BirthPlace { get; set; }

        [DisplayName("IsGraduated")]
        public bool? IsGraduated { get; set; }
    }
}