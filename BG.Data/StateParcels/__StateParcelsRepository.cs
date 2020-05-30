using BG.Core.Repositories;

namespace BG.Data
{
	
	public partial class StateParcelsRepository : IStateParcelsRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;
		
		public StateParcelsRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
