using BG.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{

	public partial class StateParcelsController
	{
		[HttpGet]
		[Route("statistics", Name = "StateParcelsStatisticsGet")]
		public ActionResult Statistics()
		{
			var model = new StateParcelsStatistics();

			var entity = _stateparcelsRepository.GetAll();

			// Count
			model.Count = entity.Count();

			// Latest
			model.Latest = entity.OrderByDescending(c => c.Id).Take(3).Select(i => new
			{
				name = i.Name,
				// image = _imageService.BuildUrl(i.ImageBlob?.Name, i.Name, 40, 40),
				creationDate = Globalization.GetLocalDateTime(i.UTCCreation).DateTime.ToLongDateString(),
				// navigationPath = Url.Action(nameof(StateParcelsController.Edit), nameof(StateParcelsController).RemoveControllerSuffix(), new { @id = i.Id })
			}).Cast<object>().ToList();

			// Weekly data
			var maxDate = DateTime.UtcNow;
			var minDate = maxDate.AddDays(-7);

            entity = entity.Where(c => c.UTCCreation.Date >= minDate.Date);
            entity = entity.Where(c => c.UTCCreation.Date <= maxDate.Date);

			var items = new List<object>();

			for (DateTime date = minDate.Date; date <= maxDate.Date; date = date.AddDays(1))
			{
				var dayName = date.ToString("MMM/dd");
				var dayValue = entity.Where(c => c.UTCCreation.Date.Equals(date)).Count();

				items.Add(new List<object>() { dayName, dayValue });
			}

			model.WeeklyRegistrations = items;

			return Json(model);
		}
	}
}
