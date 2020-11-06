using Session04.OnionArchitecture.Core.Contracts.Courses;
using Session04.OnionArchitecture.Core.Contracts.Studnts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session04.OnionArchitecture.Core.Contracts
{
    public interface IUnitOfWork
    {
        IStudentRepository StudentRepository {get;set;}
        ICourseRepository CourseRepository {get;set;}
        void Save();
    }
}
