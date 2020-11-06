using Microsoft.EntityFrameworkCore;
using Session05.Crud.UI.Entities;
using System;
using System.Linq;

namespace Session05.Crud.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new CourseContext())
            {
          
                var teachers = ctx.Teachers.ToList();
            }
        }

        private static void Deleted(CourseContext ctx)
        {
            // var teacher = ctx.Teachers.Find(1);
            var teacher = new Teacher
            {
                Id = 3
            };
            Console.WriteLine(ctx.Entry(teacher).State);
            Console.ReadLine();
            ctx.Teachers.Remove(teacher);
            Console.WriteLine(ctx.Entry(teacher).State);
            Console.ReadLine();
            ctx.SaveChanges();
        }

        private static void Update2(CourseContext ctx)
        {
            var teacher1 = ctx.Teachers.Find(2);
            Console.WriteLine(ctx.Entry(teacher1).State);
            Console.ReadLine();
            teacher1.Name = $"{teacher1.Name} {DateTime.Now.Millisecond}";
            Console.WriteLine(ctx.Entry(teacher1).State);
            Console.ReadLine();
            UpdateDisconnectedSenario02(teacher1.Id, teacher1.Name);
        }

        private static void UpdateDisconnectedSenario02(int id,string name)
        {
           

            using (var ctx = new CourseContext())
            {
                var teacher1 = ctx.Teachers.Find(id);
                Console.WriteLine(ctx.Entry(teacher1).State);
                Console.ReadLine();
                teacher1.Name = name;

                Console.WriteLine(ctx.Entry(teacher1).State);
                Console.ReadLine();
                ctx.SaveChanges();
                Console.WriteLine(ctx.Entry(teacher1).State);
                Console.WriteLine("Finished");
                Console.ReadLine();
            }
        }
        private static void UpdateDisconnectedSenario01(Teacher teacher1)
        {
            teacher1.Name = $"{teacher1.Name} {DateTime.Now.Millisecond}";
            using (var ctx = new CourseContext())
            {
                Console.WriteLine(ctx.Entry(teacher1).State);
                Console.ReadLine();
                ctx.Teachers.Update(teacher1);
                Console.WriteLine(ctx.Entry(teacher1).State);
                Console.ReadLine();
                ctx.SaveChanges();
                Console.WriteLine(ctx.Entry(teacher1).State);
                Console.WriteLine("Finished");
                Console.ReadLine();
            }
        }

        private static void UpdateConnected(CourseContext ctx)
        {
            var teacher1 = ctx.Teachers.Find(2);
            // var teacher2 = ctx.Teachers.FirstOrDefault(t => t.Id == 2);
            //var teacher3 = ctx.Teachers.SingleOrDefault(t=> t.Id == 2);
            Console.WriteLine(ctx.Entry(teacher1).State);
            Console.ReadLine();
            teacher1.Name = "Mahdi Shishebori";
            Console.WriteLine(ctx.Entry(teacher1).State);
            Console.ReadLine();
            ctx.SaveChanges();
            Console.WriteLine(ctx.Entry(teacher1).State);
            Console.ReadLine();
        }

        private static void Add(CourseContext ctx)
        {
            ctx.Database.EnsureCreated();
            Teacher t = new Teacher
            {
                Name = "Masoud Taheri",
            };
            t.Courses.Add(new Course
            {
                Name = "SQL Server For Linux Developers"
            });

            Console.WriteLine(ctx.Entry(t).State);
            Console.ReadLine();
            ctx.Teachers.Add(t);
            Console.WriteLine(ctx.Entry(t).State);
            Console.ReadLine();
            ctx.SaveChanges();
            Console.WriteLine(ctx.Entry(t).State);
            Console.ReadLine();
        }
    }
}
