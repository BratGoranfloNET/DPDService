using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class ArticleRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<Article> GetAll()
		{
			var parameters = new DynamicParameters();

			parameters.Add("@IsDeleted", false, DbType.Boolean);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
                var reader = connection.Query(
                    sql: ArticleSelect_Proc,
                    commandType: CommandType.StoredProcedure,
                    param: parameters,
                    map: _articleMap
                //splitOn: "Id, CategoryId"
                );

                return reader;


            }
		}
	}
}
