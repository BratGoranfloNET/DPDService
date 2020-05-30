using Dapper;
using System.Data;

namespace BG.Data.Users
{
	/// <summary>
	/// Partial users repository implementation.
	/// </summary>
	public partial class UsersRepository
	{
		/// <summary>
		/// Delete an entity.
		/// </summary>
		public void Delete(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Execute(
					sql: UsersDelete_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
				);
			}
		}
	}
}
