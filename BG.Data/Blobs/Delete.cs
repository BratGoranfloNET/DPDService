using Dapper;
using System;
using System.Data;

namespace BG.Data.Blobs
{
	/// <summary>
	/// Partial blobs repository implementation.
	/// </summary>
	public partial class BlobsRepository
	{
		/// <summary>
		/// Delete an entity.
		/// </summary>
		public void Delete(Guid entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Guid);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Execute(
					sql: BlobsDelete_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
				);
			}
		}
	}
}
