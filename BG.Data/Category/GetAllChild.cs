using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class CategoryRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<Category> GetAllChild()
		{

            var parameters = new DynamicParameters();

            parameters.Add("@IsDeleted", false, DbType.Boolean);

            using (var connection = _dbConnectionFactory.CreateConnection())
            {
                var reader = connection.Query(
                    sql: CategoryChildesOnlySelect_Proc,
                    commandType: CommandType.StoredProcedure,
                    param: parameters,
                    map: _categoryMap
                );

                return reader;
            }
            
		}
	}
}
