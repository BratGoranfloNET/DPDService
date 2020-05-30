using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class EventTrackingParameterRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<EventTrackingParameter> Search(string query)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Query", query, DbType.String);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				var reader = connection.Query<EventTrackingParameter>(
					sql: EventTrackingParameterSearch_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
					//map: _eventtrackingparameterMap
				);

				return reader;
			}
		}
	}
}
