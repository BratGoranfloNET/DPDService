using Dapper;
using System.Data;

namespace BG.Data
{

	public partial class TokenRepository
	{
		/// <summary>
		/// Delete entity.
		/// </summary>
		public void Delete(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Execute(
					sql: TokenDelete_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
				);
			}
		}
	}
}
