using BG.Core.Repositories;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace BG.Web
{
	public class WebConnectionFactory : IDbConnectionFactory
	{
		private string _connectionString = null;

		public WebConnectionFactory()
		{
			_connectionString = WebConfigurationManager.ConnectionStrings["SqlServerConnection"].ConnectionString;
		}
		
		public IDbConnection CreateConnection()
		{
			return new SqlConnection(_connectionString);
		}
	}
}
