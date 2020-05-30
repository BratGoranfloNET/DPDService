using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class EventTrackingParameterRepository
	{
		/// <summary>
		/// Create entity.
		/// </summary>
		public EventTrackingParameter Create(EventTrackingParameter entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();
                    					
					parameters.Add("@Name", entity.Name, DbType.String);
                    parameters.Add("@EventTrackingTypeId", entity.EventTrackingTypeId, DbType.Int32);
                    parameters.Add("@paramName", entity.paramName, DbType.String);
                    parameters.Add("@valueString", entity.valueString, DbType.String);
                    parameters.Add("@valueDecimal", entity.valueDecimal, DbType.Decimal);
                    parameters.Add("@valueDecimalSpecified", entity.valueDecimalSpecified, DbType.Boolean);
                    parameters.Add("@valueDateTime", entity.valueDateTime, DbType.DateTime2);
                    parameters.Add("@valueDateTimeSpecified", entity.valueDateTimeSpecified, DbType.Boolean);
                    parameters.Add("@type", entity.type, DbType.String);
                                                                                                                                          
                    // Configure outputs
                    parameters.Add("@EntityId", dbType: DbType.Int32, direction: ParameterDirection.Output);
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: EventTrackingParameterInsert_Proc,
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
