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
	public partial class LocationsController
	{
		/// <summary>
		/// GET / Add action.
		/// </summary>
		[HttpGet]
		[Route("add", Name = "LocationsAddGet")]
		public ActionResult Add()
		{
			var model = new LocationViewModel();

			model = BuilModel(model);

			return View("Manager", model);
		}

		/// <summary>
		/// POST / Add action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("add", Name = "LocationsAddPost")]
		public ActionResult Add(LocationViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = Mapper.Map<Location>(model);

				entity = _locationsRepository.Create(entity);

				_timelineService.RegisterActivity(Realm.BG, ActivityType.LocationCreated, User.Id);

				Feedback.AddMessageSuccess(LocationResources.LocationAddSuccessMessage);

				return RedirectToAction(nameof(Index), nameof(LocationsController).RemoveControllerSuffix());
			}

			model = BuilModel(model);

			return View("Manager", model);
		}
	}
}