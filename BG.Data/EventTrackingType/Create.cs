using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class EventTrackingTypeRepository
	{
		/// <summary>
		/// Create entity.
		/// </summary>
		public EventTrackingType Create(EventTrackingType entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();
                    					
					parameters.Add("@Name", entity.Name, DbType.String);
                    parameters.Add("@EventTrackingId", entity.EventTrackingId, DbType.Int32);
                    parameters.Add("@clientOrderNr", entity.clientOrderNr, DbType.String);
                    parameters.Add("@clientCodeInternal", entity.clientCodeInternal, DbType.String);
                    parameters.Add("@clientParcelNr", entity.clientParcelNr, DbType.String);
                    parameters.Add("@dpdOrderNr", entity.dpdOrderNr, DbType.String);
                    parameters.Add("@dpdParcelNr", entity.dpdParcelNr, DbType.String);
                    parameters.Add("@eventNumber", entity.eventNumber, DbType.String);
                    parameters.Add("@eventCode", entity.eventCode, DbType.String);
                    parameters.Add("@eventName", entity.eventName, DbType.String);
                    parameters.Add("@reasonCode", entity.reasonCode, DbType.String);
                    parameters.Add("@reasonName", entity.reasonName, DbType.String);
                    parameters.Add("@eventDate", entity.eventDate, DbType.String);

                    // Configure outputs
                    parameters.Add("@EntityId", dbType: DbType.Int32, direction: ParameterDirection.Output);
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: EventTrackingTypeInsert_Proc,
						commandType: CommandType.StoredProcedure,
						transaction: transaction,
						param: parameters
					);

					// Check for errors
					string errorMessage = parameters.Get<string>("@ErrorMessage");

					if (!string.IsNullOrEmpty(errorMessage))
						throw new RepositoryException(errorMessage);

					// Set the id
					entity.Id = parameters.Get<int>("@EntityId");

					transaction.Commit();

					return entity;
				}
			}
		}
	}
}
