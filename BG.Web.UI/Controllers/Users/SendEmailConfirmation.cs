using BG.Core.Resources;
using BG.Web.Identity;
using BG.Web.UI.Models;
using System.Dynamic;
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
		/// Renders the confirmation email contents.
		/// </summary>
		[NonAction]
		public string GetEmailConfirmationMessageContent(DotUser dotUser, string code, string subject)
		{
			dynamic mail = new ExpandoObject();

			mail.Subject = subject;

			mail.Name = dotUser.Name;

			mail.Link = Url.Action(nameof(UsersController.SendEmailConfirmationCallback), nameof(UsersController).RemoveControllerSuffix(), new
			{
				code = code,
				userId = dotUser.Id
			}, protocol: Request.Url.Scheme);

			return RenderViewToString("~/Views/Users/_Emails/EmailConfirmationTemplate.cshtml", model: mail);
		}

		/// <summary>
		/// Send a new email confirmation message.
		/// </summary>
		[HttpGet]
		[AllowAnonymous]
		[Route("send-email-confirmation", Name = "UsersSendEmailConfirmationGet")]
		public async Task<ActionResult> SendEmailConfirmation(int userId, ActionStatus? status)
		{
			if (Request.IsAuthenticated)
				return GetDefaultRedirectRoute();

			if (status == ActionStatus.Success)
				return View("SendEmailConfirmationSuccess", new EmptyViewModel());

			var user = await _userManager.FindByIdAsync(userId);

			if (user == null || await _userManager.IsEmailConfirmedAsync(user.Id))
				return ErrorResult(HttpStatusCode.BadRequest, UserResources.EmailConfirmationMessageError);

			var subject = UserResources.EmailConfirmationMessageSubject;

			var userCode = await _userManager.GenerateEmailConfirmationTokenAsync(user.Id);

			var messageContent = GetEmailConfirmationMessageContent(user, userCode, subject);

			await _userManager.SendEmailAsync(user.Id, subject, messageContent);

			return RedirectToAction(nameof(UsersController.SendEmailConfirmation), nameof(UsersController).RemoveControllerSuffix(), new { status = ActionStatus.Success.ToLowerCaseString() });
		}
	}
}
