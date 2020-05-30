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
		/// Update an entity.
		/// </summary>
		public User UpdateIdentity(User entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@Id", entity.Id, DbType.Int32);
					parameters.Add("@IsDeleted", entity.IsDeleted, DbType.Boolean);
					parameters.Add("@EmailConfirmed", entity.EmailConfirmed, DbType.Boolean);
					parameters.Add("@LockoutEnabled", entity.LockoutEnabled, DbType.Boolean);
					parameters.Add("@TwoFactorEnabled", entity.TwoFactorEnabled, DbType.Boolean);
					parameters.Add("@MobilePhoneConfirmed", entity.MobilePhoneConfirmed, DbType.Boolean);
					parameters.Add("@LockoutEndDateUtc", entity.LockoutEndDateUtc, DbType.DateTimeOffset);
					parameters.Add("@AccessFailedCount", entity.AccessFailedCount, DbType.Byte);
					parameters.Add("@PasswordHash", entity.PasswordHash, DbType.String);
					parameters.Add("@SecurityStamp", entity.SecurityStamp, DbType.String);
					parameters.Add("@UserName", entity.UserName, DbType.String);
					parameters.Add("@Email", entity.Email, DbType.String);
					parameters.Add("@Realm", entity.Realm, DbType.Byte);
					parameters.Add("@Name", entity.Name, DbType.String);
					parameters.Add("@Gender", entity.Gender, DbType.Byte);
					parameters.Add("@ImageBlobId", entity.ImageBlobId, DbType.Guid);
					parameters.Add("@MobilePhone", entity.MobilePhone, DbType.String);
					parameters.Add("@Biography", entity.Biography, DbType.String);
					parameters.Add("@GitHubLink", entity.GitHubLink, DbType.String);
					parameters.Add("@TwitterLink", entity.TwitterLink, DbType.String);
					parameters.Add("@LinkedInLink", entity.LinkedInLink, DbType.String);
					parameters.Add("@FacebookLink", entity.FacebookLink, DbType.String);
					parameters.Add("@InstagramLink", entity.InstagramLink, DbType.String);
					parameters.Add("@CurrentCultureId", entity.CurrentCultureId, DbType.String);
					parameters.Add("@CurrentUICultureId", entity.CurrentUICultureId, DbType.String);
					parameters.Add("@TimeZoneId", entity.TimeZoneId, DbType.String);
					parameters.Add("@AutoLockScreenInMinutes", entity.AutoLockScreenInMinutes, DbType.Byte);
					parameters.Add("@StatusMessage", entity.StatusMessage, DbType.String);

					// Configure outputs
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: UsersUpdateIdentity_Proc,
						commandType: CommandType.StoredProcedure,
						transaction: transaction,
						param: parameters
					);

					// Check for errors
					string errorMessage = parameters.Get<string>("@ErrorMessage");

					if (!string.IsNullOrEmpty(errorMessage))
						throw new RepositoryException(errorMessage);

					// Set claims
					UserClaimsSet(connection, transaction, claims: entity.Claims, user: entity, cleanup: true);

					// Set roles
					UserRolesSet(connection, transaction, roles: entity.Roles, user: entity, cleanup: true);

					transaction.Commit();

					return entity;
				}
			}
		}
	}
}
