using Dapper;
using BG.Core.Entities;
using System;
using System.Data;

namespace BG.Data.Blobs
{
	/// <summary>
	/// Partial blobs repository implementation.
	/// </summary>
	public partial class BlobsRepository
	{
		/// <summary>
		/// Create an entity.
		/// </summary>
		public Blob Create(Blob entity)
		{
			if (entity.Id == Guid.Empty)
				entity.Id = Guid.NewGuid();

			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@UserId", _webContext.User.Id, DbType.Int32);

					parameters.Add("@Id", entity.Id, DbType.Guid);
					parameters.Add("@Type", entity.Type, DbType.String);
					parameters.Add("@Length", entity.Length, DbType.Int64);
					parameters.Add("@Container", entity.Container, DbType.String);
					parameters.Add("@Extension", entity.Extension, DbType.String);

					// Configure outputs
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: BlobsInsert_Proc,
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
