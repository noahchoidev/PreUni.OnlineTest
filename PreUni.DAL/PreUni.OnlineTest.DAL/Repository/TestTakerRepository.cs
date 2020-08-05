using Dapper;
using PreUni.Core.ConnectionFactory;
using PreUni.Core.Model;
using PreUni.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PreUni.OnlineTest.DAL.Repository
{
    public class TestTakerRepository : ITestTakerRepository
    {
        private IPreUniOnlineConnectionFactory _connectionFactory;

        public TestTakerRepository(IPreUniOnlineConnectionFactory _connectionFactory)
        {
            this._connectionFactory = _connectionFactory;
        }

        public int AddTestTaker(TestTaker testTaker)
        {
            string procName = "spTestTakerInsert";
            var param = new DynamicParameters();
            int TestTakerID = 0;

            param.Add("@TestTakerID", testTaker.TestTakerID, null, ParameterDirection.Output);

            try
            {
                SqlMapper.Execute(_connectionFactory.GetConnection,
                procName, param, commandType: CommandType.StoredProcedure);

                TestTakerID = param.Get<int>("@TestTakerID");
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }

            return TestTakerID;
        }

        public bool DeleteTestTaker(int testTakerID)
        {
            bool IsDeleted = true;
            var SqlQuery = @"DELETE FROM TestTaker WHERE TestTakerID = @ID";

            using (IDbConnection conn = _connectionFactory.GetConnection)
            {
                var rowsaffected = conn.Execute(SqlQuery, new { ID = testTakerID });
                if (rowsaffected <= 0)
                {
                    IsDeleted = false;
                }
            }
            return IsDeleted;
        }

        public TestTaker GetTestTakerByID(int testTakerID)
        {
            var TestTaker = new TestTaker();
            var procName = "spTestTakerFetch";
            var param = new DynamicParameters();
            param.Add("@TestTakerID", testTakerID);

            try
            {
                using (var multiResult = SqlMapper.QueryMultiple(_connectionFactory.GetConnection,
                                                                    procName, param, commandType: CommandType.StoredProcedure))
                {
                    TestTaker = multiResult.ReadFirstOrDefault<TestTaker>();
                    //TestTaker.Territories = multiResult.Read<TestTakerTerritory>().ToList();
                }
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }

            return TestTaker;
        }

        public IList<TestTaker> GetTestTakersByQuery()
        {
            var EmpList = new List<TestTaker>();
            var SqlQuery = @"SELECT [TestTakerID],[LastName],[FirstName],[Title],[TitleOfCourtesy],[City],[Country] FROM [PreUniOnline].[dbo].[TestTaker]";

            using (IDbConnection conn = _connectionFactory.GetConnection)
            {
                var result = conn.Query<TestTaker>(SqlQuery);
                return result.ToList();
            }
        }

        public bool UpdateTestTaker(int TestTakerID, TestTaker testTaker)
        {
            string procName = "spTestTakerUpdate";
            var param = new DynamicParameters();
            bool IsSuccess = true;

            param.Add("@TestTakerID", TestTakerID, null, ParameterDirection.Input);

            try
            {
                var rowsAffected = SqlMapper.Execute(_connectionFactory.GetConnection,
                procName, param, commandType: CommandType.StoredProcedure);
                if (rowsAffected <= 0)
                {
                    IsSuccess = false;
                }
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }

            return IsSuccess;
        }

    }
}
