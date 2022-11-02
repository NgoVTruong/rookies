using webAPI_day2.Models;

namespace webAPI_day2.Services
{
    public class PersonService : IPersonService
    {
        private static List<PersonModel> _people = new List<PersonModel>
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
            BirthPlace = "Thai Binh",
            IsGraduated = "false",
        },
        new PersonModel {
            FirstName = "Vi",
            LastName = "Trinh",
            Gender = "Female",
            DateOfBirth = new DateTime(2001, 11, 2),
            PhoneNumber = "0943764955",
            BirthPlace = "Ninh Binh",
            IsGraduated = "false",
        },
        new PersonModel {
            FirstName = "Tin",
            LastName = "Dinh",
            Gender = "Male",
            DateOfBirth = new DateTime(1998, 6, 2),
            PhoneNumber = "0943764955",
            BirthPlace = "Ha Nam",
            IsGraduated = "false",
        },
        new PersonModel {
            FirstName = "Le",
            LastName = "Dan",
            Gender = "Female",
            DateOfBirth = new DateTime(2004, 6, 2),
            PhoneNumber = "0943764955",
            BirthPlace = "Phu tho",
            IsGraduated = "false",
        },
        new PersonModel {
            FirstName = "Le",
            LastName = "Long",
            Gender = "Other",
            DateOfBirth = new DateTime(2004, 6, 2),
            PhoneNumber = "0943764955",
            BirthPlace = "vinh pHuc",
            IsGraduated = "false",
        },
        new PersonModel {
            FirstName = "Anh",
            LastName = "Dan",
            Gender = "Other",
            DateOfBirth = new DateTime(2004, 6, 2),
            PhoneNumber = "0943764955",
            BirthPlace = "HuNg Yen ",
            IsGraduated = "false",
        },
        };
        public List<PersonModel> GetAll()
        {
            return _people;
        }
        public PersonModel? GetOne(Guid id)
        {
            return _people.SingleOrDefault(p => p.Id.Equals(id));
        }
        public PersonModel Create(PersonModel model)
        {
            _people.Add(model);
            return model;
        }
        public PersonModel? Delete(Guid id)
        {
            var index = _people.FindIndex(p => p.Id.Equals(id));
            if (index >= 0)
            {
                var person = _people[index];
                _people.RemoveAt(index);
                return person;
            }

            return null;
        }
        public PersonModel? Update(PersonModel model, Guid id)
        {
            var index = _people.FindIndex(p => p.Id.Equals(id));
            if (index >= 0)
            {
                _people[index] = model;
                return _people[index];
            }

            return null;
        }

    }
}