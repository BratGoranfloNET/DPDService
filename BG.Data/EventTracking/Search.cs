using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class EventTrackingRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<EventTracking> Search(string query)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Query", query, DbType.String);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				var reader = connection.Query<EventTracking>(
					sql: EventTrackingSearch_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
					//map: _eventtrackingMap
				);

				return reader;
			}
		}
	}
}
