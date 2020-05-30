using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{
	
	public partial class TagResultRepository
    {
		
		public IEnumerable<TagResult> GetTagsIdsByArticletId(int departmentId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@IsDeleted", false, DbType.Boolean);
            parameters.Add("@ArticleId", departmentId, DbType.Int32);

            using (var connection = _dbConnectionFactory.CreateConnection())
			{
                // var reader = connection.Query(
                //	sql: DepartmentSelect_Proc,
                //	commandType: CommandType.StoredProcedure,
                //	param: parameters,
                //	map: _departmentMap
                //  );

                var reader = connection.Query<TagResult>(
                  sql: TagResultSelect_Proc,
                  commandType: CommandType.StoredProcedure,
                  param: parameters
              );

                return reader;
			}
		}
	}
}
