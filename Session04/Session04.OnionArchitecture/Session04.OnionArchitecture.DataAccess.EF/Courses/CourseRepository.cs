using Session04.OnionArchitecture.Core.Contracts.Courses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session04.OnionArchitecture.DataAccess.EF.Courses
{
    public class CourseRepository: ICourseRepository
    {
        private readonly NikamoozStoreDbContext nikamoozStoreDbContext;

        public CourseRepository(NikamoozStoreDbContext nikamoozStoreDbContext)
        {
            this.nikamoozStoreDbContext = nikamoozStoreDbContext;
        }
    }
}
