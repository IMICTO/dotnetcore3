using System;
using System.Text;

namespace Session05.Crud.UI.Entities
{
    public class Course
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
    }
}
