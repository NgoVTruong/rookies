using Microsoft.AspNetCore.Mvc;
using dotnet_core_assignment_day3.Models;
using dotnet_core_assignment_day3.Services;

namespace dotnet_core_assignment_day3.Controllers;
public class RookiesController : Controller
{

    private readonly ILogger<RookiesController> _logger;
    private readonly IPersonService _personService;


    public RookiesController(ILogger<RookiesController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    public IActionResult Index()
    {
        var People = _personService.GetAll();

        return View(People);
    }

    public IActionResult Detail(int index)
    {
        var person = _personService.GetOne(index);
        if (person != null)
        {
            var model = new PersonDetailModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                DateOfBirth = person.DateOfBirth,
                PhoneNumber = person.PhoneNumber,
                BirthPlace = person.BirthPlace,
                IsGraduated = person.IsGraduated,
            };
            ViewData["Index"] = index;

            return View(model);
        }

        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(PersonCreateModel model)
    {
        if (ModelState.IsValid)
        {
            var person = new PersonModel
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                PhoneNumber = model.PhoneNumber,
                BirthPlace = model.BirthPlace,
            };
            _personService.Create(person);

            return RedirectToAction("Index");
        }

        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int index)
    {
        var person = _personService.GetOne(index);
        if (person != null)
        {
            var model = new PersonEditModel
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                PhoneNumber = person.PhoneNumber,
                BirthPlace = person.BirthPlace,
            };
            ViewData["Index"] = index;

            return View(model);
        }

        return View();
    }

    [HttpPost]
    public IActionResult Update(int index, PersonEditModel model)
    {
        if (ModelState.IsValid)
        {
            var person = _personService.GetOne(index);
            if (person != null)
            {
                person.FirstName = model.FirstName;
                person.LastName = model.LastName;
                person.DateOfBirth = model.DateOfBirth;
                person.PhoneNumber = model.PhoneNumber;
                person.BirthPlace = model.BirthPlace;

                _personService.Update(person, index);

                return RedirectToAction("Index");
            }
        }

        return View(model);
    }

    [HttpPost]
    public IActionResult Delete(int index)
    {
        var personDeleted = _personService.Delete(index);
        if (personDeleted == null) return NotFound();

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult DeleteAndToRedirectToResultView(int index)
    {
        var personDeleted = _personService.Delete(index);
        if (personDeleted == null) return NotFound();

        HttpContext.Session.SetString("DeletePersonName", personDeleted.FullName);

        return RedirectToAction("DeleteResult");
    }

    public IActionResult DeleteResult(int index)
    {
        ViewBag.DeletePerSonName = HttpContext.Session.GetString("DeletePersonName");
        return View();
    }
}