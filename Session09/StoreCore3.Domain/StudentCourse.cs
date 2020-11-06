namespace StoreCore3.Domain
{
    public class StudentCourse : BaseEntity
    {
        public int StudentCourseId { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}
