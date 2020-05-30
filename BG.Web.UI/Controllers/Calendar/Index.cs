using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial calendar controller.
	/// </summary>
	public partial class CalendarController
	{
		/// <summary>
		/// GET / Index action.
		/// </summary>
		[HttpGet]
		[Route(Name = "CalendarIndexGet")]
		public ActionResult Index()
		{
			var model = new CalendarIndexViewModel();

			return View(model);
		}
	}
}