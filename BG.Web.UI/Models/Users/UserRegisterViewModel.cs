using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// User register view model.
	/// </summary>
	public class UserRegisterViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the user name.
		/// </summary>
		[Display(Name = "Name", ResourceType = typeof(UserResources))]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the user e-mail.
		/// </summary>
		[Display(Name = "Email", ResourceType = typeof(UserResources))]
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets the user password.
		/// </summary>
		[Display(Name = "Password", ResourceType = typeof(UserResources))]
		public string Password { get; set; }

		/// <summary>
		/// Gets or sets the user password confirmation.
		/// </summary>
		[Display(Name = "ConfirmPassword", ResourceType = typeof(UserResources))]
		public string ConfirmPassword { get; set; }

		/// <summary>
		/// Gets or sets the flag representing whether the user accepted the terms of use or not.
		/// </summary>
		[Display(Name = "TermsOfUse", ResourceType = typeof(UserResources))]
		public bool TermsOfUse { get; set; }
	}
}
