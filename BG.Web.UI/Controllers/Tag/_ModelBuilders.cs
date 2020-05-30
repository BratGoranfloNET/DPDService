using BG.Core.Entities;
using BG.Web.UI.Models;
using System.Linq;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	public partial class TagController
	{		
		[NonAction]
		private TagViewModel BuilModel(TagViewModel model)
		{           

			return model;
		}
	}
}