using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data
{
	
	public partial class StateParcelsUnitedRepository
	{
		
		public StateParcelsUnited Update(StateParcelsUnited entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@Id", entity.Id, DbType.Int32);					
					parameters.Add("@Name", entity.Name, DbType.String);
                    parameters.Add("@docId", entity.docId, DbType.Int64);
                    parameters.Add("@docDate", entity.docDate, DbType.DateTime2);
                    parameters.Add("@clientNumber", entity.clientNumber, DbType.Int64);
                    parameters.Add("@resultComplete", entity.resultComplete, DbType.Boolean);

                    // Configure outputs
                    parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: StateParcelsUnitedUpdate_Proc,
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
