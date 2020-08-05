using PreUni.Core.ConnectionFactory;
using PreUni.Core.Model;
using PreUni.Core.Repository;
using System;
using System.Collections.Generic;

namespace PreUni.OnlineTest.DAL.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private IPreUniOnlineConnectionFactory _connectionFactory;

        public QuestionRepository(IPreUniOnlineConnectionFactory _connectionFactory)
        {
            this._connectionFactory = _connectionFactory;
        }
        
        public int AddQuestion(Question question)
        {
            throw new NotImplementedException();
        }

        public bool DeleteQuestion(int questionID)
        {
            throw new NotImplementedException();
        }

        public Question GetQuestionByID(int questionID)
        {
            throw new NotImplementedException();
        }

        public IList<Question> GetQuestionsByQuery()
        {
            throw new NotImplementedException();
        }

        public bool UpdateQuestion(int questionID, Question question)
        {
            throw new NotImplementedException();
        }
    }
}
