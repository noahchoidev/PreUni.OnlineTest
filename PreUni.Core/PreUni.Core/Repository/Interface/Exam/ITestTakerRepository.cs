using PreUni.Core.Model;
using System.Collections.Generic;

namespace PreUni.Core.Repository
{
    public interface ITestTakerRepository
    {
        IList<TestTaker> GetTestTakersByQuery();

        TestTaker GetTestTakerByID(int testTakerID);

        int AddTestTaker(TestTaker testTaker);

        bool UpdateTestTaker(int testTakerID, TestTaker testTaker);

        bool DeleteTestTaker(int testTakerID);
        
    }
}
