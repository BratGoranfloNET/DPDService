using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{	
	public partial class StateUnitedController
	{
		
		[HttpGet]
		[Route(Name = "StateUnitedIndexGet")]
		public ActionResult Index()
		{
			var model = new StateUnitedIndexViewModel();
			model.StateUniteds =  _stateunitedRepository.GetAll();
			return View(model);
		}

	}

}