using Omu.ValueInjecter;
using BG.Core.Entities;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	
	public partial class TagController
	{		
		[HttpGet]
		[Route("add", Name = "TagAddGet")]
		public ActionResult Add()
		{
			var model = new TagViewModel();
			model = BuilModel(model);
			return View("Manager", model);
		}
		
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("add", Name = "TagAddPost")]
		public ActionResult Add(TagViewModel model)
		{
			if (ModelState.IsValid)
			{
				var entity = Mapper.Map<Tag>(model);
				entity = _tagRepository.Create(entity);			
				Feedback.AddMessageSuccess(TagResources.TagAddSuccessMessage);
				return RedirectToAction(nameof(Index), nameof(TagController).RemoveControllerSuffix());
			}

			model = BuilModel(model);
			return View("Manager", model);
		}
	}
}