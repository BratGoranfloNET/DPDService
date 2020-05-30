using System;

namespace BG.Core.Entities
{
	public class TagResult : IEntity
	{           
        public int Id { get; set; }
        public DateTime UTCCreation { get; set; }
        public DateTime UTCUpdate { get; set; }        
	    public int? ArticleId { get; set; }
        public int? TagId { get; set; }
     
	}
}
