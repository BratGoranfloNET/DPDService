using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Net;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial calendar controller.
	/// </summary>
	public partial class CalendarController
	{
		/// <summary>
		/// GET / Events edit action.
		/// </summary>
		[HttpGet]
		[Route("events/{id:int}/edit", Name = "CalendarEventsEditGet")]
		public ActionResult EventsEdit(int id)
		{
			var entity = _eventsRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			var model = Mapper.Map<CalendarEventViewModel>(entity);

			model = BuildModel(model);

			return View("EventManager", model);
		}

		/// <summary>
		/// POST / Events edit action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("events/{id:int}/edit", Name = "CalendarEventsEditPost")]
		public ActionResult EventsEdit([ModelBinder(typeof(CalendarEventViewModelBinder))] CalendarEventViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = Mapper.Map<Event>(model);

				entity = _eventsRepository.Update(entity);

				_timelineService.RegisterActivity(Realm.BG, ActivityType.EventUpdated, User.Id);

				Feedback.AddMessageSuccess(CalendarResources.EventEditSuccessMessage);

				return RedirectToAction(nameof(EventsIndex), nameof(CalendarController).RemoveControllerSuffix());
			}

			model = BuildModel(model);

			return View("EventManager", model);
		}
	}
}
