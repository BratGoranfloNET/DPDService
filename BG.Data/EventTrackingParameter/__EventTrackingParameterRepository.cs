using BG.Core.Repositories;

namespace BG.Data
{	
	public partial class EventTrackingParameterRepository : IEventTrackingParameterRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;

		public EventTrackingParameterRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
