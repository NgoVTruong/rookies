using Microsoft.AspNetCore.Mvc;
using dotnet_core_assignment_day1.Models;

namespace dotnet_core_assignment_day1.Controllers;
public class RookiesController : Controller
{
    private List<PersonModel> _people = new List<PersonModel>
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
    private readonly ILogger<RookiesController> _logger;

    public RookiesController(ILogger<RookiesController> logger)
    {
        _logger = logger;
    }

    [Route("NashTech/Rookies/Index")]
    public IActionResult Index()
    {
        return View(_people);
    }

    [Route("NashTech/Rookies/GetMaleMembers")]
    public IActionResult GetMaleMembers()
    {
        var data = _people.Where(x => x.Gender == "Male").ToList();
        return View(data);
    }

    [Route("NashTech/Rookies/GetOldestMembers")]
    public IActionResult GetOldestMembers()
    {
        var maxAge = _people.Max(x => x.Age);
        var oldestMember = _people.Where(x => x.Age == maxAge).FirstOrDefault(x => x.Age == maxAge);
        return View(oldestMember);
    }

    [Route("NashTech/Rookies/GetFullNames")]
    public IActionResult GetFullNames()
    {
        var query = _people.Select(x => x).ToList();
        return View(query);
    }
    public IActionResult GetMemberByBirthYear(int year, string compareType)
    {
        switch (compareType)
        {
            case "equal":
                return View(_people.Where(x => x.DateOfBirth?.Year == year));
            case "greaterThan":
                return View(_people.Where(x => x.DateOfBirth?.Year < year));
            case "lessThan":
                return View(_people.Where(x => x.DateOfBirth?.Year > year));
            default: return Json(null);
        }
    }

    [Route("NashTech/Rookies/GetMembersWhoBornIn2000")]
    public IActionResult GetMembersWhoBornIn2000()
    {
        return RedirectToAction("GetMemberByBirthYear", new { year = 2000, compareType = "equal" });
    }

    [Route("NashTech/Rookies/GetMembersWhoBornAfter2000")]
    public IActionResult GetMembersWhoBornAfter2000()
    {
        return RedirectToAction("GetMemberByBirthYear", new { year = 2000, compareType = "lessThan" });
    }

    [Route("NashTech/Rookies/GetMembersWhoBornBefore2000")]
    public IActionResult GetMembersWhoBornBefore2000()
    {
        return RedirectToAction("GetMemberByBirthYear", new { year = 2000, compareType = "greaterThan" });
    }
}
