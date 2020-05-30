using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data
{
	
	public partial class StateHistoryRepository
	{
		
		public StateHistory Update(StateHistory entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@Id", entity.Id, DbType.Int32);
                    parameters.Add("@Name", entity.Name, DbType.String);
                   
                    parameters.Add("@dpdOrderNr", entity.dpdOrderNr, DbType.String);
                    parameters.Add("@dpdParcelNr", entity.dpdParcelNr, DbType.String);
                   
                    parameters.Add("@newState", entity.newState, DbType.String);
                    parameters.Add("@transitionTime", entity.transitionTime, DbType.DateTime2);
                    parameters.Add("@terminalCode", entity.terminalCode, DbType.String);
                    parameters.Add("@terminalCity", entity.terminalCity, DbType.String);
                    parameters.Add("@incidentCode", entity.incidentCode, DbType.String);
                    parameters.Add("@incidentName", entity.incidentName, DbType.String);
                    parameters.Add("@consignee ", entity.consignee, DbType.String);

                    // Configure outputs
                    parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: StateHistoryUpdate_Proc,
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
