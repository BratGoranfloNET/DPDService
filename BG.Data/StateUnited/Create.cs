using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class StateUnitedRepository
	{
		/// <summary>
		/// Create entity.
		/// </summary>
		public StateUnited Create(StateUnited entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();
                    					
					parameters.Add("@Name", entity.Name, DbType.String);
                    parameters.Add("@Count", entity.Count, DbType.Int32);
                    parameters.Add("@StateUnitedParcelsId", entity.StateParcelsUnitedId, DbType.Int32);
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
                    parameters.Add("@consignee", entity.consignee, DbType.String);

                    parameters.Add("@EventName", entity.EventName, DbType.String);

                    parameters.Add("@DeliveryAddress", entity.DeliveryAddress, DbType.String);
                    parameters.Add("@DeliveryCity", entity.DeliveryCity, DbType.String);
                    parameters.Add("@DeliveryVariant", entity.DeliveryVariant, DbType.String);
                    parameters.Add("@DeliveryPointCode", entity.DeliveryPointCode, DbType.String);
                    parameters.Add("@DeliveryInterval", entity.DeliveryInterval, DbType.String);

                    parameters.Add("@PickupAddress", entity.PickupAddress, DbType.String);
                    parameters.Add("@PickupCity", entity.PickupCity, DbType.String);
                    parameters.Add("@PointCity ", entity.PointCity, DbType.String);
                    parameters.Add("@Consignee2", entity.Consignee2, DbType.String);
                    parameters.Add("@Consignor", entity.Consignor, DbType.String);


                    parameters.Add("@EventReason", entity.EventReason, DbType.String);
                    parameters.Add("@ProblemName", entity.ProblemName, DbType.String);
                    parameters.Add("@ReasonName", entity.ReasonName, DbType.String);
                    parameters.Add("@RejectionReason", entity.RejectionReason, DbType.String);
                    parameters.Add("@OrderType", entity.OrderType, DbType.String);
                    parameters.Add("@MomentLocZone", entity.MomentLocZone, DbType.String);



                    // Configure outputs
                    parameters.Add("@EntityId", dbType: DbType.Int32, direction: ParameterDirection.Output);
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: StateUnitedInsert_Proc,
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
