using System;
using System.Collections.Generic;
using System.Text;
using Session05.CQRS.Entities;
namespace Session05.CQRS.Contracts
{

    public interface IPersonReadRepository
    {
        Person Find(int id);
        List<Person> GetAll();
    }

    public interface IPersonWriteRepository
    {

        void Add(Person person);
        void Update(Person person);
    }
}
