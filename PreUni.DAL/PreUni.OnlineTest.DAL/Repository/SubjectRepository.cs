using Dapper;
using PreUni.Core.ConnectionFactory;
using PreUni.Core.Model;
using PreUni.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PreUni.OnlineTest.DAL.Repository
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        
        public SubjectRepository(IPreUniOnlineConnectionFactory _connectionFactory) : base(_connectionFactory)
        {
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
            var subjectList = new List<Subject>();
            var SqlQuery = @"SELECT TOP (1000) [SubjectID],[SubjectName],[CreatedAt],[EditedAt],[DeleteAt] FROM [PreUniOnline].[dbo].[Subject]";

            using (IDbConnection conn = _connectionFactory.GetConnection)
            {
                subjectList = conn.Query<Subject>(SqlQuery).ToList();
                return subjectList;
            }
        }

        public bool UpdateSubject(int subjectID, Subject subject)
        {
            throw new NotImplementedException();
        }
    }
}
