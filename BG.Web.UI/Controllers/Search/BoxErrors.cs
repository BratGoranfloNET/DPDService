using BG.Web.UI.Attributes;
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
		/// Erros page search box form.
		/// </summary>
		[AllowAnonymous]
		[ChildActionOnly]
		[LockScreenAllowed]
		[Route("box/errors", Name = "SearchBoxErrors")]
		public ActionResult BoxErrors()
		{
			var model = new EmptyViewModel();

			return PartialView(model);
		}
	}
}