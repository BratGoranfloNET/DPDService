using System;

namespace BG.Core.Entities
{	
	public class Tag : IEntity
	{		
		public int Id { get; set; }		
		public string Name { get; set; }				
		public DateTime UTCCreation { get; set; }    
        
    }
}
