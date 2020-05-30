using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial users controller.
	/// </summary>
	public partial class UsersController
	{
		/// <summary>
		/// GET / Terms of user method.
		/// </summary>
		[AllowAnonymous]
		[Route("terms-of-use", Name = "UserTermsOfUseGet")]
		public ActionResult TermsOfUse()
		{
			var model = new EmptyViewModel();

			return PartialView(model);
		}
	}
}