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
		/// Top search box form.
		/// </summary>
		[ChildActionOnly]
		[Route("box/top", Name = "SearchBoxTop")]
		public ActionResult BoxTop()
		{
			var model = new EmptyViewModel();

			return PartialView(model);
		}
	}
}