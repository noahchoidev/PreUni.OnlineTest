using Dapper;
using PreUni.Core.ConnectionFactory;
using PreUni.Core.Model;
using PreUni.Core.Repository;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PreUni.OnlineTest.DAL.Repository
{
    public class ITakeExamNowRepository : GenericRepository<ITakeExamNow>, IITakeExamNowRepository
    {
        public ITakeExamNowRepository(IPreUniOnlineConnectionFactory _connectionFactory) : base(_connectionFactory)
        {
        }

        /// <summary>
        /// Accessing a table, ITakeNowExam and returning all lists of it using Query
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ITakeExamNowViewModel>> GetITakeExamNowListAsync(int StudentID)
        {
            var procName = "spITakeExamNowFromStudent";
            var param = new DynamicParameters();
            param.Add("@StudentID", StudentID);

            IDbConnection conn = _connectionFactory.GetConnection;

            var result = conn.QueryAsync<ITakeExamNowViewModel>(procName, param, commandType: CommandType.StoredProcedure);

            return result;
        }

        public Task<ITakeExamNowViewModel> GetITakeExamNow(int ITakeExamNowID)
        {
            var procName = "spITakeExamNowFromID";
            var param = new DynamicParameters();
            param.Add("@ITakeExamNowID", ITakeExamNowID);

            IDbConnection conn = _connectionFactory.GetConnection;

            var result = conn.QueryFirstOrDefaultAsync<ITakeExamNowViewModel>(procName, param, commandType: CommandType.StoredProcedure);

            return result;
        }

        /*
        public ITakeExamNow GetITakeExamNowByID(int iTakeExamNowID)
        {
            var ITakeExamNow = new ITakeExamNow();
            var procName = "spITakeExamNowFetch";
            var param = new DynamicParameters();
            param.Add("@ITakeExamNowID", iTakeExamNowID);

            try
            {
                using (var multiResult = SqlMapper.QueryMultiple(_connectionFactory.GetConnection,
                                                                    procName, param, commandType: CommandType.StoredProcedure))
                {
                    ITakeExamNow = multiResult.ReadFirstOrDefault<ITakeExamNow>();
                    //ITakeExamNow.Territories = multiResult.Read<ITakeExamNowTerritory>().ToList();
                }
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }

            return ITakeExamNow;
        }
        
        /// <summary>
        /// Accessing a table, ITakeNowExam and returning all lists of it using store procedure. 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<ITakeExamNow>> GetITakeExamNow_All()
        {
            IDbConnection connectiopn = _connectionFactory.GetConnection;
            var ITakeExamNowList = connectiopn.QueryAsync<ITakeExamNow>("dbo.spITakeExamNow_GetAll");


            return ITakeExamNowList;
        }


        


        public int AddITakeExamNow(ITakeExamNow iTakeExamNow)
        {
            string procName = "spITakeExamNowInsert";
            var param = new DynamicParameters();
            int ITakeExamNowID = 0;

            param.Add("@ITakeExamNowID", iTakeExamNow.ITakeExamNowID, null, ParameterDirection.Output);

            try
            {
                SqlMapper.Execute(_connectionFactory.GetConnection,
                procName, param, commandType: CommandType.StoredProcedure);

                ITakeExamNowID = param.Get<int>("@ITakeExamNowID");
            }
            finally
            {
                _connectionFactory.CloseConnection();
            }

            return ITakeExamNowID;
        }

        public bool DeleteITakeExamNow(int iTakeExamNowID)
        {
            bool IsDeleted = true;
            var SqlQuery = @"DELETE FROM ITakeExamNow WHERE ITakeExamNowID = @ID";

            using (IDbConnection conn = _connectionFactory.GetConnection)
            {
                var rowsaffected = conn.Execute(SqlQuery, new { ID = iTakeExamNowID });
                if (rowsaffected <= 0)
                {
                    IsDeleted = false;
                }
            }
            return IsDeleted;
        }

        public bool UpdateITakeExamNow(int ITakeExamNowID, ITakeExamNow iTakeExamNow)
        {
            string procName = "spITakeExamNowUpdate";
            var param = new DynamicParameters();
            bool IsSuccess = true;

            param.Add("@ITakeExamNowID", ITakeExamNowID, null, ParameterDirection.Input);

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
        */
    }
}
