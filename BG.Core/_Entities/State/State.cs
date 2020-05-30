using System;

namespace BG.Core.Entities
{	
	public class State : IEntity
	{		
		public int Id { get; set; }		
		public string Name { get; set; }				
		public DateTime UTCCreation { get; set; }
        public int StateParcelsId { get; set; }
        public string clientOrderNr { get; set; }
        public string clientParcelNr { get; set; }
        public string dpdOrderNr { get; set; }
        public string dpdParcelNr { get; set; }
        public System.DateTime pickupDate { get; set; }
        public string dpdOrderReNr { get; set; }
        public string dpdParcelReNr { get; set; }
        public bool isReturn { get; set; }
        public bool isReturnSpecified { get; set; }
        public System.DateTime planDeliveryDate { get; set; }
        public bool planDeliveryDateSpecified { get; set; }
        public string newState { get; set; }
        public System.DateTime transitionTime { get; set; }
        public string terminalCode { get; set; }
        public string terminalCity { get; set; }
        public string incidentCode { get; set; }
        public string incidentName { get; set; }
        public string consignee { get; set; }             
        
    }
}
