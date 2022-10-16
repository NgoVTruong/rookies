using dotnet_core_assignment_day3.Models;

namespace dotnet_core_assignment_day3.Services
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