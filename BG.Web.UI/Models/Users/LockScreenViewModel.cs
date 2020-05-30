using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Lock screen view model.
	/// </summary>
	public class LockScreenViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or set the password.
		/// </summary>
		[Display(Name = "Password", ResourceType = typeof(UserResources))]
		public string Password { get; set; }
	}
}
