using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{	
	public class EventTrackingTypeIndexViewModel : BaseViewModel
	{	
		public IEnumerable<EventTrackingType> EventTrackingTypes { get; set; }
	}
}
