using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;

namespace BG.Data
{
	
	public partial class StateUnitedRepository
	{
		
		public StateUnited GetByDPDParam(string DPDParam)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@DPDParam", DPDParam, DbType.String);

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

                return reader.SingleOrDefault();
			}
		}
	}
}
