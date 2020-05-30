using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Users view model.
	/// </summary>
	public class PlatformUsersViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the users.
		/// </summary>
		public List<PlatformUserViewModel> Users { get; set; } = new List<PlatformUserViewModel>();
	}
}
