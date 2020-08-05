using PreUni.Core.ConnectionFactory;
using PreUni.Core.Model;
using PreUni.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PreUni.OnlineTest.DAL.EntityFramework
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {
        private PreUniDbContext mPreUniDbContext;
            
        public ExamRepository(DbContext dbContext) : base(dbContext)
        {
            mPreUniDbContext = dbContext as PreUniDbContext;
        }

        public int AddExam(Exam exam)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteExam(int examID)
        {
            throw new System.NotImplementedException();
        }

        public Exam GetExamByID(int examID)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<Exam>> GetExamsBySpQuery()
        {
            throw new System.NotImplementedException();
        }

        public bool UpdateExam(int examID, Exam exam)
        {
            throw new System.NotImplementedException();
        }
    }
}
