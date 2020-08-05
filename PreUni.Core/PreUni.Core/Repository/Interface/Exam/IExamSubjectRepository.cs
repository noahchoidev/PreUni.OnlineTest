using PreUni.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PreUni.Core.Repository
{
    public interface IExamSubjectRepository : IGenericRepository<ExamSubject>
    {
        ExamSubject GetExamSubjectByID(int examSubjectID);

        Task<IEnumerable<ExamSubject>> GetExamSubjectsByQueryAsync();

        //IList<ExamSubject> GetExamSubjects();

        /*
        int AddExamSubject(ExamSubject examSubject);

        bool UpdateExamSubject(int examSubjectID, ExamSubject examSubject);

        bool DeleteExamSubject(int examSubjectID);
        */
    }
}
