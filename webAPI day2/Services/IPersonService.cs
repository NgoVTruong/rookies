using webAPI_day2.Models;

namespace webAPI_day2.Services
{
    public interface IPersonService
    {
        List<PersonModel> GetAll();
        PersonModel? GetOne(Guid id);
        PersonModel Create(PersonModel model);
        PersonModel? Delete(Guid id);
        PersonModel? Update(PersonModel model, Guid id);
    }
}