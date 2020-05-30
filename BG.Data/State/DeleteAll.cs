﻿using Dapper;
using System.Data;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class StateRepository
	{
		/// <summary>
		/// Delete entity.
		/// </summary>
		public void DeleteAll()
		{
			var parameters = new DynamicParameters();

			// parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Execute(
					sql: StateDeleteAll_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
				);
			}
		}
	}
}
