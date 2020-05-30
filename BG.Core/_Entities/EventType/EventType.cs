using System;

namespace BG.Core.Entities
{
	public class EventType : IEntity
	{        
        public int Id { get; set; }
        public DateTime UTCCreation { get; set; }
        public DateTime UTCUpdate { get; set; }
        public string Name { get; set; }        
        
    }
}
