using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial Tag repository implementation.
	/// </summary>
	public partial class TagResultRepository
    {
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<TagResult> GetAll()
		{
			var parameters = new DynamicParameters();

			parameters.Add("@IsDeleted", false, DbType.Boolean);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
                var reader = connection.Query<TagResult>(
                 sql: TagResultSelect_Proc,
                 commandType: CommandType.StoredProcedure,
                 param: parameters
             );

                return reader;
			}
		}
	}
}
