using BG.Core.Repositories;

namespace BG.Data
{
	
	public partial class StateUnitedRepository : IStateUnitedRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;

		public StateUnitedRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
