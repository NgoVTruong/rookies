using unit_test.Models;

namespace unit_test.Services
{
    public class PersonService : IPersonService
    {
        private static readonly List<PersonModel> People = new List<PersonModel>
        {
        new PersonModel {
            FirstName = "Truong",
            LastName = "Ngo",
            Gender = "Male",
            DateOfBirth = new DateTime(2000, 10, 28),
            PhoneNumber = "0943764955",
            BirthPlace = "Nam Dinh",
            IsGraduated = "false",
        },
        new PersonModel {
            FirstName = "Doan",
            LastName = "Mai",
            Gender = "Male",
            DateOfBirth = new DateTime(1999, 3, 8),
            PhoneNumber = "0943764955",
            BirthPlace = "Nam Dinh",
            IsGraduated = "false",
        },
        new PersonModel {
            FirstName = "Vi",
            LastName = "Trinh",
            Gender = "Female",
            DateOfBirth = new DateTime(2001, 11, 2),
            PhoneNumber = "0943764955",
            BirthPlace = "Nam Dinh",
            IsGraduated = "false",
        },
        new PersonModel {
            FirstName = "Tin",
            LastName = "Dinh",
            Gender = "Male",
            DateOfBirth = new DateTime(200, 6, 2),
            PhoneNumber = "0943764955",
            BirthPlace = "Thai Binh",
            IsGraduated = "false",
        },
        };
        public List<PersonModel> GetAll()
        {
            return People;
        }
        public PersonModel? GetOne(int index)
        {
            if (index >= 0 && index < People.Count)
            {
                return People[index];
            }

            return null;
        }
        public PersonModel Create(PersonModel model)
        {
            People.Add(model);
            return model;
        }
        public PersonModel? Delete(int index)
        {
            if (index >= 0 && index < People.Count)
            {
                var person = People[index];
                People.RemoveAt(index);
                return person;
            }

            return null;
        }
        public PersonModel? Update(PersonModel model, int index)
        {
            if (index >= 0 && index < People.Count)
            {
                People[index] = model;
                return model;
            }

            return null;
        }
    }
}