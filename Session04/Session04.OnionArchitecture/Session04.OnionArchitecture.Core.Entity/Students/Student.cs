using Session04.OnionArchitecture.Core.Entities.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session04.OnionArchitecture.Core.Entities.Students
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<StudentCourse> Courses { get; set; }


    }
    public class StudentCourse
    {
        public int StudentCourseId { get; set; }
        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
