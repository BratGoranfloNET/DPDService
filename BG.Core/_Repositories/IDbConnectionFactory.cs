using System.Data;

namespace BG.Core.Repositories
{
	/// <summary>
	/// Database connection factory.
	/// </summary>
	public interface IDbConnectionFactory
	{
        /// <summary>
        /// Create a database connection.
        /// </summary>
        ///              
		IDbConnection CreateConnection();
	}
}
