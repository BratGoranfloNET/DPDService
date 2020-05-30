using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{	
	public partial class StateParcelsRepository
	{
		public IEnumerable<StateParcels> GetAll()
		{
			var parameters = new DynamicParameters();

			parameters.Add("@IsDeleted", false, DbType.Boolean);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{

				//var reader = connection.Query(
				//	sql: StateParcelsSelect_Proc,
				//	commandType: CommandType.StoredProcedure,
				//	param: parameters,
				//	map: _stateparcelsMap
				//);
                
                var reader = connection.Query<StateParcels>(
                    sql: StateParcelsSelect_Proc,
                    commandType: CommandType.StoredProcedure,
                    param: parameters
                );


                return reader;
			}
		}
	}
}
