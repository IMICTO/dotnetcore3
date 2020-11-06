namespace StoreCore3.Domain
{
    public class TeacherCourse : BaseEntity
    {
        public int TeacherCourseId { get; set; }

        public Teacher Teacher { get; set; }

        public Course Course { get; set; }
    }
}
