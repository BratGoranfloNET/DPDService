using BG.Core.Repositories;

namespace BG.Data.Events
{
	/// <summary>
	/// Partial events repository implementation.
	/// </summary>
	public partial class EventsRepository : IEventsRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;

		/// <summary>
		/// Contructor method.
		/// </summary>
		public EventsRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
