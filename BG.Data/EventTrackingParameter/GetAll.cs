using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{	
	public partial class EventTrackingParameterRepository
	{
		public IEnumerable<EventTrackingParameter> GetAll()
		{
			var parameters = new DynamicParameters();

			parameters.Add("@IsDeleted", false, DbType.Boolean);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{

				//var reader = connection.Query(
				//	sql: EventTrackingParameterSelect_Proc,
				//	commandType: CommandType.StoredProcedure,
				//	param: parameters,
				//	map: _eventtrackingparameterMap
				//);
                
                var reader = connection.Query<EventTrackingParameter>(
                    sql: EventTrackingParameterSelect_Proc,
                    commandType: CommandType.StoredProcedure,
                    param: parameters
                );


                return reader;
			}
		}
	}
}
