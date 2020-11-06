using Microsoft.EntityFrameworkCore;
using Session03.NikamoozStore.Domain;
using System;

namespace Session03.NikamoozStore.DAL
{
    public class NikamoozStoreDb:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Initial Catalog=NikamoozStoreDb; integrated security=true");
        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Student> Students { get; set; }

    }
}
