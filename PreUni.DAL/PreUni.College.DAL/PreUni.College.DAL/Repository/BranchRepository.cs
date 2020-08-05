using PreUni.College.DAL.CollegeDbConnection;
using PreUni.College.DAL.NewcollegeDbConnection;
using PreUni.College.DAL.Repository.Interface;
using PreUni.Core.Model;
using PreUni.Core.Repository;
using PreUni.OnlineTest.DAL.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Threading.Tasks;

namespace PreUni.College.DAL.Repository
{
    /// <summary>
    /// TODO: Make this classs inherit Entity Framework Generic Repository
    /// </summary>
    public class BranchRepository : GenericRepository<tblCollege>,IBranchRepository
    {
        private CollegeDbContext mCollegeDbContext;

        public BranchRepository(DbContext SourceNewcollegeContext) : base(SourceNewcollegeContext)
        {
            mCollegeDbContext = SourceNewcollegeContext as CollegeDbContext;
        }
    }
}
