using PreUni.College.DAL.NewcollegeDbConnection;
using PreUni.Core.Model;
using PreUni.Core.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreUni.College.DAL.Repository
{
    public interface IWritingMarkingRepository : IGenericRepository<tblOnlineStudentWriting>
    {
        IEnumerable<OnlineWritingModel> GetOnlineWritingListResults(int? TestTypeID, int? Year, string Term, int? TestNo);

        IEnumerable<OnlineWritingModel> GetThisStudentWritingPaper(int? StudentID, int? TestID, int IsGeneralTest); // string Marker,

        Task UpdateWritingPaper(tblOnlineStudentWriting onlineWritingModel);

        void UpdateStudentWritingMarkForstatics(int TestID, int SubjectID, int StudentID, string StudentResponse);

        //void UpdateWritinWithUserEmail(int? TestTypeID, int? Year, string Term, int? TestNo, string UserMail);
        IEnumerable<OnlineWritingModel> UpdateWritinWithUserEmail(int? TestTypeID, int? Year, string Term, int? TestNo, string UserMail, int SubjectID);
    }
}
