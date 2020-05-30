using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class CategoryRepository
	{
		/// <summary>
		/// Get entity.
		/// </summary>
		public Category GetById(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
                var query = connection.Query<Category>(
                       sql: CategorySelect_Proc,
                       commandType: CommandType.StoredProcedure,
                       param: parameters
                   );

                //return reader;
                return query.SingleOrDefault();



            }
		}
	}
}
