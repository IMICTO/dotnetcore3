using Session04.OnionArchitecture.Core.Contracts.Studnts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Session04.OnionArchitecture.DataAccess.EF.Students
{
    public class StudentRepository:IStudentRepository
    {
        private readonly NikamoozStoreDbContext nikamoozStoreDbContext;

        public StudentRepository(NikamoozStoreDbContext nikamoozStoreDbContext)
        {
            this.nikamoozStoreDbContext = nikamoozStoreDbContext;
        }
    }
}
