using BG.Web.UI.Models;
using System.Linq;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial platform controller.
	/// </summary>
	public partial class PlatformController
	{
		/// <summary>
		/// GET / Logs action.
		/// </summary>
		[HttpGet]
		[Route("logs", Name = "PlatformLogsGet")]
		public ActionResult Logs()
		{
			var model = new LogsViewModel();

			model.Entries = _logsRepository.GetAll().ToList();

			return View(model);
		}
	}
}