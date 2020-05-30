using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data.Contacts
{
	/// <summary>
	/// Partial contacts repository implementation.
	/// </summary>
	public partial class ContactsRepository
	{
		/// <summary>
		/// Update an entity.
		/// </summary>
		public Contact Update(Contact entity)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@Id", entity.Id, DbType.Int32);
					parameters.Add("@ImageBlobId", entity.ImageBlobId, DbType.Guid);
					parameters.Add("@Name", entity.Name, DbType.String);
					parameters.Add("@Type", entity.Type, DbType.Byte);
					parameters.Add("@Gender", entity.Gender, DbType.Byte);
					parameters.Add("@BirthDate", entity.BirthDate, DbType.DateTime2);
					parameters.Add("@Email1", entity.Email1, DbType.String);
					parameters.Add("@Email2", entity.Email2, DbType.String);
					parameters.Add("@Phone1", entity.Phone1, DbType.String);
					parameters.Add("@Phone2", entity.Phone2, DbType.String);
					parameters.Add("@Notes", entity.Notes, DbType.String);
                                                           
                    parameters.Add("@FullName", entity.FullName, DbType.String);
                    parameters.Add("@Inn", entity.Inn, DbType.String);
                    parameters.Add("@Address", entity.Address, DbType.String);
                    parameters.Add("@SroNumberPasspotr", entity.SroNumberPasspotr, DbType.String);

                    parameters.Add("@Limit", entity.Limit, DbType.Currency);
                    parameters.Add("@Profession", entity.Profession, DbType.String);
                    parameters.Add("@ProfessionType", entity.ProfessionType, DbType.String);
                    parameters.Add("@ActiveFlag", entity.ActiveFlag, DbType.Int32);

                    // Configure outputs
                    parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: ContactsUpdate_Proc,
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
