using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Web.Mvc;
using System;
using System.Collections.Generic;


namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial calendar controller.
	/// </summary>
	public partial class CalendarController
	{
		/// <summary>
		/// GET / Events add action.
		/// </summary>
		[HttpGet]
		[Route("events/add", Name = "CalendarEventsAddGet")]
		public ActionResult EventsAdd()
		{
			var model = new CalendarEventViewModel();

			model = BuildModel(model);

           


            return View("EventManager", model);
		}

		/// <summary>
		/// POST / Events add action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("events/add", Name = "CalendarEventsAddPost")]
		public ActionResult EventsAdd([ModelBinder(typeof(CalendarEventViewModelBinder))] CalendarEventViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = Mapper.Map<Event>(model);

				entity = _eventsRepository.Create(entity);

				_timelineService.RegisterActivity(Realm.BG, ActivityType.EventCreated, User.Id);

				Feedback.AddMessageSuccess(CalendarResources.EventAddSuccessMessage);

				return RedirectToAction(nameof(EventsIndex), nameof(CalendarController).RemoveControllerSuffix());
			}

			model = BuildModel(model);

			return View("EventManager", model);
		}
	}
}