using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{	
	public partial class TagController
	{
		
		[HttpGet]
		[Route(Name = "TagIndexGet")]
		public ActionResult Index()
		{
			var model = new TagIndexViewModel();
			model.Tags =  _tagRepository.GetAll();
			return View(model);
		}
	}
}