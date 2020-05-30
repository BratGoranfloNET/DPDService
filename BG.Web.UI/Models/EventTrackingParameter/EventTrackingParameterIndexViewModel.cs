using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	public class EventTrackingParameterIndexViewModel : BaseViewModel
	{
		public IEnumerable<EventTrackingParameter> EventTrackingParameters { get; set; }
	}
}
