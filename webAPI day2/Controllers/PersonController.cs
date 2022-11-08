using Microsoft.AspNetCore.Mvc;
using webAPI_day2.Models;
using webAPI_day2.Services;

namespace webAPI_day2.Controllers;

[ApiController]
[Route("api/[controller]")]
//[EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-Custom-Header")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;
    private readonly IPersonService _personService;

    public PersonController(ILogger<PersonController> logger, IPersonService personService)
    {
        _logger = logger;
        _personService = personService;
    }

    [HttpGet("")]
    public IEnumerable<PersonDetailModel> GetAll()
    {
        var data = _personService.GetAll();
        return from item in data
               select new PersonDetailModel
               {
                   Id = item.Id,
                   FirstName = item.FirstName,
                   LastName = item.LastName,
                   Gender = item.Gender,
                   DateOfBirth = item.DateOfBirth,
                   PhoneNumber = item.PhoneNumber,
                   BirthPlace = item.BirthPlace,
                   IsGraduated = item.IsGraduated,
               };
    }

    [HttpGet("{id:Guid}")]
    public IActionResult GetOne(Guid id)
    {
        try
        {
            var item = _personService.GetOne(id);
            if (item == null) { return NotFound(); }

            return new JsonResult(new PersonDetailModel
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Gender = item.Gender,
                DateOfBirth = item.DateOfBirth,
                PhoneNumber = item.PhoneNumber,
                BirthPlace = item.BirthPlace,
                IsGraduated = item.IsGraduated,
            });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPost("")]
    public IActionResult Create(PersonDetailModel model)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
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
            var result = _personService.Create(person);

            return StatusCode(StatusCodes.Status201Created, result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpPut("{id:Guid}")]
    public IActionResult Update(Guid id, PersonCreateModel model)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {
            var item = _personService.GetOne(id);
            if (item == null) { return NotFound(); }
            {
                item.BirthPlace = model.BirthPlace;
                item.DateOfBirth = model.DateOfBirth;
                item.FirstName = model.FirstName;
                item.LastName = model.LastName;
                item.Gender = model.Gender;
                item.PhoneNumber = model.PhoneNumber;
                var result = _personService.Update(item, id);
                return new JsonResult(result);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpDelete("{id:Guid}")]
    public IActionResult Delete(Guid id)
    {
        if (!ModelState.IsValid) return BadRequest();

        try
        {
            var item = _personService.GetOne(id);
            if (item == null) { return NotFound(); }
            {
                var result = _personService.Delete(id);
                return new JsonResult(result);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("name")]
    public IActionResult FilterName(string name)
    {
        try
        {
            var data = _personService.GetAll();
            var result = from item in data
                         where item.FullName.Trim().ToLower() == name.Trim().ToLower()

                         select new PersonDetailModel
                         {
                             Id = item.Id,
                             FirstName = item.FirstName,
                             LastName = item.LastName,
                             Gender = item.Gender,
                             DateOfBirth = item.DateOfBirth,
                             PhoneNumber = item.PhoneNumber,
                             BirthPlace = item.BirthPlace,
                             IsGraduated = item.IsGraduated,
                         };
            if (result == null || !result.Any()) return StatusCode(StatusCodes.Status404NotFound);
            return new JsonResult(result);

        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("gender")]
    public IActionResult FilterGender(string gender)
    {
        try
        {
            var data = _personService.GetAll();
            var result = from item in data
                         where item.Gender.Trim().ToLower() == gender.Trim().ToLower()
                         select new PersonDetailModel
                         {
                             Id = item.Id,
                             FirstName = item.FirstName,
                             LastName = item.LastName,
                             Gender = item.Gender,
                             DateOfBirth = item.DateOfBirth,
                             PhoneNumber = item.PhoneNumber,
                             BirthPlace = item.BirthPlace,
                             IsGraduated = item.IsGraduated,
                         };
            if (result == null || !result.Any()) return StatusCode(StatusCodes.Status404NotFound);
            return new JsonResult(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }

    [HttpGet("birth-place")]
    public IActionResult FilterBirthPlace(string birthPlace)
    {
        try
        {
            var data = _personService.GetAll();
            var result = from item in data
                         where item.BirthPlace.Trim().ToLower() == birthPlace.Trim().ToLower()
                         select new PersonDetailModel
                         {
                             Id = item.Id,
                             FirstName = item.FirstName,
                             LastName = item.LastName,
                             Gender = item.Gender,
                             DateOfBirth = item.DateOfBirth,
                             PhoneNumber = item.PhoneNumber,
                             BirthPlace = item.BirthPlace,
                         };
            if (result == null || !result.Any()) return StatusCode(StatusCodes.Status404NotFound);
            return new JsonResult(result);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex);
        }
    }
}
