using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{	
	public class EventTypeViewModel : BaseViewModel
	{			
		public int Id { get; set; }		

		[Display(Name = "Name", ResourceType = typeof(EventTypeResources))]
		public string Name { get; set; }
    }
}
