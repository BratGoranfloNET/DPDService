using BG.Core.Repositories;

namespace BG.Data
{
	
	public partial class StateRepository : IStateRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;
				
		public StateRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
