using PreUni.College.DAL.NewcollegeDbConnection;
using PreUni.Core.Model;
using PreUni.Core.Model.ViewModel;
using PreUni.OnlineTest.DAL.EntityFramework;
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
    public class WritingMarkingRepository : GenericRepository<tblOnlineStudentWriting>, IWritingMarkingRepository
    {
        //private CollegeDbContext mCollegeDbContext;
        private NewcollegeDbContext mNewcollegeDbContext;

        public WritingMarkingRepository(DbContext SourceCollegeContext, DbContext SourceNewcollegeContext) : base(SourceNewcollegeContext)
        {
            //mCollegeDbContext = SourceCollegeContext as CollegeDbContext;
            mNewcollegeDbContext = SourceNewcollegeContext as NewcollegeDbContext;
        }

        public IEnumerable<OnlineWritingModel> GetOnlineWritingListResults(int? TestTypeID,int? Year, string Term, int? TestNo) // ,string Marker
        {
            object TestType_obj = TestTypeID ?? SqlInt32.Null;
            var clienetParam1 = new SqlParameter("@TestTypeID", TestType_obj);

            object Year_obj = Year ?? SqlInt32.Null;
            var clienetParam2 = new SqlParameter("@Year", Year_obj);

            var clienetParam3 = new SqlParameter("@Term", Term);

            object TestNo_obj = TestNo ?? SqlInt32.Null;
            var clienetParam4 = new SqlParameter("@TestNo", TestNo_obj);

            //var clienetParam5 = new SqlParameter("@UserEmail", UserEmail);

            var OnlineWritingModelList = mNewcollegeDbContext.Database
                                                             .SqlQuery<OnlineWritingModel>("SP_GetOnlineWritingList @TestTypeID,@Year,@Term,@TestNo",   // ,@UserEmail
                                                                                            clienetParam1, clienetParam2, clienetParam3, clienetParam4)  // clienetParam5
                                                             .ToList();

            return OnlineWritingModelList;
        }

        public IEnumerable<OnlineWritingModel> UpdateWritinWithUserEmail(int? TestTypeID, 
                                                                         int? Year, 
                                                                         string Term, 
                                                                         int? TestNo, 
                                                                         string UserMail,
                                                                         int SubjectID)
        {
            object TestType_obj = TestTypeID ?? SqlInt32.Null;
            var clienetParam1 = new SqlParameter("@TestTypeID", TestType_obj);

            object Year_obj = Year ?? SqlInt32.Null;
            var clienetParam2 = new SqlParameter("@Year", Year_obj);

            var clienetParam3 = new SqlParameter("@Term", Term);

            object TestNo_obj = TestNo ?? SqlInt32.Null;
            var clienetParam4 = new SqlParameter("@TestNo", TestNo_obj);

            var clienetParam5 = new SqlParameter("@UserEmail", UserMail);

            var clienetParam6 = new SqlParameter("@SubjectID", SubjectID);

            return
                    mNewcollegeDbContext.Database
                                        .SqlQuery<OnlineWritingModel>("SP_GetOnlineWritingList2 @TestTypeID,@Year,@Term,@TestNo,@UserEmail,@SubjectID",  // ExecuteSqlCommand
                                                                       clienetParam1, clienetParam2, clienetParam3, clienetParam4, clienetParam5, clienetParam6)
                                        .ToList();
        }

        /// <summary>
        /// Database is containing two rows about these params, 'StudentID', 'TestID'
        /// , which are pointing the one for normal writing test, another for ReWriting test.
        /// </summary>
        /// <param name="StudentID"></param>
        /// <param name="TestID"></param>
        /// <returns></returns>
        public IEnumerable<OnlineWritingModel> GetThisStudentWritingPaper(int? StudentID, int? TestID, int IsGeneralTest = 1) // , string Marker,
        {
            object StudentID_obj = StudentID ?? SqlInt32.Null;
            var clienetParam1 = new SqlParameter("@StudentID", StudentID_obj);

            object TestID_obj = TestID ?? SqlInt32.Null;
            var clienetParam2 = new SqlParameter("@TestID", TestID_obj);

            var clienetParam3 = new SqlParameter("@IsGeneralTest", IsGeneralTest);

            //var clienetParam4 = new SqlParameter("@UserEmail", Marker);

            var OnlineWritingModelList = mNewcollegeDbContext.Database
                                                             .SqlQuery<OnlineWritingModel>("SP_GetOnlineWritingPaper @TestID,@StudentID,@IsGeneralTest", // m,@UserEmail
                                                                                            clienetParam1, clienetParam2, clienetParam3) // clienetParam4
                                                             .ToList();
            return OnlineWritingModelList;
        }

        public void UpdateStudentWritingMarkForstatics(int TestID, int SubjectID, int StudentID, string StudentResponse)
        {
            //object StudentID_obj = StudentID ?? SqlInt32.Null;
            var clienetParam1 = new SqlParameter("@TestID", TestID);

            var clienetParam2 = new SqlParameter("@SubjectID", SubjectID);

            var clienetParam3 = new SqlParameter("@StudentID", StudentID);

            var clienetParam4 = new SqlParameter("@StudentResponse", StudentResponse);

            mNewcollegeDbContext.Database
                                //.SqlQuery<OnlineWritingModel>("InsertStudentScanData @TestID,@SubjectID,@StudentID,@StudentResponse",
                                .ExecuteSqlCommand("InsertStudentScanData @TestID,@SubjectID,@StudentID,@StudentResponse",
                                                    clienetParam1, clienetParam2, clienetParam3, clienetParam4);
        }

        public Task UpdateWritingPaper(tblOnlineStudentWriting onlineWritingModel)
        {
            var model = mNewcollegeDbContext.OnlineStudentWriting.Find(onlineWritingModel.ID);

            model.Comment = onlineWritingModel.Comment;
            model.Mark = onlineWritingModel.Mark;
            model.Marker = onlineWritingModel.Marker;
            model.Score = onlineWritingModel.Score;

            mNewcollegeDbContext.Entry<tblOnlineStudentWriting>(model);
            
            var result = mNewcollegeDbContext.SaveChangesAsync();
            
            return result;
        }
    }
}
