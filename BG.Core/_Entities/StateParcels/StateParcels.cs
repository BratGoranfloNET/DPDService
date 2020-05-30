using System;

namespace BG.Core.Entities
{	
	public class StateParcels : IEntity
	{		
		public int Id { get; set; }		
		public string Name { get; set; }				
		public DateTime UTCCreation { get; set; }
        public long docId { get; set; }
        public System.DateTime docDate { get; set; }
        public long clientNumber { get; set; }
        public bool resultComplete { get; set; }        
        public State[] states { get; set; }

    }
}
