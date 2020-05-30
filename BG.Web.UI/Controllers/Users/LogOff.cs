using Microsoft.AspNet.Identity;
using BG.Web.UI.Attributes;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial users controller.
	/// </summary>
	public partial class UsersController
	{
		/// <summary>
		/// GET|POST / Logoff method.
		/// </summary>
		[LockScreenAllowed]
		[Route("logoff", Name = "UserLogOffGetPost")]
		public ActionResult LogOff()
		{
			_authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

			return GetDefaultRedirectRoute();
		}
	}
}