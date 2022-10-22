using Microsoft.EntityFrameworkCore;

namespace EF_day1.Models
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options)
        : base(options)
        {
        }
        public DbSet<Student> Students { get; set; } = null!;
    }
}

