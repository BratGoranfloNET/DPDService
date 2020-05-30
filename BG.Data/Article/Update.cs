using Dapper;
using BG.Core.Entities;
using System.Data;
using System;

namespace BG.Data
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class ArticleRepository
	{
		/// <summary>
		/// Get entity.
		/// </summary>
		public Article Update(Article entity)
		{

            //entity.ReleaseDate = DateTime.Now;
            //entity.ExpireDate = DateTime.Now;



            using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();

					parameters.Add("@Id", entity.Id, DbType.Int32);
                   
                    //parameters.Add("@CategoryId", entity.CategoryId, DbType.Int32);
                    parameters.Add("@Title", entity.Title, DbType.String);
                    //parameters.Add("@Path", entity.Path, DbType.String);
                    parameters.Add("@Abstract", entity.Abstract, DbType.String);
                    parameters.Add("@Body", entity.Body, DbType.String);                    
                    //parameters.Add("@ReleaseDate", entity.ReleaseDate, DbType.DateTime);
                    //parameters.Add("@ExpireDate", entity.ExpireDate, DbType.DateTime);
                    //parameters.Add("@Approved", entity.Approved, DbType.Byte);
                    //parameters.Add("@CommentsEnabled", entity.CommentsEnabled, DbType.Byte);
                    //parameters.Add("@OnlyForMembers", entity.OnlyForMembers, DbType.Byte);
                    parameters.Add("@ImageBlobId", entity.ImageBlobId, DbType.Guid);


                    // Configure outputs
                    parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: ArticleUpdate_Proc,
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
