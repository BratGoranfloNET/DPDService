using BG.Core.Entities;
using BG.Core.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{	
	public class ArticleViewModel : BaseViewModel
	{        		        		
		public int Id { get; set; }      
       

        [Display(Name = "CategoryId", ResourceType = typeof(ArticleResources))]
        public int? CategoryId { get; set; }


        [Display(Name = "ArticleTitle", ResourceType = typeof(ArticleResources))]
        public string Title { get; set; }   
        

        [Display(Name = "ArticleAbstract", ResourceType = typeof(ArticleResources))]
        public string Abstract { get; set; } 
        
        public string Body { get; set; }  
        
        public SelectList Categories { get; set; }

        public long ImageUploadMaxLengthInBytes { get; set; } = 0;

        public string ImageBlobName { get; set; }        

       
        [Display(Name = "ImageBlobId", ResourceType = typeof(LocationResources))]
        public Guid? ImageBlobId { get; set; }
                                   
        
        [Display(Name = "TagId", ResourceType = typeof(DepartmentResources))]
        public int? TagId { get; set; }  
        
        public SelectList Tags { get; set; }
        public IEnumerable<TagResultViewModel> TagResultViewModel { get; set; }                    

    }
}
