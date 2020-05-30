using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{	
	public class StateHistoryViewModel : BaseViewModel
	{
		public int Id { get; set; }		

		[Display(Name = "Имя")]
		public string Name { get; set; }
        public string dpdOrderNr { get; set; }
        public string dpdParcelNr { get; set; }
        public string newState { get; set; }
        public System.DateTime transitionTime { get; set; }
        public string terminalCode { get; set; }
        public string terminalCity { get; set; }
        public string incidentCode { get; set; }
        public string incidentName { get; set; }
        public string consignee { get; set; }

    }
}
