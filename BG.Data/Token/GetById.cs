using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;

namespace BG.Data
{
	/// <summary>
	/// Partial Token repository implementation.
	/// </summary>
	public partial class TokenRepository
	{
		/// <summary>
		/// Get entity.
		/// </summary>
		public Token GetById(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
                var reader = connection.Query<Token>(
                   sql: TokenSelect_Proc,
                   commandType: CommandType.StoredProcedure,
                   param: parameters
               );

                return reader.SingleOrDefault();
            }
		}
	}
}
