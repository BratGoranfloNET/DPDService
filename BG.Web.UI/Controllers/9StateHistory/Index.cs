using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class StateHistoryController
    {
		/// <summary>
		/// GET / Index action.
		/// </summary>
		[HttpGet]
		[Route(Name = "StateHistoryIndexGet")]
		public ActionResult Index()
		{
			var model = new StateHistoryIndexViewModel();

			model.States =  _statehistoryRepository.GetAll();

			return View(model);

		}


	}
}