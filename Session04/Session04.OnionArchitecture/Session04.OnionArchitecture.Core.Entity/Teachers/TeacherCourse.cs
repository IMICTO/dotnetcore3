using Session04.OnionArchitecture.Core.Entities.Courses;

namespace Session04.OnionArchitecture.Core.Entities.Teachers
{
    public class TeacherCourse
    {
        public int TeacherCourseId { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual Course Course { get; set; }
    }
}
