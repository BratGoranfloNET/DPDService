using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class StateUnitedRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<StateUnited> Search(string query)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Query", query, DbType.String);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				var reader = connection.Query<StateUnited>(
					sql: StateUnitedSearch_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
					//map: _stateMap
				);

				return reader;
			}
		}
	}
}
