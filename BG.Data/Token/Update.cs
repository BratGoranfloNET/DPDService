using Dapper;
using BG.Core.Entities;
using System;
using System.Data;

namespace BG.Data
{
	

	public partial class TokenRepository
	{
		/// <summary>
		/// Get entity.
		/// </summary>
		public Token Update(Token entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@Id", entity.Id, DbType.Int32);
                    parameters.Add("@UserId", entity.UserId, DbType.Int32);
                    parameters.Add("@TokenString", entity.TokenString, DbType.String);
                    parameters.Add("@IP", entity.IP, DbType.String);

                    // Configure outputs
                    parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: TokenUpdate_Proc,
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
