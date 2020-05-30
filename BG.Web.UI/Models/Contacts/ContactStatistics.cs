using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Contact statistics model.
	/// </summary>
	public class ContactStatistics
	{
		/// <summary>
		/// Gets or sets the total registrations
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Gets or sets the latest registrations.
		/// </summary>
		public List<object> Latest { get; set; }

		/// <summary>
		/// Gets or sets weekly general purpose data.
		/// </summary>
		public List<object> WeeklyRegistrations { get; set; }
	}
}
