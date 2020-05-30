using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data.Events
{
	/// <summary>
	/// Partial events repository implementation.
	/// </summary>
	public partial class EventsRepository
	{
		/// <summary>
		/// Used by the create and update methods to add/remove event related images.
		/// </summary>
		public void EventImagesSet(IDbConnection dbConnection, IDbTransaction transaction, List<EventImage> images, int eventId, bool cleanup)
		{
			if (cleanup)
			{
				var parameters = new DynamicParameters();

				parameters.Add(@"EventId", eventId, DbType.Int32);

				dbConnection.Execute(
					sql: EventImagesCleanup_Proc,
					commandType: CommandType.StoredProcedure,
					transaction: transaction,
					param: parameters
				);
			}

			foreach (var image in images)
			{
				var parameters = new DynamicParameters();

				parameters.Add("@EventId", eventId, DbType.Int32);
				parameters.Add("@ImageBlobId", image.Id, DbType.Guid);
				parameters.Add("@OrderIndex", image.OrderIndex, DbType.Int32);
				parameters.Add("@Label", image.Label, DbType.String);
				parameters.Add("@Description", image.Description, DbType.String);

				// Configure outputs
				parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

				dbConnection.Query(
					sql: EventImagesInsert_Proc,
					commandType: CommandType.StoredProcedure,
					transaction: transaction,
					param: parameters
				);

				// Check for errors
				string errorMessage = parameters.Get<string>("@ErrorMessage");

				if (!string.IsNullOrEmpty(errorMessage))
					throw new RepositoryException(errorMessage);
			}
		}
	}
}
