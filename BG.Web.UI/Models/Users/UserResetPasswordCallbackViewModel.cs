using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// User reset password callback view model.
	/// </summary>
	public class UserResetPasswordCallbackViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the password reset code.
		/// </summary>
		public string ResetToken { get; set; }

		/// <summary>
		/// Gets or sets the e-mail.
		/// </summary>
		[Display(Name = "Email", ResourceType = typeof(UserResources))]
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		[Display(Name = "Password", ResourceType = typeof(UserResources))]
		public string Password { get; set; }

		/// <summary>
		/// Gets or sets the password confirmation.
		/// </summary>
		[Display(Name = "ConfirmPassword", ResourceType = typeof(UserResources))]
		public string ConfirmPassword { get; set; }
	}
}
