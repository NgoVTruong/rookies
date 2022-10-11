using Microsoft.AspNetCore.Mvc;
using dotnet_core_assignment_day2.Services;
using dotnet_core_assignment_day2.DataAccess;

namespace dotnet_core_assignment_day2.Controllers
{
    public class RookiesController : Controller
    {
        List<PersonModel> DatasPeopleService = new MemberService.ListPersonService();
        private MemberService _service;

        private readonly ILogger<RookiesController> _logger;

        public RookiesController(ILogger<RookiesController> logger)
        {
            _logger = logger;
            _service = new MemberService();
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetMaleMembers()
        {
            var data = people.Where(x => x.Gender == "Male").ToList();
            return Json(data);
        }
        public IActionResult GetOldestMembers()
        {
            var maxAge = people.Max(x => x.Age);
            var oldestMember = people.Where(x => x.Age == maxAge).FirstOrDefault(x => x.Age == maxAge);
            return Json(oldestMember);
        }
        public IActionResult GetFullNames()
        {
            var members = people.Select(x => x.FullName);
            return Json(members);
        }
        public IActionResult GetMemberByBirthYear(int year, string compareType)
        {
            switch (compareType)
            {
                case "equal":
                    return Json(people.Where(x => x.DateOfBirth?.Year == year));
                case "greaterThan":
                    return Json(people.Where(x => x.DateOfBirth?.Year == year));
                case "lessThan":
                    return Json(people.Where(x => x.DateOfBirth?.Year == year));
                default: return Json(null);
            }
        }
        public IActionResult GetMembersWhoBornIn2000()
        {
            return RedirectToAction("MembersWhoBornIn2000", new { year = 2000, compareType = "equal" });
        }
        public IActionResult GetMembersWhoBornAfter2000()
        {
            return RedirectToAction("MembersWhoBornAfter2000", new { year = 2000, compareType = "greaterThan" });
        }
        public IActionResult GetMembersWhoBornBefore2000()
        {
            return RedirectToAction("MembersWhoBornBefore2000", new { year = 2000, compareType = "lessThan" });
        }
    }
}