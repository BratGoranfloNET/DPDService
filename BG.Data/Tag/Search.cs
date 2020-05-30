using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class TagRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<Tag> Search(string query)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Query", query, DbType.String);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				var reader = connection.Query<Tag>(
					sql: TagSearch_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
					//map: _tagMap
				);

				return reader;
			}
		}
	}
}
