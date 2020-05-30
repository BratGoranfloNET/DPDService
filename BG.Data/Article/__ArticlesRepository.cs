using BG.Core.Repositories;

namespace BG.Data
{
    
    public partial class ArticleRepository : IArticleRepository
    {
        private IDbConnectionFactory _dbConnectionFactory = null;

        public ArticleRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
    }
}
