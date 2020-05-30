using System;

namespace BG.Core.Entities
{	
	public class EventTrackingParameter : IEntity
	{		
		public int Id { get; set; }		
		public string Name { get; set; }				
		public DateTime UTCCreation { get; set; }
        public int  EventTrackingTypeId { get; set; }
        public string paramName { get; set; }
        public string valueString { get; set; }
        public decimal valueDecimal { get; set; }
        public bool valueDecimalSpecified { get; set; }
        public System.DateTime valueDateTime { get; set; }
        public bool valueDateTimeSpecified { get; set; }
        public EventTrackingUnitLoad[] value { get; set; }
        public string type { get; set; }
    }
}
