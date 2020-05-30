using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class EventTypeController
	{
		/// <summary>
		/// GET / Add action.
		/// </summary>
		[HttpGet]
		[Route("add", Name = "EventTypeAddGet")]
		public ActionResult Add()
		{
			var model = new EventTypeViewModel();

			model = BuilModel(model);

			return View("Manager", model);
		}

		/// <summary>
		/// POST / Add action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("add", Name = "EventTypeAddPost")]
		public ActionResult Add(EventTypeViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = Mapper.Map<EventType>(model);

				entity = _eventtypeRepository.Create(entity);

				// _timelineService.RegisterActivity(Realm.BG, ActivityType.LocationCreated, User.Id);

				Feedback.AddMessageSuccess(EventTypeResources.LocationAddSuccessMessage);

				return RedirectToAction(nameof(Index), nameof(EventTypeController).RemoveControllerSuffix());
			}

			model = BuilModel(model);

			return View("Manager", model);
		}
	}
}