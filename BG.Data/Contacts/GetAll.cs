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
		public IEnumerable<Contact> GetAll()
		{
			var parameters = new DynamicParameters();

			parameters.Add("@IsDeleted", false, DbType.Boolean);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				var reader = connection.Query(
					sql: ContactsSelect_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters,
					map: _contactMap
				);

				return reader;
			}
		}
	}
}
