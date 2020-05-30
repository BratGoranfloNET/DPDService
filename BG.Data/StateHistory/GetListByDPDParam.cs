using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace BG.Data
{
	
	public partial class StateHistoryRepository
    {
		
		public IEnumerable<StateHistory> GetListByDPDParam(string DPDParam)
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

                var reader = connection.Query<StateHistory>(
                     sql: StateHistorySelect_Proc,
                     commandType: CommandType.StoredProcedure,
                     param: parameters
                 );


                return reader;
            }
		}
	}
}
