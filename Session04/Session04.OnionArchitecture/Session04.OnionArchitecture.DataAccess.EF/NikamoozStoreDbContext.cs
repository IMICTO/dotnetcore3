using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Session04.OnionArchitecture.Core.Entities.Courses;
using Session04.OnionArchitecture.Core.Entities.Students;
using Session04.OnionArchitecture.Core.Entities.Teachers;
using System;

namespace Session04.OnionArchitecture.DataAccess.EF
{
    public class DbContextFactory : IDesignTimeDbContextFactory<NikamoozStoreDbContext>
    {
        public NikamoozStoreDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<NikamoozStoreDbContext> optionsBuilder = new DbContextOptionsBuilder<NikamoozStoreDbContext>();
            optionsBuilder.UseSqlServer("Server=.; initial Catalog=NikamoozStore;" +
                " integrated security=true;");
            return new NikamoozStoreDbContext(optionsBuilder.Options);
        }
    }
    public class NikamoozStoreDbContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbQuery<CourseVw> courseVws { get; set; }

        public NikamoozStoreDbContext(DbContextOptions<NikamoozStoreDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Query<CourseVw>().ToView("CourseVw");
            base.OnModelCreating(modelBuilder);
        }
    }

}
