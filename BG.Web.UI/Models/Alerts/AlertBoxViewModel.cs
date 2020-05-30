using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Alert box view model class.
	/// </summary>
	public class AlertBoxViewModel
	{
		/// <summary>
		/// Gets or sets the existing alerts.
		/// </summary>
		public List<AlertViewModel> Alerts { get; set; } = new List<AlertViewModel>();
	}
}
