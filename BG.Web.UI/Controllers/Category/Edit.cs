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
	public partial class CategoryController
	{
		/// <summary>
		/// GET / Edit action.
		/// </summary>
		[HttpGet]
		[Route("{id:int}/edit", Name = "CategoryEditGet")]
		public ActionResult Edit(int id)
		{
			var entity = _categoryRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			var model = Mapper.Map<CategoryViewModel>(entity);

			model = BuilModel(model);

			return View("Manager", model);
		}

		/// <summary>
		/// POST / Edit action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("{id:int}/edit", Name = "CategoryEditPost")]
		public ActionResult Edit(CategoryViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = Mapper.Map<Category>(model);

				entity = _categoryRepository.Update(entity);

                //_timelineService.RegisterActivity(Realm.BG, ActivityType.LocationUpdated, User.Id);

                //Feedback.AddMessageSuccess(CategoryResources.CategoryEditSuccessMessage);
                Feedback.AddMessageSuccess("Категория успешно отредактирована !");

                return RedirectToAction(nameof(Index), nameof(CategoryController).RemoveControllerSuffix());
			}

			model = BuilModel(model);

			return View("Manager", model);
		}
	}
}