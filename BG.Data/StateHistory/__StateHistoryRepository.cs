using BG.Core.Repositories;

namespace BG.Data
{
	
	public partial class StateHistoryRepository : IStateHistoryRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;
			
		public StateHistoryRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
