using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{	
	public partial class EventTrackingController
	{		
		[HttpGet]
		[Route(Name = "EventTrackingIndexGet")]
		public ActionResult Index()
		{
			var model = new EventTrackingIndexViewModel();
			model.EventTrackings =  _eventtrackingRepository.GetAll();
			return View(model);
		}
	}
}