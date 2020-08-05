using Dapper;
using PreUni.Core.ConnectionFactory;
using PreUni.Core.Model;
using PreUni.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PreUni.OnlineTest.DAL.Repository
{
    public class ExamRepository : GenericRepository<Exam>, IExamRepository
    {

        public ExamRepository(IPreUniOnlineConnectionFactory _connectionFactory) : base(_connectionFactory)
        {
        }

        public Exam GetExamByID(int examID)
        {
            var Exam = new Exam();
            var procName = "spExamFetch";
            var param = new DynamicParameters();
            param.Add("@ExamID", examID);

            try
            {
                var multiResult = SqlMapper.QueryMultiple(_connectionFactory.GetConnection,
                                                                    procName, param, commandType: CommandType.StoredProcedure);

                Exam = multiResult.ReadFirstOrDefault<Exam>();
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }

            return Exam;
        }

        public Task<IEnumerable<Exam>> GetExamsBySpQuery()
        {
            var sp = "dbo.spExamInfo_GetAll";

            IDbConnection conn = _connectionFactory.GetConnection;
            
            var listWaiting = conn.QueryAsync<Exam>(sp);

            return listWaiting;
        }

        public int AddExam(Exam exam)
        {
            string procName = "spExamInsert";
            var param = new DynamicParameters();
            int ExamID = 0;

            param.Add("@ExamID", exam.ExamID, null, ParameterDirection.Output);

            try
            {
                SqlMapper.Execute(_connectionFactory.GetConnection,
                procName, param, commandType: CommandType.StoredProcedure);

                ExamID = param.Get<int>("@ExamID");
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }

            return ExamID;
        }

        public bool UpdateExam(int ExamID, Exam exam)
        {
            string procName = "spExamUpdate";
            var param = new DynamicParameters();
            bool IsSuccess = true;

            param.Add("@ExamID", ExamID, null, ParameterDirection.Input);

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

        public bool DeleteExam(int examID)
        {
            bool IsDeleted = true;
            var SqlQuery = @"DELETE FROM Exam WHERE ExamID = @ID";

            IDbConnection conn = _connectionFactory.GetConnection;

            var rowsaffected = conn.Execute(SqlQuery, new { ID = examID });
            if (rowsaffected <= 0)
            {
                IsDeleted = false;
            }
            return IsDeleted;
        }
    }
}
