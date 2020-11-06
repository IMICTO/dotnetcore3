using EfCoreNew.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Data.Common;

namespace EfCoreNew.EfModel
{
    public class HintCommandInterceptor : DbCommandInterceptor
    {
        //public override DbDataReader re(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        //{
        //    return base.ReaderExecuted(command, eventData, result);
        //}

        //public override InterceptionResult ReaderExecuting(
        //    DbCommand command,
        //    CommandEventData eventData,
        //    InterceptionResult result)
        //{
        //    // Manipulate the command text, etc. here...
        //    command.CommandText += " OPTION (OPTIMIZE FOR UNKNOWN)";
        //    return result;
        //}
        public override InterceptionResult<int> NonQueryExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<int> result)
        {
            return base.NonQueryExecuting(command, eventData, result);
        }
        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
          
            return base.ReaderExecuting(command, eventData, result);
        }
        public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        {
            return base.ScalarExecuting(command, eventData, result);
        }
    }
    public class PersonContext:DbContext
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Address> Address{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseInMemoryDatabase("Test");
            optionsBuilder.UseSqlServer("Server=.; initial catalog=personDb; integrated security=true").AddInterceptors(new HintCommandInterceptor());
        }
    }
}
