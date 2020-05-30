using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data
{
	
	public partial class CategoryRepository
    {
		/// <summary>
		/// Get entity.
		/// </summary>
		public Category Update(Category entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@Id", entity.Id, DbType.Int32);
                    parameters.Add("@ParentId", entity.ParentId, DbType.Int32);
                    parameters.Add("@Level", entity.Level, DbType.Int32);
                    parameters.Add("@Title", entity.Title, DbType.String);
                    parameters.Add("@Importance", entity.Importance, DbType.Int32);
                    parameters.Add("@Description", entity.Description, DbType.String);
                    parameters.Add("@ImageBlobId", entity.ImageBlobId, DbType.Guid);

                    // Configure outputs
                    parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: CategoryUpdate_Proc,
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
