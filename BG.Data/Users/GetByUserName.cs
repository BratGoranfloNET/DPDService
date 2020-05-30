﻿using Dapper;
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
		/// Get an entity.
		/// </summary>
		public User GetByUserName(string userName)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@UserName", userName, DbType.String);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				using (var reader = connection.QueryMultiple(sql: UsersSelect_Proc, commandType: CommandType.StoredProcedure, param: parameters))
				{
					var entity = BuildEntity(reader);

					return entity;
				}
			}
		}
	}
}
