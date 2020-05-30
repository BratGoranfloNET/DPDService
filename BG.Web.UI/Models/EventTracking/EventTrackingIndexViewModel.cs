using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{	
	public class EventTrackingIndexViewModel : BaseViewModel
	{		
		public IEnumerable<EventTracking> EventTrackings { get; set; }
	}
}
