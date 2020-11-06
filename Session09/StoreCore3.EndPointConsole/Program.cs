using Microsoft.EntityFrameworkCore;

using StoreCore3.DAL;
using StoreCore3.Domain;
using StoreCore3.Extentions.Extentions;

using System;

namespace StoreCore3.EndPointConsole
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            int rowCount = 100000;
            using (StoreCore3Db ctx = new StoreCore3Db())
            {
                DateTime timer = DateTime.Now;

                ctx.Database.Migrate();
                Console.WriteLine($"Database Migrated in {(DateTime.Now - timer).TotalSeconds} seconds");


                timer = DateTime.Now;

                for (int i = 0; i < rowCount; i++)
                {
                    ctx.Courses.Add(new Course() { Name = $"Course{i}" });
                }

                ctx.SaveChanges();

                Console.WriteLine($"{rowCount} Rows Added to Course table in {(DateTime.Now - timer).TotalSeconds} seconds");

                timer = DateTime.Now;
                int deletedCount = ctx.Courses.Clear();

                Console.WriteLine($"{deletedCount} Rows removed from Course table in {(DateTime.Now - timer).TotalSeconds} seconds");
                Console.ReadLine();
            }
        }
    }
}
