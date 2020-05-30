using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{	
	public class TokenIndexViewModel : BaseViewModel
	{
		public IEnumerable<Token> Tokens { get; set; }
	}
}
