using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// User reset password view model.
	/// </summary>
	public class UserResetPasswordViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the e-mail address.
		/// </summary>
		[Display(Name = "Email", ResourceType = typeof(UserResources))]
		public string Email { get; set; }
	}
}
