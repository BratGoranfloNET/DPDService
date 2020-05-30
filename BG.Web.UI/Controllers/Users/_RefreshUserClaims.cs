using Microsoft.AspNet.Identity;
using BG.Web.Identity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial users controller.
	/// </summary>
	public partial class UsersController
	{
		/// <summary>
		/// Refresh claims identity cookie data.
		/// </summary>
		[NonAction]
		private async Task RefreshUserClaims(int userId)
		{
			var dotUser = _userManager.FindById(userId);

			await RefreshUserClaims(dotUser);
		}

		/// <summary>
		/// Refresh claims identity cookie data.
		/// </summary>
		[NonAction]
		private async Task RefreshUserClaims(DotUser dotUser)
		{
			if (dotUser != null)
				await _signInManager.SignInAsync(dotUser, true, false);
		}
	}
}