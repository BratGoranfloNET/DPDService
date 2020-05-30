using BG.Core.Context;
using BG.Core.Repositories;

namespace BG.Data.Blobs
{
	/// <summary>
	/// Partial blobs repository implementation.
	/// </summary>
	public partial class BlobsRepository : IBlobsRepository
	{
		private IWebContext _webContext = null;
		private IDbConnectionFactory _dbConnectionFactory = null;

		/// <summary>
		/// Contructor method.
		/// </summary>
		public BlobsRepository(IWebContext webContext, IDbConnectionFactory dbConnectionFactory)
		{
			_webContext = webContext;
			_dbConnectionFactory = dbConnectionFactory;
		}
	}
}
