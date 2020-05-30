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
		/// Update entity.
		/// </summary>
		public Event Update(Event entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@Id", entity.Id, DbType.Int32);
					parameters.Add("@Name", entity.Name, DbType.String);
					parameters.Add("@Color", entity.Color, DbType.AnsiString);
					parameters.Add("@StartDate", entity.StartDate, DbType.DateTimeOffset);
					parameters.Add("@EndDate", entity.EndDate, DbType.DateTimeOffset);
					parameters.Add("@LocationId", entity.LocationId, DbType.Int32);
					parameters.Add("@Description", entity.Description, DbType.String);
                    //parameters.Add("@ProductionId", entity.ProductionId, DbType.Int32);
                    parameters.Add("@EventTypeId", entity.EventTypeId, DbType.Int32);
                    parameters.Add("@Fio", entity.Fio, DbType.String);
                    parameters.Add("@StateUnitedId", entity.StateUnitedId, DbType.Int32);

                    // Configure outputs
                    parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: EventsUpdate_Proc,
						commandType: CommandType.StoredProcedure,
						transaction: transaction,
						param: parameters
					);

					// Check for errors
					string errorMessage = parameters.Get<string>("@ErrorMessage");

					if (!string.IsNullOrEmpty(errorMessage))
						throw new RepositoryException(errorMessage);

					EventImagesSet(connection, transaction, images: entity.Images, eventId: entity.Id, cleanup: true);

					transaction.Commit();

					return entity;
				}
			}
		}
	}
}
