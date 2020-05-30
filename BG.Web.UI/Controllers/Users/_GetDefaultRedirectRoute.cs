using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial users controller.
	/// </summary>
	public partial class UsersController
	{
		/// <summary>
		/// Get the default redirect route that will determine where the user will be navigated to.
		/// </summary>
		public RedirectToRouteResult GetDefaultRedirectRoute() => RedirectToAction(nameof(HomeController.Index), nameof(HomeController).RemoveControllerSuffix());
	}
}