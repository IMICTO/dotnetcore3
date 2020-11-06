using Session05.CQRS.Contracts;
using Session05.CQRS.Entities;

namespace Session05.CQRS.Infrastructures
{
    public class PersonWriteRepository : IPersonWriteRepository
    {
        private readonly PersonContext personContext;

        public PersonWriteRepository(PersonContext personContext)
        {
            this.personContext = personContext;
        }
        public void Add(Person person)
        {
            personContext.Add(person);
            personContext.SaveChanges();
        }

        public void Update(Person person)
        {
            personContext.Update(person);
            personContext.SaveChanges();
        }
    }
}
