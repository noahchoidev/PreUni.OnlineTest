using PreUni.Core.ConnectionFactory;
using System.Data;
using System.Data.SqlClient;

namespace PreUni.OnlineTest.DAL
{
    public class PreUniOnlineConnectionFactory : IPreUniOnlineConnectionFactory
    {
        private IDbConnection _connection;

        private string connectionString { get; set; } = "server=.;Database=PreUniOnline;Trusted_Connection=True;";


        public PreUniOnlineConnectionFactory()
        {
        }

        public IDbConnection GetConnection 
        {
            get
            {
                if (_connection == null)
                {
                    _connection = new SqlConnection(connectionString);
                }

                if (string.IsNullOrEmpty(_connection.ConnectionString))
                    _connection.ConnectionString = connectionString;

                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }

                return _connection;
            }
        }

        public void CloseConnection()
        {
            if (_connection != null && _connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }
    }
}
