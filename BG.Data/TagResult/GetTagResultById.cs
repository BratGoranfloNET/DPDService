using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;

namespace BG.Data
{
	/// <summary>
	/// Partial Department repository implementation.
	/// </summary>
	public partial class TagResultRepository
    {
		/// <summary>
		/// Get entity.
		/// </summary>
		public TagResult GetTagResultById(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

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

                return reader.SingleOrDefault();
			}
		}
	}
}
