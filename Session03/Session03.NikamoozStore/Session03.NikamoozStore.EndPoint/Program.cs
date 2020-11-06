using Session03.NikamoozStore.DAL;
using System;
using static System.Console;
namespace Session03.NikamoozStore.EndPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new NikamoozStoreDb())
            {
                var corse = ctx.Courses.Find(1);
                ctx.Courses.Remove(corse);
                //Update(corse);
                //Add(ctx);

                ctx.SaveChanges();
            }
            WriteLine("Done");
            ReadLine();
        }

        private static void Update(Domain.Course corse)
        {
            corse.Name = "ASP.NET Core MVC 3";
        }

        private static void Add(NikamoozStoreDb ctx)
        {
            ctx.Courses.Add(new Domain.Course
            {
                Name = "ASP.NET Core MVC "
            });
        }
    }
}
