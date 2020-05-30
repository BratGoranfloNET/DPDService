using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;

namespace BG.Data.Contacts
{
	/// <summary>
	/// Partial contacts repository implementation.
	/// </summary>
	public partial class ContactsRepository
	{
		/// <summary>
		/// Get an entity by id.
		/// </summary>
		public Contact GetById(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				var reader = connection.Query(
					sql: ContactsSelect_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters,
					map: _contactMap
				);

				return reader.SingleOrDefault();
			}
		}
	}
}
