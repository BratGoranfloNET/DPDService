using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Net;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class EventTypeController
	{
		/// <summary>
		/// GET / Edit action.
		/// </summary>
		[HttpGet]
		[Route("{id:int}/edit", Name = "EventTypeEditGet")]
		public ActionResult Edit(int id)
		{
			var entity = _eventtypeRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			var model = Mapper.Map<EventTypeViewModel>(entity);

			model = BuilModel(model);

			return View("Manager", model);
		}

		/// <summary>
		/// POST / Edit action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("{id:int}/edit", Name = "EventTypeEditPost")]
		public ActionResult Edit(EventTypeViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = Mapper.Map<EventType>(model);

				entity = _eventtypeRepository.Update(entity);

				//_timelineService.RegisterActivity(Realm.BG, ActivityType.LocationUpdated, User.Id);

				Feedback.AddMessageSuccess(EventTypeResources.LocationEditSuccessMessage);

				return RedirectToAction(nameof(Index), nameof(EventTypeController).RemoveControllerSuffix());
			}

			model = BuilModel(model);

			return View("Manager", model);
		}
	}
}