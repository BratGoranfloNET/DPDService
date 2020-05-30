using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{	
	public class TagViewModel : BaseViewModel
	{
		public int Id { get; set; }		

		[Display(Name = "Имя тэга")]
		public string Name { get; set; }       

    }
}
