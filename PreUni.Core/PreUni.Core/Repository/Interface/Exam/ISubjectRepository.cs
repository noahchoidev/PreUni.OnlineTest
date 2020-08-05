using PreUni.Core.Model;
using System.Collections.Generic;

namespace PreUni.Core.Repository
{
    public interface ISubjectRepository : IGenericRepository<Subject>
    {
        IList<Subject> GetSubjectsByQuery();

        Subject GetSubjectByID(int subjectID);

        int AddSubject(Subject subject);

        bool UpdateSubject(int subjectID, Subject subject);

        bool DeleteSubject(int subjectID);
        
    }
}
