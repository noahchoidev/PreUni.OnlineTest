using System.Data;

namespace PreUni.Core.ConnectionFactory
{
    public interface IPreUniOnlineConnectionFactory
    {

        IDbConnection GetConnection { get; }

        void CloseConnection();
    }
}
