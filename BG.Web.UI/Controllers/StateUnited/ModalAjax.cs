using BG.Web.UI.Models;
using System.Web.Mvc;
using System.Collections.Generic;

namespace BG.Web.UI.Controllers
{
	public partial class StateUnitedController
	{
		
		[HttpGet]
		[Route("modalajax", Name = "StateModalAjaxGet")]
		public ActionResult ModalAjax(string dpdparam)
		{
			var model = new List<StateViewModel>();
			return PartialView(model);
		}
	}
}