using BG.Web.Identity;
using BG.Web.UI.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using Entities = BG.Core.Entities;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial users controller.
	/// </summary>
	public partial class UsersController
	{
		/// <summary>
		/// GET / Register method.
		/// </summary>
		[HttpGet]
		[AllowAnonymous]
		[Route("register", Name = "UserRegisterGet")]
		public ActionResult Register()
		{
			if (Request.IsAuthenticated)
				return GetDefaultRedirectRoute();

			return View(new UserRegisterViewModel());
		}

		/// <summary>
		/// POST / Register method.
		/// </summary>
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		[Route("register", Name = "UserRegisterPost")]
		public async Task<ActionResult> Register(UserRegisterViewModel model)
		{
			if (Request.IsAuthenticated)
				return GetDefaultRedirectRoute();

			if (ModelState.IsValid)
			{
				var user = new DotUser
				{
					Name = model.Name,
					Email = model.Email,
					Realm = Entities.Realm.BG,
					UserName = model.Name, //Entities.User.GenerateUserName(model.Name),
					CurrentCultureId = Globalization.RegionCulture.Name,
					CurrentUICultureId = Globalization.LanguageCulture.Name,
					TimeZoneId = Globalization.TimeZoneInfo.Id
				};

				if (ModelState.IsValid)
				{
					var result = await _userManager.CreateAsync(user, model.Password);

					if (result.Succeeded)
					{
						await _signInManager.SignInAsync(user, isPersistent: true, rememberBrowser: false);

						// Get user data.
						var entity = await _userManager.FindByNameAsync(user.Email);

						// Register account creation.
						_timelineService.RegisterActivity(Entities.Realm.BG, Entities.ActivityType.CreatedItsOwnAccount, entity.Id);

						return RedirectToLocal();
					}

					AddErrors(result);
				}
			}

			return View(model);
		}
	}
}