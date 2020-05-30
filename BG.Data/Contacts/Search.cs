using Dapper;
using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;

namespace BG.Data.Contacts
{
	/// <summary>
	/// Partial contacts repository implementation.
	/// </summary>
	public partial class ContactsRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<Contact> Search(string query)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Query", query, DbType.String);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				var reader = connection.Query(
					sql: ContactsSearch_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters,
					map: _contactMap
				);

				return reader;
			}
		}
	}
}
