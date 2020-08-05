using PreUni.Core.ConnectionFactory;
using PreUni.Core.Model;
using PreUni.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace PreUni.OnlineTest.DAL.EntityFramework
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private PreUniDbContext mPreUniDbContext;

        public SubjectRepository(DbContext dbContext) : base(dbContext)
        {
            mPreUniDbContext = dbContext as PreUniDbContext;    
        }

        public int AddSubject(Subject subject)
        {
            throw new NotImplementedException();
        }

        public bool DeleteSubject(int subjectID)
        {
            throw new NotImplementedException();
        }

        public Subject GetSubjectByID(int subjectID)
        {
            throw new NotImplementedException();
        }

        public IList<Subject> GetSubjectsByQuery()
        {
            throw new NotImplementedException();
        }

        public bool UpdateSubject(int subjectID, Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
