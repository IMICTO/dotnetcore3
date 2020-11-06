using StoreCore3.Domain;

namespace StoreCore3.DAL.Repository
{
    public class CourseRepository : BaseRepository<Student>
    {
        public CourseRepository(StoreCore3Db ctx) : base(ctx)
        {
        }
    }
}
