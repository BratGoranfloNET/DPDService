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
		/// Top user box information.
		/// </summary>
		[AllowAnonymous]
		[ChildActionOnly]
		[Route("box", Name = "UserBox")]
		public ActionResult Box()
		{
			var model = new UserBoxViewModel();

			return PartialView(model);
		}
	}
}