namespace dotnet_core_assignment_day2.DataAccess;
public class PersonModel
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public string? BirthPlace { get; set; }
    public string? IsGraduated { get; set; }
    public int? Age
    {
        get
        {
            return DateTime.Now.Year - DateOfBirth?.Year;
        }
    }
    public string? FullName
    {
        get
        {
            return LastName + FirstName;
        }
    }

}