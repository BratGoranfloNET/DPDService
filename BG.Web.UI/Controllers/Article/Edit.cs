using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Net;
using System.Web.Mvc;
using BG.Web.UI.Extensions;
using System;
using System.Collections.Generic;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class ArticleController
	{
		/// <summary>
		/// GET / Edit action.
		/// </summary>
		[HttpGet]
		[Route("{id:int}/edit", Name = "ArticleEditGet")]
		public ActionResult Edit(int id)
		{
			var entity = _articleRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			var model = Mapper.Map<ArticleViewModel>(entity);

			model = BuilModel(model);


            IEnumerable<TagResult> tag_entity = _tagresultRepository.GetTagsIdsByArticletId(id);


            // А можно и так :) (PositionResultViewModelMaps.cs)
            List<TagResultViewModel> tag_model = new List<TagResultViewModel>();
            foreach (TagResult item in tag_entity)
            {
                var model1 = Mapper.Map<TagResultViewModel>(item);
                tag_model.Add(model1);
            }


            model.TagResultViewModel = tag_model;



            return View("Manager", model);
		}

		/// <summary>
		/// POST / Edit action.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
        [ValidateInput(false)]
        [Route("{id:int}/edit", Name = "ArticleEditPost")]
		public ActionResult Edit(ArticleViewModel model)
		{
			if (ModelState.IsValid)
			{
                // model.Path = Transliter.Trans(model.Title).ToUrlFormat();               
                // model.OnlyForMembers = true;

                model.Abstract = "-";

                var entity = Mapper.Map<Article>(model);

				entity = _articleRepository.Update(entity);

                //_timelineService.RegisterActivity(Realm.BG, ActivityType.LocationUpdated, User.Id);

                //Feedback.AddMessageSuccess(ArticleResources.ArticleEditSuccessMessage);
                Feedback.AddMessageSuccess("Категория успешно отредактирована !");

                return RedirectToAction(nameof(Index), nameof(ArticleController).RemoveControllerSuffix());
			}

			model = BuilModel(model);

			return View("Manager", model);
		}
	}
}