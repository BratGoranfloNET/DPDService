using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{	
	public partial class StateController
	{
		
		[HttpGet]
		[Route(Name = "StateIndexGet")]
		public ActionResult Index()
		{
			var model = new StateIndexViewModel();
			model.States =  _stateRepository.GetAll();
			return View(model);
		}
	}
}