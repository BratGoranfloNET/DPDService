using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{	
	public partial class EventTrackingTypeRepository
	{
		public IEnumerable<EventTrackingType> GetAll()
		{
			var parameters = new DynamicParameters();

			parameters.Add("@IsDeleted", false, DbType.Boolean);

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


                return reader;
			}
		}
	}
}
