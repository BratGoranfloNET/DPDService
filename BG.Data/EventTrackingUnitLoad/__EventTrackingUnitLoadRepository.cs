using BG.Core.Repositories;

namespace BG.Data
{
	
	public partial class EventTrackingUnitLoadRepository : IEventTrackingUnitLoadRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;
		
		public EventTrackingUnitLoadRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
