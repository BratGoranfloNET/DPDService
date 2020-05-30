using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class TokenRepository
	{
		/// <summary>
		/// Create entity.
		/// </summary>
		public Token Create(Token entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

                    parameters.Add("@UserId", entity.UserId, DbType.Int32);
                    parameters.Add("@TokenString", entity.TokenString, DbType.String);					                    
                    parameters.Add("@IP", entity.IP, DbType.String);					

					// Configure outputs
					parameters.Add("@EntityId", dbType: DbType.Int32, direction: ParameterDirection.Output);
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: TokenInsert_Proc,
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
