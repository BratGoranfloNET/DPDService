using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Net;
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
		/// GET / Reset password callback method.
		/// </summary>
		[HttpGet]
		[AllowAnonymous]
		[Route("reset-password-callback", Name = "UsersResetPasswordCallbackGet")]
		public ActionResult ResetPasswordCallback(string resetToken)
		{
			if (Request.IsAuthenticated)
				return GetDefaultRedirectRoute();

			if (resetToken == null)
				return ErrorResult(HttpStatusCode.BadRequest);

			var model = new UserResetPasswordCallbackViewModel()
			{
				ResetToken = resetToken
			};

			return View(model);
		}

		/// <summary>
		/// POST / Reset password callback method.
		/// </summary>
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		[Route("reset-password-callback", Name = "UsersResetPasswordCallbackPost")]
		public async Task<ActionResult> ResetPasswordCallback(UserResetPasswordCallbackViewModel model)
		{
			if (Request.IsAuthenticated)
				return GetDefaultRedirectRoute();

			if (ModelState.IsValid)
			{
				string userEmail = model.Email;

				var user = await _userManager.FindByEmailAsync(userEmail);

				if (user != null)
				{
					var result = await _userManager.ResetPasswordAsync(user.Id, model.ResetToken, model.Password);

					if (result.Succeeded)
					{
						await _signInManager.PasswordSignInAsync(userEmail, model.Password, true, shouldLockout: false);

						return RedirectToLocal();
					}

					AddErrors(result);
				}
				else
					ModelState.AddModelError(string.Empty, UserResources.ResetPasswordGeneralErrorMessage);
			}

			return View(model);
		}
	}
}
