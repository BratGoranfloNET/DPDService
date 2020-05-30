using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	
	public partial class EventTrackingParameterController
	{		
		[HttpGet]
		[Route(Name = "EventTrackingParameterIndexGet")]
		public ActionResult Index()
		{
			var model = new EventTrackingParameterIndexViewModel();
			model.EventTrackingParameters =  _eventtrackingparameterRepository.GetAll();
			return View(model);
		}
	}
}