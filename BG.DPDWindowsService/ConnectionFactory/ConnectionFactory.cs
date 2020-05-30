using System.Data;
using System.Data.SqlClient;
//using System.Web.Configuration;
using System.Configuration;
using BG.Core;
using BG.Core.Repositories;

namespace BG.DPDWindowsService
{
    
    public class ConnectionFactory : IDbConnectionFactory
    {
        private string _connectionString = null;              

        
        public ConnectionFactory()
        {
           _connectionString = ConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
                      
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
