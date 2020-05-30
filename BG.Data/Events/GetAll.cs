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
		public IEnumerable<Event> GetAll()
		{
			var parameters = new DynamicParameters();

			parameters.Add("@IsDeleted", false, DbType.Boolean);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				using (var reader = connection.QueryMultiple(sql: EventsSelect_Proc, commandType: CommandType.StoredProcedure, param: parameters))
				{
					var entities = BuildEntitiesList(reader);

					return entities;
				}
			}
		}
	}
}
