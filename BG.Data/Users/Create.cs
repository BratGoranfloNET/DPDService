using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data.Users
{
	/// <summary>
	/// Partial users repository implementation.
	/// </summary>
	public partial class UsersRepository
	{
		/// <summary>
		/// Create an entity.
		/// </summary>
		public User Create(User entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@LockoutEnabled", entity.LockoutEnabled, DbType.Boolean);
					parameters.Add("@PasswordHash", entity.PasswordHash, DbType.String);
					parameters.Add("@SecurityStamp", entity.SecurityStamp, DbType.String);
					parameters.Add("@UserName", entity.UserName, DbType.String);
					parameters.Add("@Email", entity.Email, DbType.String);
					parameters.Add("@Realm", entity.Realm, DbType.Byte);
					parameters.Add("@Name", entity.Name, DbType.String);
					parameters.Add("@Gender", entity.Gender, DbType.Byte);
					parameters.Add("@ImageBlobId", entity.ImageBlobId, DbType.Guid);
					parameters.Add("@Biography", entity.Biography, DbType.String);
					parameters.Add("@CurrentCultureId", entity.CurrentCultureId, DbType.String);
					parameters.Add("@CurrentUICultureId", entity.CurrentUICultureId, DbType.String);
					parameters.Add("@TimeZoneId", entity.TimeZoneId, DbType.String);

					// Configure outputs
					parameters.Add("@EntityId", dbType: DbType.Int32, direction: ParameterDirection.Output);
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: UsersInsert_Proc,
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

					// Set claims
					UserClaimsSet(connection, transaction, claims: entity.Claims, user: entity, cleanup: false);

					// Set roles
					UserRolesSet(connection, transaction, roles: entity.Roles, user: entity, cleanup: false);

					transaction.Commit();

					return entity;
				}
			}
		}
	}
}
