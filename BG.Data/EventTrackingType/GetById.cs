using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;

namespace BG.Data
{
	
	public partial class EventTrackingTypeRepository
	{
		
		public EventTrackingType GetById(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				//var reader = connection.Query(
				//	sql: EventTrackingTypeSelect_Proc,
				//	commandType: CommandType.StoredProcedure,
				//	param: parameters,
				//	map: _eventtrackingtypeMap
				//);

                var reader = connection.Query<EventTrackingType>(
                    sql: EventTrackingTypeSelect_Proc,
                    commandType: CommandType.StoredProcedure,
                    param: parameters                    
                );

                return reader.SingleOrDefault();
			}
		}
	}
}
