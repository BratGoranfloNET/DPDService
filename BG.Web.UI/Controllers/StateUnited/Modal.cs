using BG.Web.UI.Models;
using System.Web.Mvc;
using System.Collections.Generic;

namespace BG.Web.UI.Controllers
{
	public partial class StateUnitedController
	{		
		[HttpGet]
		[Route("modal", Name = "StateModalGet")]
		public ActionResult Modal(string dpdparam)
		{
			var model = new List<StateViewModel>();
			return PartialView(model);
		}
	}
}