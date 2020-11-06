using EfCoreNew.EfModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EfCoreNew.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var ctx = new PersonContext();
            ctx.People.Add(new Model.Person
            {
                FirstName = "Alrieza",
                LastName = "Oroumand"
            });
            //ctx.People.FromSqlRaw("")
            //ctx.People.FromSqlInterpolated("");

            var adddress = ctx.Address.Include(c => c.Person).AsNoTracking().ToList();
            bool result = ReferenceEquals(adddress[0]?.Person, adddress[1]?.Person);

            ctx.SaveChanges();
            var p = ctx.People.ToList();
        }
    }
}
