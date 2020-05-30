using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data.Activities
{
	/// <summary>
	/// Partial activities repository implementation.
	/// </summary>
	public partial class ActivitiesRepository
	{
		/// <summary>
		/// Create an entity.
		/// </summary>
		public Activity Create(Activity entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@Realm", entity.Realm, DbType.Byte);
					parameters.Add("@Date", entity.Date, DbType.DateTimeOffset);
					parameters.Add("@Type", entity.Type, DbType.Int32);
					parameters.Add("@UserId", entity.UserId, DbType.Int32);
					parameters.Add("@Signature", entity.Signature, DbType.Guid);

					// Configure outputs
					parameters.Add("@EntityId", dbType: DbType.Int32, direction: ParameterDirection.Output);
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: ActivitiesInsert_Proc,
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
