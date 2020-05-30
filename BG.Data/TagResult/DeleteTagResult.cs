using Dapper;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial Department repository implementation.
	/// </summary>
	public partial class TagResultRepository
    {
		/// <summary>
		/// Delete entity.
		/// </summary>
		public void DeleteTagResult(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Execute(
					sql: TagResultDelete_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
				);
			}
		}
	}
}
