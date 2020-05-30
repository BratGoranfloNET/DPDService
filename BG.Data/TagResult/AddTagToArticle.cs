using Dapper;
using BG.Core.Entities;
using System.Data;

namespace BG.Data
{
	
	public partial class TagResultRepository
    {
		/// <summary>
		/// Create entity.
		/// </summary>
		public TagResult AddTagToArticle(int articleid, int tagid)
		{
			using (var connection = _dbConnectionFactory.CreateConnection())
			{
				connection.Open();

				using (var transaction = connection.BeginTransaction())
				{
					var parameters = new DynamicParameters();
									
					parameters.Add("@ArticleId", articleid, DbType.Int32);
                    parameters.Add("@TagId", tagid, DbType.Int32);
                    
                    // Configure outputs
                    parameters.Add("@EntityId", dbType: DbType.Int32, direction: ParameterDirection.Output);
					parameters.Add("@ErrorMessage", dbType: DbType.String, size: 1000, direction: ParameterDirection.Output);

					// Execute query
					int result = connection.Execute(
						sql: TagResultInsert_Proc,
						commandType: CommandType.StoredProcedure,
						transaction: transaction,
						param: parameters 
					);

					// Check for errors
					string errorMessage = parameters.Get<string>("@ErrorMessage");

					if (!string.IsNullOrEmpty(errorMessage))
						throw new RepositoryException(errorMessage);

                    TagResult entity = new TagResult
                    {
                       ArticleId = articleid,
                        TagId = tagid
                    };

					// Set the id
					entity.Id = parameters.Get<int>("@EntityId");

					transaction.Commit();

					return entity;

				}
			}
		}
	}
}
