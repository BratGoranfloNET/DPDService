using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data.Locations
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class LocationsRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<Location> Search(string query)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Query", query, DbType.String);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				var reader = connection.Query(
					sql: LocationsSearch_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters,
					map: _locationMap
				);

				return reader;
			}
		}
	}
}
