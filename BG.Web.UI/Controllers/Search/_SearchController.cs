using BG.Services.Search;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial search controller.
	/// </summary>
	[Authorize]
	[RoutePrefix("search")]
	public partial class SearchController : BaseController
	{
		private ISearchService _searchService = null;

		/// <summary>
		/// Contructor method.
		/// </summary>
		public SearchController(ISearchService searchService)
		{
			_searchService = searchService;
		}
	}
}
