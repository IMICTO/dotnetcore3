using System.Collections.Generic;

namespace Session05.Crud.UI.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public bool Fired { get; set; }

    }
}
