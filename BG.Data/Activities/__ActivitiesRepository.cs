using BG.Core.Repositories;

namespace BG.Data.Activities
{
	/// <summary>
	/// Partial activities repository implementation.
	/// </summary>
	public partial class ActivitiesRepository : IActivitiesRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;

		/// <summary>
		/// Contructor method.
		/// </summary>
		public ActivitiesRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
