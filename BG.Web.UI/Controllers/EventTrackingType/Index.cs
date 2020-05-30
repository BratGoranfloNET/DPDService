using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{	
	public partial class EventTrackingTypeController
	{		
		[HttpGet]
		[Route(Name = "EventTrackingTypeIndexGet")]
		public ActionResult Index()
		{
			var model = new EventTrackingTypeIndexViewModel();
			model.EventTrackingTypes =  _eventtrackingtypeRepository.GetAll();
			return View(model);
		}
	}
}