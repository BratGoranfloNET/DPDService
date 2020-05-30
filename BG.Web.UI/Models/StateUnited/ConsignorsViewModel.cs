using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{	
	public class ConsignorsViewModel : BaseViewModel
	{
		public int Id { get; set; }		

		[Display(Name = "Имя")]
		public string Name { get; set; }  

    }
}
