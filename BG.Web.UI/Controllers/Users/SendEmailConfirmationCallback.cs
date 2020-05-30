using BG.Core.Resources;
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
		/// Callback for verifying and confirming the user e-mail.
		/// </summary>
		[HttpGet]
		[AllowAnonymous]
		[Route("send-email-confirmation-callback", Name = "UsersSendEmailConfirmationCallbackGet")]
		public async Task<ActionResult> SendEmailConfirmationCallback(int userId, string code)
		{
			if (Request.IsAuthenticated)
				return GetDefaultRedirectRoute();

			var user = await _userManager.FindByIdAsync(userId);

			if (user == null || code == null)
				return ErrorResult(HttpStatusCode.NotFound);

			var result = await _userManager.ConfirmEmailAsync(user.Id, code);

			if (!result.Succeeded)
				return ErrorResult(HttpStatusCode.BadRequest, UserResources.EmailConfirmationCallbackErrorMessage);

			await _signInManager.SignInAsync(user, isPersistent: true, rememberBrowser: false);

			return RedirectToLocal();
		}
	}
}