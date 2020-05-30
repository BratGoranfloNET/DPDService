using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;

namespace BG.Data
{
	
	public partial class StateParcelsRepository
	{
		
		public StateParcels GetById(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

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

                return reader.SingleOrDefault();
			}
		}
	}
}
