using unit_test.Models;

namespace unit_test.Services
{
    public interface IPersonService
    {
        List<PersonModel> GetAll();
        PersonModel? GetOne(int index);
        PersonModel Create(PersonModel model);
        PersonModel? Delete(int index);
        PersonModel? Update(PersonModel model, int index);
    }
}