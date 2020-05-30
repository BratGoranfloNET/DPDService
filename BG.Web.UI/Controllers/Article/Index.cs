using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class ArticleController
	{
		/// <summary>
		/// GET / Index action.
		/// </summary>
		[HttpGet]
		[Route(Name = "ArticleIndexGet")]
		public ActionResult Index()
		{
			var model = new ArticleIndexViewModel();

			model.Articles =  _articleRepository.GetAll();

			return View(model);
		}
	}
}