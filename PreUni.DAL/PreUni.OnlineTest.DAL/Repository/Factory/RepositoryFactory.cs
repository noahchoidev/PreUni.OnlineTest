using PreUni.Core.ConnectionFactory;
using PreUni.Core.Repository;

namespace PreUni.OnlineTest.DAL.Repository
{
    public class CreateRepository : ICreateRepository
    {
        private readonly IPreUniOnlineConnectionFactory mPreUniOnlineConnectionFactory;

        public CreateRepository(IPreUniOnlineConnectionFactory preUniOnlineConnectionFactory)
        {
            mPreUniOnlineConnectionFactory = preUniOnlineConnectionFactory;
        }

        public ITestTakerRepository CreateTestTakerRepository()
        {
            return new TestTakerRepository(mPreUniOnlineConnectionFactory);
        }

        public IExamRepository CreateExamRepository()
        {
            return new ExamRepository(mPreUniOnlineConnectionFactory);
        }

        public ISubjectRepository CreateSubjectRepository()
        {
            return new SubjectRepository(mPreUniOnlineConnectionFactory);
        }

        public IExamSubjectRepository CreateExamSubjectRepository()
        {
            return new ExamSubjectRepository(mPreUniOnlineConnectionFactory);
        }

        public IQuestionRepository CreateQuestionRepository()
        {
            return new QuestionRepository(mPreUniOnlineConnectionFactory);
        }

        public IITakeExamNowRepository CreateITakeExamNowRepository()
        {
            return new ITakeExamNowRepository(mPreUniOnlineConnectionFactory);
        }

        public ITestTypeRepository CreateTestTypeRepository()
        {
            throw new System.NotImplementedException();
        }
    }
}
