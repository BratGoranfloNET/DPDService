using BG.Web.UI.Models;
using System;
using System.Collections.Generic;
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
		/// GET / Statistics action.
		/// </summary>
		[HttpGet]
		[Route("events/statistics", Name = "EventStatisticsGet")]
		public ActionResult EventStatistics()
		{
			var model = new CalendarEventStatistics();

			var events = _eventsRepository.GetAll();

			// Count
			model.Count = events.Count();

			// Latest
			model.Latest = events.OrderByDescending(c => c.Id).Take(3).Select(i => new
			{
				name = i.Name,
				image = _imageService.BuildUrl(i.Images?.FirstOrDefault()?.Name ?? null, i.Name, 40, 40),
				creationDate = Globalization.GetLocalDateTime(i.UTCCreation).DateTime.ToLongDateString(),
				navigationPath = Url.Action(nameof(CalendarController.EventsEdit), nameof(CalendarController).RemoveControllerSuffix(), new { @id = i.Id })
			}).Cast<object>().ToList();

			// Weekly data
			var maxDate = DateTime.UtcNow;
			var minDate = maxDate.AddDays(-7);

			events = events.Where(c => c.UTCCreation.Date >= minDate.Date);
			events = events.Where(c => c.UTCCreation.Date <= maxDate.Date);

			var items = new List<object>();

			for (DateTime date = minDate.Date; date <= maxDate.Date; date = date.AddDays(1))
			{
				var dayName = date.ToString("MMM/dd");
				var dayValue = events.Where(c => c.UTCCreation.Date.Equals(date)).Count();

				items.Add(new List<object>() { dayName, dayValue });
			}

			model.WeeklyRegistrations = items;

			return Json(model);
		}
	}
}
