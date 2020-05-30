using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data.Users
{
	/// <summary>
	/// Partial users repository implementation.
	/// </summary>
	public partial class UsersRepository
	{
		/// <summary>
		/// Get all entities.
		/// </summary>
		public IEnumerable<User> Search(string query)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Query", query, DbType.String);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				using (var reader = connection.QueryMultiple(sql: UsersSearch_Proc, commandType: CommandType.StoredProcedure, param: parameters))
				{
					var entities = BuildEntitiesList(reader);

					return entities;
				}
			}
		}
	}
}
