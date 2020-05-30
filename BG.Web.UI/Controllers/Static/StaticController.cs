using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	[RoutePrefix("static")]
	public class StaticController : BaseController
	{
		[Route("menu/samples", Name = "StaticMenuSamplesGet")]
		public PartialViewResult Menu()
		{
			return PartialView("MenuSamples");
		}

		[Route("data/modals/ajax", Name = "DataModalsAjaxGet")]
		public string DataModalsAjax()
		{
			return RenderPartialViewToString("~/Views/Static/Data/ModalsAjax.cshtml");
		}

		[Route("data/lightbox/ajax", Name = "DataLightboxAjaxGet")]
		public string DataLightboxAjax()
		{
			return RenderPartialViewToString("~/Views/Static/Data/LightboxAjax.cshtml");
		}

		[Route("data/tree-view/ajax/nodes-html", Name = "DataTreeViewNodesHtmlGet")]
		public string DataTreeViewNodesHtml()
		{
			return RenderPartialViewToString("~/Views/Static/Data/TreeViewNodesHtml.cshtml");
		}

		[Route("data/tree-view/ajax/json/roots", Name = "DataTreeViewNodesJsonRootsGet")]
		public string DataTreeViewNodesJsonRoots()
		{
			Response.ContentType = "application/json";

			return RenderPartialViewToString("~/Views/Static/Data/TreeViewNodesJsonRoots.cshtml");
		}

		[Route("data/tree-view/ajax/json/children", Name = "DataTreeViewNodesJsonChildrenGet")]
		public string DataTreeViewNodesJsonChildren()
		{
			Response.ContentType = "application/json";

			return RenderPartialViewToString("~/Views/Static/Data/TreeViewNodesJsonChildren.cshtml");
		}

		[Route("about", Name = "StaticAboutGet")]
		public ActionResult About()
		{
			var model = new EmptyViewModel();

			return View(model);
		}

		[Route("dashboard", Name = "StaticDashboardGet")]
		public ActionResult Dashboard()
		{
			var model = new EmptyViewModel();

			return View(model);
		}

		[Route("invoice", Name = "StaticInvoiceGet")]
		public ActionResult Invoice()
		{
			var model = new EmptyViewModel();

			return View(model);
		}

		[Route("invoice-print", Name = "StaticInvoicePrintGet")]
		public ActionResult InvoicePrint()
		{
			return View();
		}

		[Route("timeline", Name = "StaticTimelineGet")]
		public ActionResult Timeline()
		{
			var model = new EmptyViewModel();

			return View(model);
		}

		[Route("forms/{*view}", Name = "StaticFormsGet")]
		public ActionResult Forms(string view)
		{
			var model = new EmptyViewModel();

			var viewPath = $"~/Views/Static/Forms/{view.Trim('/')}.cshtml";

			return View(viewPath, model);
		}

		[Route("tables/{*view}", Name = "StaticTablesGet")]
		public ActionResult Tables(string view)
		{
			var model = new EmptyViewModel();

			var viewPath = $"~/Views/Static/Tables/{view.Trim('/')}.cshtml";

			return View(viewPath, model);
		}

		[Route("uielements/{*view}", Name = "StaticUIElementsGet")]
		public ActionResult UIElements(string view)
		{
			var model = new EmptyViewModel();

			var viewPath = $"~/Views/Static/UIElements/{view.Trim('/')}.cshtml";

			return View(viewPath, model);
		}
	}
}
