using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data
{
	
	public partial class EventTrackingParameterRepository
	{
		
		public EventTrackingParameter Update(EventTrackingParameter entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@Id", entity.Id, DbType.Int32);
                    parameters.Add("@Name", entity.Name, DbType.String);
                    parameters.Add("@EventTrackingTypeId", entity.EventTrackingTypeId, DbType.Int32);
                    parameters.Add("@paramNamee", entity.paramName, DbType.String);
                    parameters.Add("@valueString", entity.valueString, DbType.String);
                    parameters.Add("@valueDecimal", entity.valueDecimal, DbType.Decimal);
                    parameters.Add("@valueDecimalSpecified", entity.valueDecimalSpecified, DbType.Boolean);
                    parameters.Add("@valueDateTime", entity.valueDateTime, DbType.DateTime2);
                    parameters.Add("@valueDateTimeSpecified", entity.valueDateTimeSpecified, DbType.Boolean);
                    parameters.Add("@type", entity.type, DbType.String);


                    // Configure outputs
                    parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: EventTrackingParameterUpdate_Proc,
						commandType: CommandType.StoredProcedure,
						transaction: transaction,
						param: parameters
					);

					// Check for errors
					string errorMessage = parameters.Get<string>("@ErrorMessage");

					if (!string.IsNullOrEmpty(errorMessage))
						throw new RepositoryException(errorMessage);

					transaction.Commit();

					return entity;
				}
			}
		}
	}
}
