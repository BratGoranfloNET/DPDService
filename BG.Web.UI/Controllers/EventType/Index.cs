using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class EventTypeController
	{
		/// <summary>
		/// GET / Index action.
		/// </summary>
		[HttpGet]
		[Route(Name = "EventTypeIndexGet")]
		public ActionResult Index()
		{
			var model = new EventTypeIndexViewModel();

			model.EventTypes =  _eventtypeRepository.GetAll();

			return View(model);
		}
	}
}