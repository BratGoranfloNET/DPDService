using BG.Core.Repositories;

namespace BG.Data.Users
{
	
	public partial class UsersRepository : IUsersRepository
	{
		private IDbConnectionFactory _dbConnectionFactory = null;

		public UsersRepository(IDbConnectionFactory dbConnectionFactory)
		{
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
