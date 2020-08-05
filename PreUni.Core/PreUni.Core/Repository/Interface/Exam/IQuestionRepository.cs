using PreUni.Core.Model;
using System.Collections.Generic;

namespace PreUni.Core.Repository
{
    public interface IQuestionRepository
    {
        IList<Question> GetQuestionsByQuery();

        Question GetQuestionByID(int questionID);

        int AddQuestion(Question question);

        bool UpdateQuestion(int questionID, Question question);

        bool DeleteQuestion(int questionID);
        
    }
}
