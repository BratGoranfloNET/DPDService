using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{	
	public class StateUnitedIndexViewModel : BaseViewModel
	{		
		public IEnumerable<StateUnited> StateUniteds { get; set; }
        public int CurrStateUnitedId { get; set; } = 0;
    }
}
