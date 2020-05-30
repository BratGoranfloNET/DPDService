using BG.Core.Repositories;

namespace BG.Data
{
	
	public partial class EventTrackingTypeRepository : IEventTrackingTypeRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;
		
		public EventTrackingTypeRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
