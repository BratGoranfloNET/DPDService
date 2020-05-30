using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{	
	public class EventTrackingStatistics
	{	
		public int Count { get; set; }
				
		public List<object> Latest { get; set; }
		
		public List<object> WeeklyRegistrations { get; set; }
	}
}
