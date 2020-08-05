using PreUni.Core.Repository;
using System.Data.Entity;

namespace PreUni.OnlineTest.DAL.EntityFramework
{

    public class CreateEFRepository : ICreateRepository
    {
        private readonly DbContext mDbContext;

        public CreateEFRepository(DbContext dbContext)
        {
            mDbContext = dbContext;
        }

        public ITestTakerRepository CreateTestTakerRepository()
        {
            throw new System.NotImplementedException();
        }

        public IExamRepository CreateExamRepository()
        {
            return new ExamRepository(mDbContext);
        }

        public ISubjectRepository CreateSubjectRepository()
        {
            return new SubjectRepository(mDbContext);
        }

        public IExamSubjectRepository CreateExamSubjectRepository()
        {
            return new ExamSubjectRepository(mDbContext);
        }

        public IQuestionRepository CreateQuestionRepository()
        {
            return new QuestionRepository(mDbContext);
        }

        public IITakeExamNowRepository CreateITakeExamNowRepository()
        {
            return new ITakeExamNowRepository(mDbContext);
        }

        public ITestTypeRepository CreateTestTypeRepository()
        {
            return new TestTypeRepository(mDbContext);
        }
    }
}
