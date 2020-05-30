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
		/// GET / Events feed action.
		/// </summary>
		[HttpGet]
		[Route("events/feed", Name = "CalendarEventsFeedGet")]
		public ActionResult EventsFeed(DateTime? startParam, DateTime? endParam, string timezoneParam)
		{
			var events = _eventsRepository.GetAll();

			var result = events.Select(e => new {
				id = e.Id,
				color = e.Color,
				title = e.Name,
				start = Globalization.GetLocalDateTime(e.StartDate),
				end = Globalization.GetLocalDateTime(e.EndDate)
			});

			return Json(result);
		}
	}
}