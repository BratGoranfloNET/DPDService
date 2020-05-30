using BG.Core.Resources;
using BG.Web.Identity;
using BG.Web.UI.Models;
using System.Dynamic;
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
		/// Renders the reset password email contents.
		/// </summary>
		[NonAction]
		private string GetResetPasswordMessageContent(DotUser dotUser, string resetToken, string subject)
		{
			dynamic mail = new ExpandoObject();

			mail.Subject = subject;

			mail.Name = dotUser.Name;

			mail.Link = Url.Action(nameof(UsersController.ResetPasswordCallback), nameof(UsersController).RemoveControllerSuffix(), new {
				userId = dotUser.Id,
				resetToken = resetToken
			}, protocol: Request.Url.Scheme);

			return RenderViewToString("~/Views/Users/_Emails/ResetPasswordTemplate.cshtml", model: mail);
		}

		/// <summary>
		/// GET / Reset password method.
		/// </summary>
		[HttpGet]
		[AllowAnonymous]
		[Route("reset-password", Name = "UsersResetPasswordGet")]
		public ActionResult ResetPassword(ActionStatus? status)
		{
			if (Request.IsAuthenticated)
				return GetDefaultRedirectRoute();

			if (status == ActionStatus.Success)
				return View("ResetPasswordMessageSent", new EmptyViewModel());

			return View(new UserResetPasswordViewModel());
		}

		/// <summary>
		/// POST / Reset password method.
		/// </summary>
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		[Route("reset-password", Name = "UsersResetPasswordPost")]
		public async Task<ActionResult> ResetPassword(UserResetPasswordViewModel model)
		{
			if (Request.IsAuthenticated)
				return GetDefaultRedirectRoute();

			if (ModelState.IsValid)
			{
				var userEmail = model.Email;

				var user = await _userManager.FindByEmailAsync(userEmail);

				// Don't reveal that the user does not exist
				if (user != null)
				{
					var subject = UserResources.ResetPasswordMessageSubject;

					var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user.Id);

					var messageContent = GetResetPasswordMessageContent(user, resetToken, subject);

					await _userManager.SendEmailAsync(user.Id, subject, messageContent);
				}

				return RedirectToAction(nameof(UsersController.ResetPassword), nameof(UsersController).RemoveControllerSuffix(), new { status = ActionStatus.Success.ToLowerCaseString() });
			}

			return View(model);
		}
	}
}
