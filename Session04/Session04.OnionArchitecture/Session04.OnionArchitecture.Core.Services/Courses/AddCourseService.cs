using Session04.OnionArchitecture.Core.Contracts;
using Session04.OnionArchitecture.Core.Contracts.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session04.OnionArchitecture.Core.Services.Courses
{
    public class AddCourseService : IAddCourseService
    {
        private readonly IUnitOfWork unitOfWork;

        public AddCourseService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void Execute()
        {
            //unitOfWork.StudentRepository;
            //unitOfWork.CourseRepository;

            unitOfWork.Save();
        }
    }
}
