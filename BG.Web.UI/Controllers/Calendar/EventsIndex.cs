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
		/// GET / Events action.
		/// </summary>
		[HttpGet]
		[Route("events", Name = "CalendarEventsGet")]
		public ActionResult EventsIndex()
		{
			var model = new CalendarEventsIndexViewModel();

			model.Events = _eventsRepository.GetAll();

			return View(model);
		}
	}
}