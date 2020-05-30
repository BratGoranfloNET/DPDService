using BG.Core.Repositories;

namespace BG.Data
{
	
	public partial class StateParcelsUnitedRepository : IStateParcelsUnitedRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;
			
		public StateParcelsUnitedRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
