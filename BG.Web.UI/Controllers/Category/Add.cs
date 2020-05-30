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
	public partial class CategoryController
	{
		/// <summary>
		/// GET / Add action.
		/// </summary>
		[HttpGet]
		[Route("add", Name = "CategoryAddGet")]
		public ActionResult Add()
		{
			var model = new CategoryViewModel();

			model = BuilModel(model);

			return View("Manager", model);
		}

		/// <summary>
		/// POST / Add action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("add", Name = "CategoryAddPost")]
		public ActionResult Add(CategoryViewModel model)
		{
			if (ModelState.IsValid)
			{

                if (model.ParentId == null || model.ParentId == 0)
                {
                    model.Level = 0;
                }
                else
                {
                    model.Level = 1;
                }
              
                model.AddedBy = User.Id.ToString();              

                var entity = Mapper.Map<Category>(model);

                entity = _categoryRepository.Create(entity);

                //_timelineService.RegisterActivity(Realm.Admin, ActivityType.CategoryCreated, User.Id);

                //Feedback.AddMessageSuccess(CategoryResources.CategoryAddSuccessMessage);
                Feedback.AddMessageSuccess("Категория  успешно добавлена");

                return RedirectToAction(nameof(Index), nameof(CategoryController).RemoveControllerSuffix());                

            }

            model = BuilModel(model);

			return View("Manager", model);
		}
	}
}