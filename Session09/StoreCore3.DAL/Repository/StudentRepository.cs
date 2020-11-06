using StoreCore3.Domain;

namespace StoreCore3.DAL.Repository
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(StoreCore3Db ctx) : base(ctx)
        {
        }
    }
}
