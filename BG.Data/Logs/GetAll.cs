using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data.Logs
{
	/// <summary>
	/// Partial logs repository implementation.
	/// </summary>
	public partial class LogsRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<LogEntry> GetAll(int top = 30)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Top", top, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				var reader = connection.Query<LogEntry>(
					sql: LogsSelect_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
				);

				return reader;
			}
		}
	}
}
