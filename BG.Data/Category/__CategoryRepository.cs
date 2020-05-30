using BG.Core.Repositories;

namespace BG.Data
{
    
    public partial class CategoryRepository : ICategoryRepository
    {
        private IDbConnectionFactory _dbConnectionFactory = null;

        public CategoryRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }
    }
}
