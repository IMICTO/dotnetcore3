using Microsoft.EntityFrameworkCore.Infrastructure;
using Session04.OnionArchitecture.Core.Entities.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session04.OnionArchitecture.Core.Entities.Courses
{
    public class CourseVw
    {
        public string Name { get; set; }
    }
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Course
    {
        //private readonly ILazyLoader lazyLoader;

        //public Course(ILazyLoader lazyLoader)
        //{
        //    this.lazyLoader = lazyLoader;
        //}
        public int CourseId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public virtual List<StudentCourse> Students { get; set; }
        public virtual List<Teachers.TeacherCourse> Teachers { get; set; }
        //private List<Teachers.TeacherCourse> _teachers;
        //public List<Teachers.TeacherCourse> Teachers
        //{
        //    get
        //    {
        //        lazyLoader.Load(this, "Teachers");
        //        return _teachers;
        //    }
        //    set
        //    {
        //        _teachers = value;
        //    }
        //}

    }
}
