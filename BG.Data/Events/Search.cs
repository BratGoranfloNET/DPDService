using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data.Events
{
	/// <summary>
	/// Partial events repository implementation.
	/// </summary>
	public partial class EventsRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<Event> Search(string query)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Query", query, DbType.String);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				using (var reader = connection.QueryMultiple(sql: EventsSearch_Proc, commandType: CommandType.StoredProcedure, param: parameters))
				{
					var entities = BuildEntitiesList(reader);

					return entities;
				}
			}
		}
	}
}
