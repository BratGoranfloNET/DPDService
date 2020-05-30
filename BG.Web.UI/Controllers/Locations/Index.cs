using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class LocationsController
	{
		/// <summary>
		/// GET / Index action.
		/// </summary>
		[HttpGet]
		[Route(Name = "LocationsIndexGet")]
		public ActionResult Index()
		{
			var model = new LocationsIndexViewModel();

			model.Locations = _locationsRepository.GetAll();

			return View(model);
		}
	}
}