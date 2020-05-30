using BG.Core.Repositories;

namespace BG.Data.Logs
{	
	public partial class LogsRepository : ILogsRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;

		public LogsRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
