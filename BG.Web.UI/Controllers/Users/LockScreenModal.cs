using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial users controller.
	/// </summary>
	public partial class UsersController
	{
		/// <summary>
		/// GET / Lock screen modal action.
		/// <para>Renders the lock screen modal HTML contents.</para>
		/// </summary>
		[ChildActionOnly]
		[Route("screen/lock-modal", Name = "LockScreenModal")]
		public ActionResult LockScreenModal()
		{
			var model = new LockScreenViewModel();

			return PartialView(model);
		}
	}
}
