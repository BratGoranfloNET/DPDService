using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	public class TagIndexViewModel : BaseViewModel
	{	
		public IEnumerable<Tag> Tags{ get; set; }
	}
}
