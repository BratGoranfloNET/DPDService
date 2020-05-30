using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial events repository implementation.
	/// </summary>
	public partial class CategoryRepository
    {
		/// <summary>
		/// Create entity.
		/// </summary>
		public Category Create(Category entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

                    parameters.Add("@ParentId", entity.ParentId, DbType.Int32);
                    parameters.Add("@Level", entity.Level, DbType.Int32);                   
					parameters.Add("@AddedBy", entity.AddedBy, DbType.String);
					parameters.Add("@Title", entity.Title, DbType.String);					
					parameters.Add("@Importance", entity.Importance, DbType.Int32);
					parameters.Add("@Description", entity.Description, DbType.String);
                    parameters.Add("@ImageBlobId", entity.ImageBlobId, DbType.Guid);

                    // Configure outputs
                    parameters.Add("@EntityId", dbType: DbType.Int32, direction: ParameterDirection.Output);
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: CategoryInsert_Proc,
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

					// Set images
					//EventImagesSet(connection, transaction, images: entity.Images, eventId: entity.Id, cleanup: false);

					transaction.Commit();

					return entity;
				}
			}
		}
	}
}
