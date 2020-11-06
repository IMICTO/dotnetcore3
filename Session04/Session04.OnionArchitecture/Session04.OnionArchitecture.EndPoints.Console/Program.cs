using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Session04.OnionArchitecture.Core.Entities.Courses;
using Session04.OnionArchitecture.DataAccess.EF;
using System;
using System.Linq;

namespace Session04.OnionArchitecture.EndPoints.Consoles
{
    class Program
    {
        public static readonly LoggerFactory MyLoggerFactory
            = new LoggerFactory(new[]
            {
        new ConsoleLoggerProvider((category, level)
            => category == DbLoggerCategory.Database.Command.Name
               && level == LogLevel.Information, true)
            });

        static void Main(string[] args)
        {
            DbContextOptionsBuilder<NikamoozStoreDbContext> optionsBuilder = new DbContextOptionsBuilder<NikamoozStoreDbContext>();
            optionsBuilder.UseSqlServer("Server=.; initial Catalog=NikamoozStore;" +
                " integrated security=true;");
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);
            var dbContext = new NikamoozStoreDbContext(optionsBuilder.Options);
            var course = dbContext.Courses.First();
            var teacher = course.Teachers;
            Console.WriteLine($"{course.CourseId} {course.Name}");
            //DtoTest(dbContext);
            Console.ReadLine();

        }

        private static void QueryType(NikamoozStoreDbContext dbContext)
        {
            dbContext.courseVws.FromSql("Select [Name] from Courses");
        }

        private static void DtoTest(NikamoozStoreDbContext dbContext)
        {
            var result = dbContext.Courses.Select(c => new CourseDto
            {
                Id = c.CourseId,
                Name = c.Name
            });
        }

        private static void LazyLoading(NikamoozStoreDbContext dbContext)
        {
            var course = dbContext.Courses.First();
            var teachers = course.Teachers;
            Console.WriteLine($"{course.CourseId} {course.Name}");
        }

        private static void SelectLoading(NikamoozStoreDbContext dbContext)
        {
            var item = dbContext.Courses.Select(c => new
            {
                c.Name,
                //c.Teachers.Select()
            }
                );
        }

        private static void ExplicitLoading(NikamoozStoreDbContext dbContext)
        {

            var course = dbContext.Courses.First();
            dbContext.Entry(course).Collection(c => c.Teachers).Load();//Query().Where(c => c.Teacher.FirstName.StartsWith("A"));
            var teacherCourse = dbContext.TeacherCourses.First();
            dbContext.Entry(teacherCourse).Reference(c => c.Teacher).Load();
            Console.WriteLine($"{course.CourseId} {course.Name}");
        }

        private static void EagerLoading(NikamoozStoreDbContext dbContext)
        {
            var Courses = dbContext.Courses.Include(c => c.Teachers).
                ThenInclude(c => c.Teacher).First();
            //foreach (var item in Courses)
            //{
            Console.WriteLine($"{Courses.CourseId} {Courses.Name}");
            //}
        }
    }
}
