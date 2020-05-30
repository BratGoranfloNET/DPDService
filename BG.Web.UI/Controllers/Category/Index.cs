using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class CategoryController
	{
		/// <summary>
		/// GET / Index action.
		/// </summary>
		[HttpGet]
		[Route(Name = "CategoryIndexGet")]
		public ActionResult Index()
		{
			var model = new CategoryIndexViewModel();

			model.Categories =  _categoryRepository.GetAll();

			return View(model);
		}
	}
}