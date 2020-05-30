using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{	
	public class EventTrackingTypeViewModel : BaseViewModel
	{
		public int Id { get; set; }		

		[Display(Name = "Имя")]
		public string Name { get; set; }
        public int EventTrackingId { get; set; }
        public string clientOrderNr { get; set; }
        public string clientCodeInternal { get; set; }
        public string clientParcelNr { get; set; }
        public string dpdOrderNr { get; set; }
        public string dpdParcelNr { get; set; }
        public string eventNumber { get; set; }
        public string eventCode { get; set; }
        public string eventName { get; set; }
        public string reasonCode { get; set; }
        public string reasonName { get; set; }
        public string eventDate { get; set; }    

    }
}
