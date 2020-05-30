using BG.Web.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class CategoryController
	{
		/// <summary>
		/// GET / Statistics action.
		/// </summary>
		[HttpGet]
		[Route("statistics", Name = "CategoryStatisticsGet")]
		public ActionResult Statistics()
		{
			var model = new CategoryStatistics();

			var position =  _categoryRepository.GetAll();

			// Count
			model.Count = position.Count();

			// Latest
			model.Latest = position.OrderByDescending(c => c.Id).Take(3).Select(i => new
			{
				name = i.Title,
				image = _imageService.BuildUrl(i.ImageBlob?.Name, i.Title, 40, 40),
				creationDate = Globalization.GetLocalDateTime(i.UTCCreation).DateTime.ToLongDateString(),
				navigationPath = Url.Action(nameof(CategoryController.Edit), nameof(CategoryController).RemoveControllerSuffix(), new { @id = i.Id })
			}).Cast<object>().ToList();

			// Weekly data
			var maxDate = DateTime.UtcNow;
			var minDate = maxDate.AddDays(-7);

            position = position.Where(c => c.UTCCreation.Date >= minDate.Date);
            position = position.Where(c => c.UTCCreation.Date <= maxDate.Date);

			var items = new List<object>();

			for (DateTime date = minDate.Date; date <= maxDate.Date; date = date.AddDays(1))
			{
				var dayName = date.ToString("MMM/dd");
				var dayValue = position.Where(c => c.UTCCreation.Date.Equals(date)).Count();

				items.Add(new List<object>() { dayName, dayValue });
			}

			model.WeeklyRegistrations = items;

			return Json(model);
		}
	}
}
