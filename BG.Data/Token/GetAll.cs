using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial Token repository implementation.
	/// </summary>
	public partial class TokenRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<Token> GetAll()
		{
			var parameters = new DynamicParameters();

			parameters.Add("@IsDeleted", false, DbType.Boolean);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
                var reader = connection.Query<Token>(
                    sql: TokenSelect_Proc,
                    commandType: CommandType.StoredProcedure,
                    param: parameters
                );

                return reader;
			}
		}
	}
}
