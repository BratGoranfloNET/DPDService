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
	public partial class LocationsController
	{
		/// <summary>
		/// GET / Edit action.
		/// </summary>
		[HttpGet]
		[Route("{id:int}/edit", Name = "LocationsEditGet")]
		public ActionResult Edit(int id)
		{
			var entity = _locationsRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			var model = Mapper.Map<LocationViewModel>(entity);

			model = BuilModel(model);

			return View("Manager", model);
		}

		/// <summary>
		/// POST / Edit action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("{id:int}/edit", Name = "LocationsEditPost")]
		public ActionResult Edit(LocationViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = Mapper.Map<Location>(model);

				entity = _locationsRepository.Update(entity);

				_timelineService.RegisterActivity(Realm.BG, ActivityType.LocationUpdated, User.Id);

				Feedback.AddMessageSuccess(LocationResources.LocationEditSuccessMessage);

				return RedirectToAction(nameof(Index), nameof(LocationsController).RemoveControllerSuffix());
			}

			model = BuilModel(model);

			return View("Manager", model);
		}
	}
}