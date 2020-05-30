using System;

namespace BG.Core.Entities
{
	public class EventTrackingType : IEntity
	{		
		public int Id { get; set; }		
		public string Name { get; set; }				
		public DateTime UTCCreation { get; set; }
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
        public EventTrackingParameter [] parameter { get; set; }

    }
}
