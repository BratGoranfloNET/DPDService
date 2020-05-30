using Dapper;
using System.Data;

namespace BG.Data.Contacts
{
	/// <summary>
	/// Partial contacts repository implementation.
	/// </summary>
	public partial class ContactsRepository
	{
		/// <summary>
		/// Delete an entity.
		/// </summary>
		public void Delete(int entityId)
		{
			var parameters = new DynamicParameters();

			parameters.Add("@Id", entityId, DbType.Int32);

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Execute(
					sql: ContactsDelete_Proc,
					commandType: CommandType.StoredProcedure,
					param: parameters
				);
			}
		}
	}
}
