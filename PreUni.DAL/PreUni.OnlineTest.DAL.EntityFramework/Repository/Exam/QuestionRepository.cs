using PreUni.Core.ConnectionFactory;
using PreUni.Core.Model;
using PreUni.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace PreUni.OnlineTest.DAL.EntityFramework
{
    public class QuestionRepository : GenericRepository<Question>, IQuestionRepository
    {
        private DbContext mPreUniDbContext;

        public QuestionRepository(DbContext dbContext) : base(dbContext)
        {
            mPreUniDbContext = dbContext as PreUniDbContext;
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
