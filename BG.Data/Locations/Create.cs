using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data.Locations
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class LocationsRepository
	{
		/// <summary>
		/// Create entity.
		/// </summary>
		public Location Create(Location entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@ImageBlobId", entity.ImageBlobId, DbType.Guid);
					parameters.Add("@Name", entity.Name, DbType.String);
					parameters.Add("@Type", entity.Type, DbType.Byte);
					parameters.Add("@TimeZoneId", entity.TimeZoneId, DbType.String);
					parameters.Add("@ContactId", entity.ContactId, DbType.Int32);
					parameters.Add("@Notes", entity.Notes, DbType.String);
                    parameters.Add("@City", entity.City, DbType.String);
                    parameters.Add("@Latitude", entity.Latitude, DbType.String);
                    parameters.Add("@Longitude", entity.Longitude, DbType.String);
                    
                        
                    // Configure outputs
                    parameters.Add("@EntityId", dbType: DbType.Int32, direction: ParameterDirection.Output);
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: LocationsInsert_Proc,
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
