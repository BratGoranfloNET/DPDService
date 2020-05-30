using BG.Core.Repositories;

namespace BG.Data
{
	
	public partial class TagRepository : ITagRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;
				
		public TagRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
