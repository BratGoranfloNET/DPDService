using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	public class ArticleIndexViewModel : BaseViewModel
	{
		public IEnumerable<Article> Articles { get; set; }
	}
}
