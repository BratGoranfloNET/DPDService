using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial alerts controller.
	/// </summary>
	[Authorize]
	[RoutePrefix("alerts")]
	public partial class AlertsController : BaseController
	{
		/// <summary>
		/// Contructor method.
		/// </summary>
		public AlertsController()
		{

		}

	}
}
