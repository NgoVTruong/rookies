namespace dotnet_core_assignment_day2.DataAccess
{
    public class StaticDataAsset
    {
        public static List<PersonModel> people = new List<PersonModel>
    {
        new PersonModel {
            FirstName = "Truong",
            LastName = "Ngo",
            Gender = 1,
            DateOfBirth = new DateTime(2000, 10, 28),
            PhoneNumber = "0943764955",
            BirthPlace = "Nam Dinh",
            IsGraduated = "false",
        },
        new PersonModel {
            FirstName = "Truo",
            LastName = "Ngo",
            Gender = 2,
            DateOfBirth = new DateTime(2000, 10, 28),
            PhoneNumber = "0943764955",
            BirthPlace = "Nam Dinh",
            IsGraduated = "false",
        },
        new PersonModel {
            FirstName = "Truong",
            LastName = "Ngon",
            Gender = 1,
            DateOfBirth = new DateTime(2000, 10, 28),
            PhoneNumber = "0943764955",
            BirthPlace = "Nam Dinh",
            IsGraduated = "false",
        },
    };
        public List<PersonModel> ListPerson()
        {
            return people;
        }
    }
}