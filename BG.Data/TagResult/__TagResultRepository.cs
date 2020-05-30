using BG.Core.Repositories;

namespace BG.Data
{
	
	public partial class TagResultRepository : ITagResultRepository
    {
		private IDbConnectionFactory _dbConnectionFactory = null;

		public TagResultRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
