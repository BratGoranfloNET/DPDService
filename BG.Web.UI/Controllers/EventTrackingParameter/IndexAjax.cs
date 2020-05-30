using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{	
	public partial class EventTrackingParameterController
	{       
        [HttpGet]
		[Route("ajax", Name = "EventTrackingParameterIndexAjaxGet")]
		public ActionResult IndexAjax()
		{
			var model = new EventTrackingParameterIndexViewModel();
			return View(model);
		}
	}
}