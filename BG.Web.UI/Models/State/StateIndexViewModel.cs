using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	public class StateIndexViewModel : BaseViewModel
	{		
		public IEnumerable<State> States { get; set; }
	}
}
