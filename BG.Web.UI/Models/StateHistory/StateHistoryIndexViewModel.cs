using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{	
	public class StateHistoryIndexViewModel : BaseViewModel
	{
		public IEnumerable<StateHistory> States { get; set; }
	}
}
