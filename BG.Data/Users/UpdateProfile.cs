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
		public User UpdateProfile(User entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@Id", entity.Id, DbType.Int32);
					parameters.Add("@Name", entity.Name, DbType.String);
					parameters.Add("@Email", entity.Email, DbType.String);
					parameters.Add("@Gender", entity.Gender, DbType.Byte);
					parameters.Add("@UserName", entity.UserName, DbType.String);
					parameters.Add("@ImageBlobId", entity.ImageBlobId, DbType.Guid);
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
						sql: UsersUpdateProfile_Proc,
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
