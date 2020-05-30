using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{	
	public class EventTrackingViewModel : BaseViewModel
	{
		public int Id { get; set; }		

		[Display(Name = "Имя")]
		public string Name { get; set; }

        public long docId { get; set; }
        public System.DateTime docDate { get; set; }
        public long clientNumber { get; set; }
        public bool resultComplete { get; set; }       

    }

}
