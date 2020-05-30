using BG.Core.Resources;
using BG.Web.UI.Models;
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
		/// GET / Edit profile method.
		/// </summary>
		[HttpGet]
		[Route("change-password", Name = "UserChangePasswordGet")]
		public ActionResult ChangePassword()
		{
			return View(new UserChangePasswordViewModel());
		}

		/// <summary>
		/// POST / Edit profile method.
		/// </summary>
		[HttpPost]
		[ValidateAntiForgeryToken]
		[Route("change-password", Name = "UserChangePasswordPost")]
		public async Task<ActionResult> ChangePassword(UserChangePasswordViewModel model)
		{
			if (ModelState.IsValid)
			{
				var uId = User.Id;
				var cPwd = model.Password;
				var nPwd = model.NewPassword;

				var result = await _userManager.ChangePasswordAsync(uId, cPwd, nPwd);

				if (result.Succeeded)
				{
					Feedback.AddMessageSuccess(UserResources.PasswordChangeSuccessMessage);

					return RedirectToAction(nameof(UsersController.Account), nameof(UsersController).RemoveControllerSuffix(), new { tab = UserAccountTabs.GeneralSettings.ToSlug() });
				}

				ModelState.AddModelError("Password", UserResources.ChangePasswordCurrentInvalidMessage);
			}

			return View(model);
		}
	}
}