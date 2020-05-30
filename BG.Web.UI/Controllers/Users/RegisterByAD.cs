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
		[Route("registerbyad", Name = "UserRegisterByADGet")]
        public async Task<ActionResult> RegisterByAD( string AD_userName)
		{
            if (Request.IsAuthenticated)
                return GetDefaultRedirectRoute();


                var user = new DotUser
                {
                Name  = AD_userName,
                Email = AD_userName + "@_",
                Realm = Entities.Realm.BG,
                UserName = AD_userName, //AD_userName, //Entities.User.GenerateUserName(model.Name),
                CurrentCultureId =  "ru-RU", //Globalization.RegionCulture.Name,
                CurrentUICultureId = "ru-RU",//Globalization.LanguageCulture.Name,
                TimeZoneId = Globalization.TimeZoneInfo.Id
                };

                
                    var result = await _userManager.CreateAsync(user, "password");

                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: true, rememberBrowser: false);

                    // Get user data.
                    //var entity = await _userManager.FindByNameAsync(user.Email);
                    var entity = await _userManager.FindByNameAsync(user.UserName);


                // Register account creation.
                _timelineService.RegisterActivity(Entities.Realm.BG, Entities.ActivityType.CreatedItsOwnAccount, entity.Id);

                        return RedirectToLocal();
                    }

                    AddErrors(result);



            //return View();
            return RedirectToLocal();
        }
    }



        
    
}