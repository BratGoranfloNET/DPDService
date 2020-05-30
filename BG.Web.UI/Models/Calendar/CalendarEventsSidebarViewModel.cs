using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Calendar events sidebar widget view model.
	/// </summary>
	public class CalendarEventsSidebarViewModel
	{
		/// <summary>
		/// Gets or sets the calendar events list.
		/// </summary>
		public IEnumerable<Event> UpcomingEvents { get; set; }
	}
}
