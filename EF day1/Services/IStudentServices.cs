using EF_day1.Models;

namespace EF_day1.Services
{
    public interface IStudentServices
    {
        public List<Student> GetAllStudents();
        public Student GetById(int id);
        public void CreateStudent(Student student);
        public void UpdateStudent(Student student);
        public void DeleteStudent(int studentId);

    }
}
