using Session06.NoneRelational.DAL;
using System;

namespace Session06.NoneRelational.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            BlogContext blogContext = new BlogContext();
            blogContext.Database.EnsureDeleted();

            blogContext.Database.EnsureCreated();
            Console.WriteLine("Hello World!");
        }
    }
}
