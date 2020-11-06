using Microsoft.EntityFrameworkCore;
using Session05.CQRS.Infrastructures;
using System;

namespace Session05.CQRS
{
    class Program
    {
        static void Main(string[] args)
        {
            //var optionBuilder = new 
            var optionBuilder = new DbContextOptionsBuilder<PersonContext>();
            optionBuilder.UseSqlServer("Server=.;Initial Catalog=session05Write;integrated security=true");

            var optionBuilderRead = new DbContextOptionsBuilder<PersonContext>();
            optionBuilderRead.UseSqlServer("Server=.;Initial Catalog=session05Read;integrated security=true");

            var contextWite = new PersonContext(optionBuilder.Options);
            var contextRead = new PersonContext(optionBuilderRead.Options);
            //context.Database.EnsureCreated();




            var readRepo = new PersonReadRepository(contextRead.Database.GetDbConnection().ConnectionString);
            var writeRepo = new PersonWriteRepository(contextWite);

            //writeRepo.Add(new Entities.Person
            //{
            //    FirstName = "Masoud",
            //    LastName = "Traheri"
            //});

            var list = readRepo.GetAll();


        }
    }
}
