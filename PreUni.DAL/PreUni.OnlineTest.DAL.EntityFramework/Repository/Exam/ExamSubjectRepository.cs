using PreUni.Core.ConnectionFactory;
using PreUni.Core.Model;
using PreUni.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PreUni.OnlineTest.DAL.EntityFramework
{
    public class ExamSubjectRepository : GenericRepository<ExamSubject>, IExamSubjectRepository
    {
        private PreUniDbContext mPreUniDbContext;

        public ExamSubjectRepository(DbContext dbContext) : base(dbContext)
        {
            mPreUniDbContext = dbContext as PreUniDbContext;
        }

        public ExamSubject GetExamSubjectByID(int examSubjectID)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ExamSubject>> GetExamSubjectsByQueryAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
