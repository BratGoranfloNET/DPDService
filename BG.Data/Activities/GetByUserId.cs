using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data.Activities
{
	/// <summary>
	/// Partial activities repository implementation.
	/// </summary>
	public partial class ActivitiesRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<Activity> GetByUserId(int userId, int? top = 15)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@UserId", userId, DbType.Int32);
			parameters.Add("@Top", top, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				var reader = connection.Query<Activity>(
					sql: ActivitiesSelect_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
				);

				return reader;
			}
		}
	}
}
