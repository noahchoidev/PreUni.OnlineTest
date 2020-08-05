using PreUni.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Unity;
using PreUni.College.DAL.CollegeDbConnection;
using PreUni.College.DAL.NewcollegeDbConnection;
using PreUni.College.DAL.Repository.Interface;

namespace PreUni.College.DAL.Repository
{
    public interface ICreateEFCollegeRepository
    {
        ITermTestCommentRepository CreateTermTestCommentRepository();
        
        IWritingMarkingRepository CreateWritingMarkingRepository();

        IBranchRepository CreateBranchRepository();

        IClassRepository CreateClassRepository();
    }

    public class CreateEFCollegeRepository : ICreateEFCollegeRepository
    {
        private readonly DbContext mDbCollegeDBContext;
        private readonly DbContext mDbNewcollegeDBContext;

        [Unity.Dependency]
        public IUnityContainer Container { get; set; }

        public CreateEFCollegeRepository(IUnityContainer muhContainer) // DbContext dbCollegeContext, DbContext dbNewcollegeContext
        {
            mDbCollegeDBContext = muhContainer.Resolve<DbContext>(typeof(CollegeDbContext).Name) as CollegeDbContext;
            mDbNewcollegeDBContext = muhContainer.Resolve<DbContext>(typeof(NewcollegeDbContext).Name) as NewcollegeDbContext;
        }

        public ITermTestCommentRepository CreateTermTestCommentRepository()
        {
            return new TermTestCommentRepository(mDbCollegeDBContext, mDbNewcollegeDBContext);
        }

        public IWritingMarkingRepository CreateWritingMarkingRepository()
        {
            return new WritingMarkingRepository(mDbCollegeDBContext, mDbNewcollegeDBContext);
        }

        public IBranchRepository CreateBranchRepository()
        {
            return new BranchRepository(mDbCollegeDBContext);
        }

        public IClassRepository CreateClassRepository()
        {
            return new ClassRepository(mDbCollegeDBContext);
        }
    }
}
