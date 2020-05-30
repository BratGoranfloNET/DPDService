using System;
using System.Collections.Generic;

namespace BG.Core.Entities
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int? Level { get; set; }
        public DateTime UTCCreation { get; set; }
        public Guid? ImageBlobId { get; set; }
        public Blob ImageBlob { get; set; }
        public string AddedBy { get; set; }
        public string Title { get; set; }
        public int Importance { get; set; }
        public string Description { get; set; }       
        public Category ParentCategory { get; set; }
        public List<Category> ChildCategories { get; set; } = new List<Category>();
        public List<Article> Articles { get; set; } = new List<Article>();

    }
}