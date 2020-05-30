using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// User change password view model.
	/// </summary>
	public class UserChangePasswordViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or set the current user password.
		/// </summary>
		[Display(Name = "Password", ResourceType = typeof(UserResources))]
		public string Password { get; set; }

		/// <summary>
		/// Gets or sets the new user password.
		/// </summary>
		[Display(Name = "NewPassword", ResourceType = typeof(UserResources))]
		public string NewPassword { get; set; }

		/// <summary>
		/// Gets or sets the new user password confirmation.
		/// </summary>
		[Display(Name = "NewPasswordConfirmation", ResourceType = typeof(UserResources))]
		public string NewPasswordConfirmation { get; set; }
	}
}
