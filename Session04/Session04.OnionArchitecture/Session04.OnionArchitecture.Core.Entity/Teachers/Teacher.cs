using System;
using System.Collections.Generic;
using System.Text;

namespace Session04.OnionArchitecture.Core.Entities.Teachers
{
    public class Teacher
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual List<TeacherCourse> Courses{ get; set; }

    }
}
