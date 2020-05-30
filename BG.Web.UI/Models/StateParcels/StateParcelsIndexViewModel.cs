using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{	
	public class StateParcelsIndexViewModel : BaseViewModel
	{		
		public IEnumerable<StateParcels> StateParcelss { get; set; }
	}
}
