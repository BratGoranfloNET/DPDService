using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;

namespace BG.Data.Locations
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class LocationsRepository
	{
		/// <summary>
		/// Get entity.
		/// </summary>
		public Location GetById(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				var reader = connection.Query(
					sql: LocationsSelect_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters,
					map: _locationMap
				);

				return reader.SingleOrDefault();
			}
		}
	}
}
