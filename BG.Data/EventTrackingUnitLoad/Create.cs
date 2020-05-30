﻿using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class EventTrackingUnitLoadRepository
	{
		/// <summary>
		/// Create entity.
		/// </summary>
		public EventTrackingUnitLoad Create(EventTrackingUnitLoad entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();
                    					
					parameters.Add("@Name", entity.Name, DbType.String);
                    parameters.Add("@EventTrackingParameterId", entity.EventTrackingParameterId, DbType.Int32);
                    parameters.Add("@article", entity.article, DbType.String);
                    parameters.Add("@descript", entity.descript, DbType.String);
                    parameters.Add("@declared_value", entity.declared_value, DbType.String);
                    parameters.Add("@parcel_num", entity.parcel_num, DbType.String);
                    parameters.Add("@npp_amount", entity.npp_amount, DbType.String);
                    parameters.Add("@vat_percent", entity.vat_percent, DbType.Int32);
                    parameters.Add("@vat_percentSpecified", entity.vat_percentSpecified, DbType.Boolean);
                    parameters.Add("@without_vat", entity.without_vat, DbType.Boolean);
                    parameters.Add("@without_vatSpecified", entity.without_vatSpecified, DbType.Boolean);
                    parameters.Add("@countField", entity.countField, DbType.Int32);
                    parameters.Add("@state_name", entity.state_name, DbType.String);
                                                                                
                                    
                    // Configure outputs
                    parameters.Add("@EntityId", dbType: DbType.Int32, direction: ParameterDirection.Output);
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: EventTrackingUnitLoadInsert_Proc,
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
