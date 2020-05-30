using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Calendar events index view model.
	/// </summary>
	public class CalendarEventsIndexViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the calendar events list.
		/// </summary>
		public IEnumerable<Event> Events { get; set; }
	}
}
