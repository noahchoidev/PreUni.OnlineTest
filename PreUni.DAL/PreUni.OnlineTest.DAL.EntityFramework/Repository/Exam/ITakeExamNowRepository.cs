using PreUni.Core.ConnectionFactory;
using PreUni.Core.Model;
using PreUni.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace PreUni.OnlineTest.DAL.EntityFramework
{
    public class ITakeExamNowRepository : GenericRepository<ITakeExamNow>, IITakeExamNowRepository
    {
        private PreUniDbContext mPreUniDbContext;

        public ITakeExamNowRepository(DbContext dbContext) : base(dbContext)
        {
            mPreUniDbContext = dbContext as PreUniDbContext;    
        }

        public Task<ITakeExamNowViewModel> GetITakeExamNow(int ITakeExamNowID)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<ITakeExamNowViewModel>> GetITakeExamNowListAsync(int StudentID)
        {
            throw new System.NotImplementedException();
        }
    }
}
