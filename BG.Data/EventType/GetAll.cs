using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial EventType repository implementation.
	/// </summary>
	public partial class EventTypeRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<EventType> GetAll()
		{
			var parameters = new DynamicParameters();

			parameters.Add("@IsDeleted", false, DbType.Boolean);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
                //  var reader = connection.Query(
                //	sql: EventTypeSelect_Proc,
                //	commandType: CommandType.StoredProcedure,
                //	param: parameters,
                //	map: _positionMap
                //  );
                
                var reader = connection.Query<EventType>(
                sql: EventTypeSelect_Proc,
                commandType: CommandType.StoredProcedure,
                param: parameters
                );
                
                return reader;

			}
		}
	}
}
