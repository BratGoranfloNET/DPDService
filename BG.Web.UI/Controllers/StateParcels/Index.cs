using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	
	public partial class StateParcelsController
	{
		
		[HttpGet]
		[Route(Name = "StateParcelsIndexGet")]
		public ActionResult Index()
		{
			var model = new StateParcelsIndexViewModel();
			model.StateParcelss =  _stateparcelsRepository.GetAll();
			return View(model);
		}
	}
}