using Dapper;
using BG.Core.Entities;
using System.Data;
using System;

namespace BG.Data
{
	/// <summary>
	/// Partial events repository implementation.
	/// </summary>
	public partial class ArticleRepository
    {
		/// <summary>
		/// Create entity.
		/// </summary>
		public Article Create(Article entity)
		{
            //entity.ReleaseDate = DateTime.Now;
            //entity.ExpireDate  = DateTime.Now;


            using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();
                   
                    //parameters.Add("@AddedBy", entity.AddedBy, DbType.String);
                    parameters.Add("@CategoryId", entity.CategoryId, DbType.Int32);
                    parameters.Add("@Title", entity.Title, DbType.String);
					//parameters.Add("@Path", entity.Path, DbType.String);
                    parameters.Add("@Abstract", entity.Abstract, DbType.String);
                    parameters.Add("@Body", entity.Body, DbType.String);                   
                    //parameters.Add("@ReleaseDate", entity.ReleaseDate, DbType.DateTime);
                    //parameters.Add("@ExpireDate", entity.ExpireDate, DbType.DateTime);
                    //parameters.Add("@Approved", entity.Approved, DbType.Byte);
                    //parameters.Add("@CommentsEnabled", entity.CommentsEnabled, DbType.Byte);
                    //parameters.Add("@OnlyForMembers", entity.OnlyForMembers, DbType.Byte);
                    //parameters.Add("@ViewCount", entity.ViewCount, DbType.Int32);
                    //parameters.Add("@Votes", entity.Votes, DbType.Int32);
                    //parameters.Add("@TotalRating", entity.TotalRating, DbType.Int32);
                    parameters.Add("@ImageBlobId", entity.ImageBlobId, DbType.Guid);

                    // Configure outputs
                    parameters.Add("@EntityId", dbType: DbType.Int32, direction: ParameterDirection.Output);
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: ArticleInsert_Proc,
						commandType: CommandType.StoredProcedure,
						transaction: transaction,
						param: parameters
					);

					// Check for errors
					string errorMessage = parameters.Get<string>("@ErrorMessage");

					if (!string.IsNullOrEmpty(errorMessage))
						throw new RepositoryException(errorMessage);

					// Set the id
					entity.Id = parameters.Get<int>("@EntityId");

					// Set images
					//EventImagesSet(connection, transaction, images: entity.Images, eventId: entity.Id, cleanup: false);

					transaction.Commit();

					return entity;
				}
			}
		}
	}
}
