using Microsoft.EntityFrameworkCore;
using Session05.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session05.CQRS.Infrastructures
{
    public class PersonContext:DbContext
    {
        public PersonContext(DbContextOptions<PersonContext> options) :base(options)
        {

        }
        public DbSet<Person> People { get; set; }
    }
}
