using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{	
	public partial class StateUnitedRepository
	{
		public IEnumerable<StateUnited> GetAll()
		{
			var parameters = new DynamicParameters();

			parameters.Add("@IsDeleted", false, DbType.Boolean);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{

				//var reader = connection.Query(
				//	sql: StateUnitedSelect_Proc,
				//	commandType: CommandType.StoredProcedure,
				//	param: parameters,
				//	map: _stateMap
				//);
                
                var reader = connection.Query<StateUnited>(
                    sql: StateUnitedSelect_Proc,
                    commandType: CommandType.StoredProcedure,
                    param: parameters
                );


                return reader;
			}
		}
	}
}
