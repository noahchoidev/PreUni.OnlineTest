namespace PreUni.Core.Repository
{
    public interface ICreateRepository
    {
        ITestTakerRepository CreateTestTakerRepository();

        ITestTypeRepository CreateTestTypeRepository();

        IExamRepository CreateExamRepository();

        ISubjectRepository CreateSubjectRepository();

        IExamSubjectRepository CreateExamSubjectRepository();

        IQuestionRepository CreateQuestionRepository();

        IITakeExamNowRepository CreateITakeExamNowRepository();
    }
}
