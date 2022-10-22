using EF_day1.Models;
using EF_day1.Services;
using Microsoft.AspNetCore.Mvc;

namespace EF_day1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;

        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpGet(Name = "get-list-students")]
        public List<Student> GetStudent()
        {
            return _studentServices.GetAllStudents();
        }

        [HttpGet("get-student")]
        public Student GetById(int StudentId)
        {
            return _studentServices.GetById(StudentId);
        }

        [HttpPost(Name = "create-student")]
        public void CreateStudent(Student student)
        {
            _studentServices.CreateStudent(student);
        }

        [HttpPut(Name = "update-student")]
        public void UpdateStudent(Student student)
        {
            _studentServices.UpdateStudent(student);
        }

    }
}