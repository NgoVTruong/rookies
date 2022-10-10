using Microsoft.AspNetCore.Mvc;
using dotnet_core_assignment_day1.Models;

namespace dotnet_core_assignment_day1.Controllers
{
    public class RookiesController : Controller
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
    };
        private readonly ILogger<RookiesController> _logger;

        public RookiesController(ILogger<RookiesController> logger)
        {
            _logger = logger;
        }
        public IActionResult GetMaleMembers()
        {
            var data = _people.Where(x => x.Gender == "Male").ToList();
            return Json(data);
        }
        public IActionResult GetOldestMembers()
        {
            var maxAge = _people.Max(x => x.Age);
            var oldestMember = _people.Where(x => x.Age == maxAge).FirstOrDefault(x => x.Age == maxAge);
            return Json(oldestMember);
        }
        public IActionResult GetFullNames()
        {
            var members = _people.Select(x => x.FullName);
            return Json(members);
        }
        public IActionResult GetMemberByBirthYear(int year, string compareType)
        {
            switch (compareType)
            {
                case "equal":
                    return Json(_people.Where(x => x.DateOfBirth?.Year == year));
                case "greaterThan":
                    return Json(_people.Where(x => x.DateOfBirth?.Year == year));
                case "lessThan":
                    return Json(_people.Where(x => x.DateOfBirth?.Year == year));
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