using EF_day1.Models;

namespace EF_day1.Services
{
    public class StudentServices : IStudentServices
    {
        private StudentContext _studentContext;
        public StudentServices(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }

        public Student GetById(int id)
        {
            return _studentContext.Students.Where(x => x.StudentId == id).FirstOrDefault();
        }

        public List<Student> GetAllStudents()
        {
            return _studentContext.Students.ToList();
        }

        public void CreateStudent(Student student)
        {
            _studentContext.Students.Add(student);
            _studentContext.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            var dummyStudent = _studentContext.Students.Where(x => x.StudentId == student.StudentId).FirstOrDefault();
            if (dummyStudent != null)
            {
                dummyStudent.FirstName = student.FirstName;
                dummyStudent.LastName = student.LastName;
                _studentContext.SaveChanges();
            }
        }

        public void DeleteStudent(int studentId)
        {
            throw new NotImplementedException();
        }
    }
}

