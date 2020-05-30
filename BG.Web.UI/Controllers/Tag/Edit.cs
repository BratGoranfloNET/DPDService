using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Net;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{	
	public partial class TagController
	{
	
		[HttpGet]
		[Route("{id:int}/edit", Name = "TagEditGet")]
		public ActionResult Edit(int id)
		{
			var entity = _tagRepository.GetById(id);

			if (entity.Id <= 0)
				return ErrorResult(HttpStatusCode.NotFound);

			var model = Mapper.Map<TagViewModel>(entity);
			model = BuilModel(model);
			return View("Manager", model);
		}
				
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("{id:int}/edit", Name = "TagEditPost")]
		public ActionResult Edit(TagViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = Mapper.Map<Tag>(model);
				entity = _tagRepository.Update(entity);
				Feedback.AddMessageSuccess(TagResources.TagEditSuccessMessage);
				return RedirectToAction(nameof(Index), nameof(TagController).RemoveControllerSuffix());
			}

			model = BuilModel(model);
			return View("Manager", model);
		}
	}
}