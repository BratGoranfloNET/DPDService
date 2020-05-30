using BG.Core.Repositories;

namespace BG.Data
{
	public partial class TokenRepository : ITokenRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;
				
		public TokenRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
