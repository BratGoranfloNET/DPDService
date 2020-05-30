using Dapper;
using BG.Core.Entities;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System;



namespace BG.Data
{  
    public partial class ArticleRepository
    {        /// <summary>
        /// Get entity.
        /// </summary>
        public IEnumerable<Article> GetPublishedArticles(int categoryId)
        {
            var parameters = new DynamicParameters();

            parameters.Add("@IsDeleted", false, DbType.Boolean);
                      
            if (categoryId != 0)
            {
                parameters.Add("@CategoryId", categoryId, DbType.Int32);
            }

            DateTime NowDate = DateTime.UtcNow;
            parameters.Add("@NowDate", NowDate, DbType.DateTime);
            parameters.Add("@CheckForApproved", true, DbType.Boolean);
            
            IEnumerable<Article> reader;

            using (var connection = _dbConnectionFactory.CreateConnection())
            {               
                reader = connection.Query(
                    sql: ArticleSelect_Proc,
                    commandType: CommandType.StoredProcedure,
                    param: parameters,
                    map: _articleMap
                );                               
            }          

            return reader;
            
        }
    }
}
