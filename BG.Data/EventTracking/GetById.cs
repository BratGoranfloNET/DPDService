using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;

namespace BG.Data
{
	
	public partial class EventTrackingRepository
	{
		
		public EventTracking GetById(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				//var reader = connection.Query(
				//	sql: EventTrackingSelect_Proc,
				//	commandType: CommandType.StoredProcedure,
				//	param: parameters,
				//	map: _eventtrackingMap
				//);

                var reader = connection.Query<EventTracking>(
                    sql: EventTrackingSelect_Proc,
                    commandType: CommandType.StoredProcedure,
                    param: parameters                    
                );

                return reader.SingleOrDefault();
			}
		}
	}
}
