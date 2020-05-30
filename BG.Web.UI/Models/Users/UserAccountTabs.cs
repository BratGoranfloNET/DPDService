using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Available user account tabs.
	/// </summary>
	public enum UserAccountTabs
	{
		/// <summary>
		/// Tab 1
		/// </summary>
		[Display(Name = "AccountTab1Label", ResourceType = typeof(UserResources))]
		Overview = 1,

		/// <summary>
		/// Tab 2
		/// </summary>
		[Display(Name = "AccountTab2Label", ResourceType = typeof(UserResources))]
		ProfileInfo = 2,

		/// <summary>
		/// Tab 3
		/// </summary>
		[Display(Name = "AccountTab3Label", ResourceType = typeof(UserResources))]
		GeneralSettings = 3
	}
}