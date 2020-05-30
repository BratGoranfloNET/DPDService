using System;

namespace BG.Core.Entities
{	
	public class EventTrackingUnitLoad : IEntity
	{		
		public int Id { get; set; }		
		public string Name { get; set; }				
		public DateTime UTCCreation { get; set; }
        public int  EventTrackingParameterId { get; set; }
        public string article { get; set; }
        public string descript { get; set; }
        public string declared_value { get; set; }
        public string parcel_num { get; set; }
        public string npp_amount { get; set; }
        public int vat_percent { get; set; }
        public bool vat_percentSpecified { get; set; }
        public bool without_vat { get; set; }
        public bool without_vatSpecified { get; set; }
        public int countField { get; set; }
        public string state_name { get; set; }
    }
}
