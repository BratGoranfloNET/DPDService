using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial home controller.
	/// </summary>
	public partial class HomeController
	{
		/// <summary>
		/// GET / Index action.
		/// </summary>
		[Route(Name = "HomeIndexGet")]
		public ActionResult Index()
		{
			if (HttpContext.Request.IsAuthenticated)
				return RedirectToAction(nameof(DashboardController.Index), nameof(DashboardController).RemoveControllerSuffix());

			return RedirectToAction(nameof(UsersController.Login), nameof(UsersController).RemoveControllerSuffix());
		}
	}
}