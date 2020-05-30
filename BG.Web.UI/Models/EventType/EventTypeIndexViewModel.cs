using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{	
	public class EventTypeIndexViewModel : BaseViewModel
	{
		public IEnumerable<EventType> EventTypes { get; set; }
	}
}
