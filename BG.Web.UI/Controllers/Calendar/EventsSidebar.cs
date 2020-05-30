using BG.Web.UI.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial calendar controller.
	/// </summary>
	public partial class CalendarController
	{
		/// <summary>
		/// Sidebar events widget.
		/// </summary>
		[ChildActionOnly]
		[Route("events/sidebar", Name = "CalendarEventsSidebar")]
		public ActionResult EventsSidebar()
		{
			var events = _eventsRepository.GetAll();

			var model = new CalendarEventsSidebarViewModel();

			var localNow = Globalization.GetLocalDateTime(DateTime.UtcNow);

			model.UpcomingEvents = events.Where(e =>
				Globalization.GetLocalDateTime(e.StartDate.Date) >= localNow.Date
			).OrderBy(e =>
				Globalization.GetLocalDateTime(e.StartDate.DateTime)
			).ToList();

			return PartialView(model);
		}
	}
}