using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{	
	public class CategoryIndexViewModel : BaseViewModel
	{	
		public IEnumerable<Category> Categories { get; set; }
	}
}
