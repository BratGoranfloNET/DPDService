using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data.Events
{
	/// <summary>
	/// Partial events repository implementation.
	/// </summary>
	public partial class EventsRepository
	{
		/// <summary>
		/// Get entity.
		/// </summary>
		public Event GetById(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				using (var reader = connection.QueryMultiple(sql: EventsSelect_Proc, commandType: CommandType.StoredProcedure, param: parameters))
				{
					var entity = BuildEntity(reader);

					return entity;
				}
			}
		}
	}
}
