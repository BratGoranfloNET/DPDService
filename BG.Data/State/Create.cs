using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class StateRepository
	{
		/// <summary>
		/// Create entity.
		/// </summary>
		public State Create(State entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();
                    					
					parameters.Add("@Name", entity.Name, DbType.String);
                    parameters.Add("@StateParcelsId", entity.StateParcelsId, DbType.Int32);
                    parameters.Add("@clientOrderNr", entity.clientOrderNr, DbType.String);
                    parameters.Add("@clientParcelNr", entity.clientParcelNr, DbType.String);
                    parameters.Add("@dpdOrderNr", entity.dpdOrderNr, DbType.String);
                    parameters.Add("@dpdParcelNr", entity.dpdParcelNr, DbType.String);
                    parameters.Add("@pickupDate", entity.pickupDate, DbType.DateTime2);
                    parameters.Add("@dpdOrderReNr", entity.dpdOrderReNr, DbType.String);
                    parameters.Add("@dpdParcelReNr", entity.dpdParcelReNr, DbType.String);
                    parameters.Add("@isReturn", entity.isReturn, DbType.Boolean);
                    parameters.Add("@isReturnSpecified", entity.isReturnSpecified, DbType.Boolean);
                    parameters.Add("@planDeliveryDate", entity.planDeliveryDate, DbType.DateTime2);
                    parameters.Add("@planDeliveryDateSpecified", entity.planDeliveryDateSpecified, DbType.Boolean);
                    parameters.Add("@newState", entity.newState, DbType.String);
                    parameters.Add("@transitionTime", entity.transitionTime, DbType.DateTime2);
                    parameters.Add("@terminalCode", entity.terminalCode, DbType.String);
                    parameters.Add("@terminalCity", entity.terminalCity, DbType.String);
                    parameters.Add("@incidentCode", entity.incidentCode, DbType.String);
                    parameters.Add("@incidentName", entity.incidentName, DbType.String);
                    parameters.Add("@consignee ", entity.consignee, DbType.String);
                                                                                                                                           
                    // Configure outputs
                    parameters.Add("@EntityId", dbType: DbType.Int32, direction: ParameterDirection.Output);
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: StateInsert_Proc,
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
