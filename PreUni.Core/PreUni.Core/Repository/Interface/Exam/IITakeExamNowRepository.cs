using PreUni.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreUni.Core.Repository
{
    public interface IITakeExamNowRepository : IGenericRepository<ITakeExamNow>
    {
        Task<IEnumerable<ITakeExamNowViewModel>> GetITakeExamNowListAsync(int StudentID);

        Task<ITakeExamNowViewModel> GetITakeExamNow(int ITakeExamNowID);

        /*
        ITakeExamNow GetITakeExamNowByID(int iTakeExamNowID);

        /// <summary>
        /// Accessing a table, ITakeNowExam and returning all lists of it using store procedure. 
        /// </summary>
        /// <returns></returns>
        IList<ITakeExamNow> GetITakeExamNow_All();

        /// <summary>
        /// Accessing a table, ITakeNowExam and returning all lists of it using Query
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ITakeExamNow>> GetITakeExamNow_All_ByQueryAsync();
        
        int AddITakeExamNow(ITakeExamNow iTakeExamNow);

        bool UpdateITakeExamNow(int ITakeExamNowID, ITakeExamNow iTakeExamNow);

        bool DeleteITakeExamNow(int iTakeExamNowID);

        */
    }
}
