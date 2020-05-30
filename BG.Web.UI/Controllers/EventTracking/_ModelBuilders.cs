using BG.Core.Entities;
using BG.Web.UI.Models;
using System.Linq;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	public partial class EventTrackingController
	{
		
		[NonAction]
		private EventTrackingViewModel BuilModel(EventTrackingViewModel model)
		{
			return model;
		}
	}
}