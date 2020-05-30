using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;

namespace BG.Data
{
	/// <summary>
	/// Partial EventType repository implementation.
	/// </summary>
	public partial class EventTypeRepository
	{
		/// <summary>
		/// Get entity.
		/// </summary>
		public EventType GetById(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

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
                
                return reader.SingleOrDefault();

			}
		}
	}
}
