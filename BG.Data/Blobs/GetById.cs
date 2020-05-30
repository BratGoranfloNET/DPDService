using Dapper;
using BG.Core.Entities;
using System;
using System.Data;
using System.Linq;

namespace BG.Data.Blobs
{
	/// <summary>
	/// Partial blobs repository implementation.
	/// </summary>
	public partial class BlobsRepository
	{
		/// <summary>
		/// Get an entity.
		/// </summary>
		public Blob GetById(Guid entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Guid);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				var query = connection.Query<Blob>(
					sql: BlobsSelect_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
				);

				return query.SingleOrDefault();
			}
		}
	}
}
