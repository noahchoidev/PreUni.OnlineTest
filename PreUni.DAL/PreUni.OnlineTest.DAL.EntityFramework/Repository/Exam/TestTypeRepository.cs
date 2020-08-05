using PreUni.Core.Model;
using PreUni.Core.Repository;
using System.Data.Entity;

namespace PreUni.OnlineTest.DAL.EntityFramework
{
    public class TestTypeRepository : GenericRepository<TestType>, ITestTypeRepository
    {
        private PreUniDbContext mPreUniDbContext;

        public TestTypeRepository(DbContext dbContext) : base(dbContext)
        {
            mPreUniDbContext = dbContext as PreUniDbContext;
        }
    }
}
