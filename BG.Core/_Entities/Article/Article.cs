using System;
using System.Collections.Generic;

namespace BG.Core.Entities
{
    public class Article : IEntity
    {
        public int Id { get; set; }
        public DateTime UTCCreation { get; set; }        
        //public string AddedBy { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }
        //public string Path { get; set; }
        public string Abstract { get; set; }
        public string Body { get; set; } 
        
        //public DateTime ReleaseDate { get; set; }
        //public DateTime ExpireDate { get; set; }
        //public bool Approved { get; set; }
        //public bool CommentsEnabled { get; set; }
        //public bool OnlyForMembers { get; set; }
        //public int ViewCount { get; set; }
        //public int Votes { get; set; }
        //public int TotalRating { get; set; }

        //public Category Category { get; set; }
               
        public Guid? ImageBlobId { get; set; }
              
        public Blob ImageBlob { get; set; }
        
        public List<Tag> Tags { get; set; } = new List<Tag>();

        // public List<Comment> Comment { get; set; } = new List<Comment>();


    }

}