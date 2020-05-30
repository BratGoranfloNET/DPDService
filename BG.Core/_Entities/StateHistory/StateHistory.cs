using System;

namespace BG.Core.Entities
{	
	public class StateHistory : IEntity
	{		
		public int Id { get; set; }		
		public string Name { get; set; }				
		public DateTime UTCCreation { get; set; }       
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
