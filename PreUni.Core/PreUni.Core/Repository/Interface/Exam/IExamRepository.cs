using PreUni.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreUni.Core.Repository
{
    public interface IExamRepository : IGenericRepository<Exam>
    {
        Exam GetExamByID(int examID);

        //IList<Exam> GetExamsByQuery();

        Task<IEnumerable<Exam>> GetExamsBySpQuery();

        int AddExam(Exam exam);

        bool UpdateExam(int examID, Exam exam);

        bool DeleteExam(int examID);
        
    }
}
