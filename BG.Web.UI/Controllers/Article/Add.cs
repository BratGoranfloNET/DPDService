using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Web.Mvc;
using System;
using BG.Web.UI.Extensions;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class ArticleController
	{
		/// <summary>
		/// GET / Add action.
		/// </summary>
		[HttpGet]
		[Route("add", Name = "ArticleAddGet")]
		public ActionResult Add()
		{
			var model = new ArticleViewModel();

            model = BuilModel(model);

           // model.ExpireDate = DateTime.UtcNow;
           // model.ReleaseDate = DateTime.UtcNow;

            return View("Manager", model);
		}

		/// <summary>
		/// POST / Add action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Route("add", Name = "ArticleAddPost")]
		public ActionResult Add(ArticleViewModel model)
		{
			if (ModelState.IsValid)
			{

                // model.AddedBy = User.Id.ToString();
                // model.Path = Transliter.Trans(model.Title).ToUrlFormat();               
                // model.OnlyForMembers = true;
                // model.ViewCount = 0;
                // model.Votes = 0;
                // model.TotalRating = 0;

                model.Abstract = "-";

                var entity = Mapper.Map<Article>(model);

                entity = _articleRepository.Create(entity);

                //_timelineService.RegisterActivity(Realm.Admin, ActivityType.ArticleCreated, User.Id);

                //Feedback.AddMessageSuccess(ArticleResources.ArticleAddSuccessMessage);
                Feedback.AddMessageSuccess("Статья успешно добавлена");

                return RedirectToAction(nameof(Index), nameof(ArticleController).RemoveControllerSuffix());                

            }

            model = BuilModel(model);

			return View("Manager", model);
		}
	}
}