using System;

namespace BG.Core.Entities
{	
	public class Token : IEntity
	{
		public long Id { get; set; }
        public int UserId { get; set; }
        public string TokenString { get; set; }
        public string IP { get; set; }
        public DateTime UTCCreation { get; set; }
        public DateTime ExpiredTime { get; set; }               
        public DateTime UTCUpdate { get; set; }

    }

}
