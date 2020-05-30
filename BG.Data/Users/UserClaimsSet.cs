using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data.Users
{
	/// <summary>
	/// Partial users repository implementation.
	/// </summary>
	public partial class UsersRepository
	{
		/// <summary>
		/// Used by the create and update methods to add/remove user related claims.
		/// </summary>
		public void UserClaimsSet(IDbConnection dbConnection, IDbTransaction transaction, List<UserClaim> claims, User user, bool cleanup)
		{
			if (cleanup)
			{
				var parameters = new DynamicParameters();

				parameters.Add(@"UserId", user.Id, DbType.Int32);

				dbConnection.Execute(
					sql: UserClaimsCleanup_Proc,
					commandType: CommandType.StoredProcedure,
					transaction: transaction,
					param: parameters
				);
			}

			foreach (var claim in claims)
			{
				var parameters = new DynamicParameters();

				parameters.Add("@Realm", user.Realm, DbType.Byte);
				parameters.Add("@UserId", user.Id, DbType.Int32);
				parameters.Add("@ClaimType", claim.ClaimType, DbType.String);
				parameters.Add("@ClaimValue", claim.ClaimValue, DbType.String);

				// Configure outputs
				parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

				dbConnection.Query(
					sql: UserClaimsInsert_Proc,
					commandType: CommandType.StoredProcedure,
					transaction: transaction,
					param: parameters
				);

				// Check for errors
				string errorMessage = parameters.Get<string>("@ErrorMessage");

				if (!string.IsNullOrEmpty(errorMessage))
					throw new RepositoryException(errorMessage);

				// Set the id
				claim.Id = parameters.Get<int>("@EntityId");
			}
		}
	}
}
