using BG.Core.Entities;
using BG.Core.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	
	public class CategoryViewModel : BaseViewModel
	{		        		
		public int Id { get; set; }

        [Display(Name = "ParentCategoryId", ResourceType = typeof(CategoryResources))]
        public int? ParentId { get; set; }

        public int? Level { get; set; }
                
		public long ImageUploadMaxLengthInBytes { get; set; } = 0;

        public string ImageBlobName { get; set; }
        
		[Display(Name = "ImageBlobId", ResourceType = typeof(LocationResources))]
        public Guid? ImageBlobId { get; set; }


        [Display(Name = "CategoryTitle", ResourceType = typeof(CategoryResources))]
        public string Title { get; set; }
        
        public string AddedBy { get; set; }

        [Display(Name = "ImportanceTitle", ResourceType = typeof(CategoryResources))]
        public int Importance { get; set; }


        [Display(Name = "DescriptionTitle", ResourceType = typeof(CategoryResources))]
        public string Description { get; set; }        

        public List<CategoryViewModel> ChildCategory { get; set; } = new List<CategoryViewModel>();
                
        public SelectList ParentCategory { get; set; }

    }
}
