using Microsoft.EntityFrameworkCore;

using StoreCore3.Domain;
using StoreCore3.Extentions.Abstractions;

namespace StoreCore3.DAL
{
    public class StoreCore3Db : BaseDbContext
    {
        public DbSet<Teacher> Teachers { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Initial Catalog=StoreCore3Db;Integrated Security=True");
        }
    }
}
