using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;

namespace BG.Data
{
	
	public partial class TagRepository
	{
		
		public Tag GetById(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				//var reader = connection.Query(
				//	sql: TagSelect_Proc,
				//	commandType: CommandType.StoredProcedure,
				//	param: parameters,
				//	map: _tagMap
				//);

                var reader = connection.Query<Tag>(
                    sql: TagSelect_Proc,
                    commandType: CommandType.StoredProcedure,
                    param: parameters                    
                );

                return reader.SingleOrDefault();
			}
		}
	}
}
