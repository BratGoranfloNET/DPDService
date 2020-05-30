using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial users controller.
	/// </summary>
	public partial class UsersController
	{
		/// <summary>
		/// Safelly redirect user for a local website route.
		/// </summary>
		[NonAction]
		private ActionResult RedirectToLocal(string returnUrl = null)
		{
			if (Url.IsLocalUrl(returnUrl))
				return Redirect(returnUrl);

			return GetDefaultRedirectRoute();
		}
	}
}