using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial search controller.
	/// </summary>
	public partial class SearchController
	{
		/// <summary>
		/// Results page search box form.
		/// </summary>
		[AllowAnonymous]
		[ChildActionOnly]
		[Route("box/results", Name = "SearchBoxResults")]
		public ActionResult BoxResults()
		{
			var model = new EmptyViewModel();

			return PartialView(model);
		}
	}
}