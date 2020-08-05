using Dapper;
using PreUni.Core.ConnectionFactory;
using PreUni.Core.Model;
using PreUni.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PreUni.OnlineTest.DAL.Repository
{
    public class ExamSubjectRepository : GenericRepository<ExamSubject>, IExamSubjectRepository
    {
        public ExamSubjectRepository(IPreUniOnlineConnectionFactory _connectionFactory) : base(_connectionFactory)
        {
        }

        public ExamSubject GetExamSubjectByID(int examSubjectID)
        {
            var ExamSubject = new ExamSubject();
            var procName = "spExamSubjectFetch";
            var param = new DynamicParameters();
            param.Add("@ExamSubjectID", examSubjectID);

            try
            {
                using (var multiResult = SqlMapper.QueryMultiple(_connectionFactory.GetConnection,
                                                                    procName, param, commandType: CommandType.StoredProcedure))
                {
                    ExamSubject = multiResult.ReadFirstOrDefault<ExamSubject>();
                    //ExamSubject.Territories = multiResult.Read<ExamSubjectTerritory>().ToList();
                }
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }

            return ExamSubject;
        }

        public Task<IEnumerable<ExamSubject>> GetExamSubjectsByQueryAsync()
        {
            var SqlQuery = @"SELECT TOP (1000) * FROM [PreUniOnline].[dbo].[ExamSubject]";

            IDbConnection conn = _connectionFactory.GetConnection;

            var examSubjects = conn.QueryAsync<ExamSubject>(SqlQuery);
            
            return examSubjects;
        }

        //public IList<ExamSubject> GetExamSubjects()
        //{
        //    var examSubjectList = new List<ExamSubject>();
        //    var sp = "dbo.spExamSubjectInfo_GetAll";

        //    using (IDbConnection conn = _connectionFactory.GetConnection)
        //    {
        //        examSubjectList = conn.Query<ExamSubject>(sp).ToList();
        //        return examSubjectList;
        //    }
        //}
        
        /*
        public int AddExamSubject(ExamSubject examSubject)
        {
            string procName = "spExamSubjectInsert";
            var param = new DynamicParameters();
            int ExamSubjectID = 0;

            param.Add("@ExamSubjectID", examSubject.ExamSubjectID, null, ParameterDirection.Output);

            try
            {
                SqlMapper.Execute(_connectionFactory.GetConnection,
                procName, param, commandType: CommandType.StoredProcedure);

                ExamSubjectID = param.Get<int>("@ExamSubjectID");
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }

            return ExamSubjectID;
        }
        public bool UpdateExamSubject(int ExamSubjectID, ExamSubject examSubject)
        {
            string procName = "spExamSubjectUpdate";
            var param = new DynamicParameters();
            bool IsSuccess = true;

            param.Add("@ExamSubjectID", ExamSubjectID, null, ParameterDirection.Input);

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
        public bool DeleteExamSubject(int examSubjectID)
        {
            bool IsDeleted = true;
            var SqlQuery = @"DELETE FROM ExamSubject WHERE ExamSubjectID = @ID";

            using (IDbConnection conn = _connectionFactory.GetConnection)
            {
                var rowsaffected = conn.Execute(SqlQuery, new { ID = examSubjectID });
                if (rowsaffected <= 0)
                {
                    IsDeleted = false;
                }
            }
            return IsDeleted;
        }
        */
    }
}
