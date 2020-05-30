using BG.Core.Repositories;

namespace BG.Data
{
	
	public partial class EventTypeRepository : IEventTypeRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;
				
		public EventTypeRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
