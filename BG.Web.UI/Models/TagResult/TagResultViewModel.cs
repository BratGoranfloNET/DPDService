
namespace BG.Web.UI.Models
{	
	public class TagResultViewModel : BaseViewModel
	{
        public int Id { get; set; }        
        public int? TagId { get; set; }
        public int? ArticleId { get; set; }
        public string TagName { get; set; }
        public string ArticleName { get; set; }        

    }
}
