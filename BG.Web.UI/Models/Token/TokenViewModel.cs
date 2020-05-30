
namespace BG.Web.UI.Models
{	public class TokenViewModel : BaseViewModel
	{		
		public int Id { get; set; }
		public int UserId { get; set; }
        public string TokenString { get; set; }
        public string IP { get; set; }

    }
}
