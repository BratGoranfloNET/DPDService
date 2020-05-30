using Microsoft.AspNet.Identity;
using BG.Core.Resources;
using BG.Web.UI.Attributes;
using BG.Web.UI.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.DirectoryServices;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial users controller.
	/// </summary>
	public partial class UsersController
	{
		/// <summary>
		/// GET / Lock screen action.
		/// </summary>
		[HttpGet]
		[LockScreenAllowed]
		[Route("screen/lock", Name = "LockScreenGet")]
		public async Task<ActionResult> LockScreen()
		{
			var dotUser = _userManager.FindById(User.Id);

			dotUser.ScreenLocked = true;

			await RefreshUserClaims(dotUser);

			if (Request.IsAjaxRequest())
				return Json(new { locked = true });

			return View(new LockScreenViewModel());
		}

		/// <summary>
		/// POST / Lock screen action.
		/// </summary>
		[HttpPost]
		[LockScreenAllowed]
		[Route("screen/lock", Name = "LockScreenPost")]
		public async Task<ActionResult> LockScreen(LockScreenViewModel model)
		{
            if (ModelState.IsValid)
            {
                var dotUser = _userManager.FindById(User.Id);

                var isValidPassword = _userManager.CheckPassword(dotUser, model.Password);

                if (isValidPassword)
                {
                    dotUser.ScreenLocked = false;

                    await RefreshUserClaims(dotUser);

                    return GetDefaultRedirectRoute();
                }

                ModelState.AddModelError("Password", UserResources.InvalidPasswordMessage);
            }

            return View(model);
		}
	}
}
