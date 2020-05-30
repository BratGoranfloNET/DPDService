using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data.Blobs
{
	/// <summary>
	/// Partial blobs repository implementation.
	/// </summary>
	public partial class BlobsRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<Blob> GetAll()
		{
			var parameters = new DynamicParameters();

			parameters.Add("@IsDeleted", false, DbType.Boolean);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				var query = connection.Query<Blob>(
					sql: BlobsSelect_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
				);

				return query;
			}
		}
	}
}
