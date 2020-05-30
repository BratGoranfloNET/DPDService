using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{	
	public partial class StateUnitedController
	{
		[Route("indexajax", Name = "StateUnitedIndexAjaxGet")]      
        public ActionResult IndexAjax()
		{
			var model = new StateUnitedIndexViewModel();
			return View(model);
		}
	}
}