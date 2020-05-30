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
		/// Used by the create and update methods to add/remove user related roles.
		/// </summary>
		public void UserRolesSet(IDbConnection dbConnection, IDbTransaction transaction, List<UserRole> roles, User user, bool cleanup)
		{
			if (cleanup)
			{
				var parameters = new DynamicParameters();

				parameters.Add(@"UserId", user.Id, DbType.Int32);

				dbConnection.Execute(
					sql: UserRolesCleanup_Proc,
					commandType: CommandType.StoredProcedure,
					transaction: transaction,
					param: parameters
				);
			}

			foreach (var role in roles)
			{
				var parameters = new DynamicParameters();

				parameters.Add("@UserId", user.Id, DbType.Int32);
				parameters.Add("@Role", role.Role.ToString(), DbType.String);

				// Configure outputs
				parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

				dbConnection.Query(
					sql: UserRolesInsert_Proc,
					commandType: CommandType.StoredProcedure,
					transaction: transaction,
					param: parameters
				);

				// Check for errors
				string errorMessage = parameters.Get<string>("@ErrorMessage");

				if (!string.IsNullOrEmpty(errorMessage))
					throw new RepositoryException(errorMessage);
			}
		}
	}
}
