using PreUni.College.DAL.CollegeDbConnection;
using PreUni.OnlineTest.DAL.EntityFramework;
using System.Data.Entity;

namespace PreUni.College.DAL.Repository
{
    public  class ClassRepository : GenericRepository<MGTableClassInfo>, IClassRepository
    {
        private CollegeDbContext mCollegeDbContext;

        public ClassRepository(DbContext SourceCollegeContext) : base(SourceCollegeContext)
        {
            mCollegeDbContext = SourceCollegeContext as CollegeDbContext;
        }
    }
}
