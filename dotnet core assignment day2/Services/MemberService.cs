using dotnet_core_assignment_day2.DataAccess;

namespace dotnet_core_assignment_day2.Services
{
    public class MemberService
    {
        public List<PersonModel> ListPersonService()
        {
            var DataAccess = new DataAccess.StaticDataAsset();
            return DataAccess.ListPerson();
        }
    }

}