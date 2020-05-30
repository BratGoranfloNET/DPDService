using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class ArticleRepository
	{
		/// <summary>
		/// Get entity.
		/// </summary>
		public Article GetById(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
                var reader = connection.Query(
                    sql: ArticleSelect_Proc,
                    commandType: CommandType.StoredProcedure,
                    param: parameters,
                    map: _articleMap
                );

                return reader.SingleOrDefault();



            }
		}
	}
}
