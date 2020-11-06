using Session05.CQRS.Contracts;
using Session05.CQRS.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Dapper;
namespace Session05.CQRS.Infrastructures
{
    public class PersonReadRepository : IPersonReadRepository
    {
        //private readonly PersonContext personContext;

        //public PersonReadRepository(PersonContext personContext)
        //{
        //    this.personContext = personContext;
        //}
        private readonly IDbConnection dbConnection;
        public PersonReadRepository(string cnnString)
        {
            dbConnection = new SqlConnection(cnnString);
        }
        public Person Find(int id)
        {
            return dbConnection.QueryFirstOrDefault<Person>($"Select * from People where id={id}");
        }

        public List<Person> GetAll()
        {
            return dbConnection.Query<Person>("Select * from People").ToList();
        }
    }
}
