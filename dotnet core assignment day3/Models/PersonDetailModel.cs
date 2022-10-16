using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace dotnet_core_assignment_day3.Models
{
    public class PersonDetailModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? BirthPlace { get; set; }
        public string? IsGraduated { get; set; }
    }
}