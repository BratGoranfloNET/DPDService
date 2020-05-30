using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{	
	public partial class StateParcelsUnitedRepository
	{
		public IEnumerable<StateParcelsUnited> GetAll()
		{
			var parameters = new DynamicParameters();

			parameters.Add("@IsDeleted", false, DbType.Boolean);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{

				//var reader = connection.Query(
				//	sql: StateParcelsUnitedSelect_Proc,
				//	commandType: CommandType.StoredProcedure,
				//	param: parameters,
				//	map: _stateparcelsMap
				//);
                
                var reader = connection.Query<StateParcelsUnited>(
                    sql: StateParcelsUnitedSelect_Proc,
                    commandType: CommandType.StoredProcedure,
                    param: parameters
                );


                return reader;
			}
		}
	}
}
