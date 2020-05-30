using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// User login view model.
	/// </summary>
	public class UserLoginViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the email or user name.
		/// </summary>
		[Display(Name = "EmailOrUsername", ResourceType = typeof(UserResources))]
		public string EmailOrUsername { get; set; }

		/// <summary>
		/// Gets or sets the password.
		/// </summary>
		[Display(Name = "Password", ResourceType = typeof(UserResources))]
		public string Password { get; set; }

		/// <summary>
		/// Gets or sets the remember me flag.
		/// </summary>
		[Display(Name = "RememberMe", ResourceType = typeof(UserResources))]
		public bool RememberMe { get; set; }
	}
}
