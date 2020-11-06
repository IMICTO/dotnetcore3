using Session04.OnionArchitecture.Core.Contracts;
using Session04.OnionArchitecture.Core.Contracts.Courses;
using Session04.OnionArchitecture.Core.Contracts.Studnts;
using Session04.OnionArchitecture.DataAccess.EF.Courses;
using Session04.OnionArchitecture.DataAccess.EF.Students;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session04.OnionArchitecture.DataAccess.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NikamoozStoreDbContext nikamoozStoreDbContext;

        public UnitOfWork(NikamoozStoreDbContext nikamoozStoreDbContext)
        {
            this.nikamoozStoreDbContext = nikamoozStoreDbContext;
        }
        public IStudentRepository StudentRepository { get =>new StudentRepository(nikamoozStoreDbContext); set => throw new NotImplementedException(); }
        public ICourseRepository CourseRepository { get => new CourseRepository(nikamoozStoreDbContext); set => throw new NotImplementedException(); }

        public void Save()
        {
            
        }
    }
}
