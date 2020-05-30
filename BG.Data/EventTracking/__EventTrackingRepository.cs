using BG.Core.Repositories;

namespace BG.Data
{	
	public partial class EventTrackingRepository : IEventTrackingRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;
				
		public EventTrackingRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
