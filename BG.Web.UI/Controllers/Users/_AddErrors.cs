using Microsoft.AspNet.Identity;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial users controller.
	/// </summary>
	public partial class UsersController
	{
		/// <summary>
		/// Adds authentication resolt errors.
		/// </summary>
		[NonAction]
		private void AddErrors(IdentityResult result)
		{
			foreach (var error in result.Errors)
			{
				ModelState.AddModelError(string.Empty, error);
			}
		}
	}
}