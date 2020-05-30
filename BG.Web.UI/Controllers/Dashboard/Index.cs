using BG.Web.UI.Models;
using System.Web.Mvc;
using System.Collections.Generic;
using BG.Core.Entities;
using System;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using BG.Core.Resources;
using System.Threading.Tasks;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Web.Security;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Principal;
using System.Net;
using System.IO;
using BG.Web.Identity;
using Entities = BG.Core.Entities;


namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial dashboard controller.
	/// </summary>
	public partial class DashboardController
	{
		/// <summary>
		/// GET / Index action.
		/// </summary>
		[HttpGet]
		[Route(Name = "DashboardIndexGet")]
		//public ActionResult Index(string period1, string period2, string consignor1)
        public  async Task<ActionResult> Index(string period1, string period2, string consignor1)
        {
            var isAuth = Request.IsAuthenticated;
            var winUser = System.Web.HttpContext.Current.User.Identity.Name;

            //var user1 = _userManager.FindByNameAsync(winUser);

            //var cont = System.Web.HttpContext.Current.GetOwinContext().Request.User.Identity.Name;// .Authentication;

            var userCurrent = _usersRepository.GetByUserName(winUser);

            string newUserDisplayName = "";
            string newUserEmail = "";

            if (userCurrent == null)
            {

                DirectoryEntry root = new DirectoryEntry("LDAP://dc=BG,dc=local");

                DirectorySearcher srch = new DirectorySearcher(root);
                srch.Filter = "(objectCategory=Person)";
                srch.SearchScope = System.DirectoryServices.SearchScope.Subtree;
                srch.SearchRoot.AuthenticationType = AuthenticationTypes.Secure;
                srch.PageSize = 100000;

                // define properties to load
                srch.PropertiesToLoad.Add("objectSid");
                srch.PropertiesToLoad.Add("displayName");
                srch.PropertiesToLoad.Add("userPrincipalName");
                srch.PropertiesToLoad.Add("mail");
                srch.PropertiesToLoad.Add("msDS-PrincipalName");
                               

                int ccc = srch.FindAll().Count;

                // search the directory
                foreach (SearchResult result1 in srch.FindAll())
                {
                    //// grab the data - if present
                    //if (result1.Properties["objectSid"] != null && result1.Properties["objectSid"].Count > 1)
                    //{
                    //    var sid = result1.Properties["objectSid"][0];
                    //}
                    
                    if (result1.Properties["msDS-PrincipalName"] != null && result1.Properties["msDS-PrincipalName"].Count > 0)
                    {
                        var winName = result1.Properties["msDS-PrincipalName"][0].ToString();

                        if (winName.Contains(winUser))
                        {                            
                            if (result1.Properties["displayName"] != null && result1.Properties["displayName"].Count > 0)
                            {
                                newUserDisplayName = result1.Properties["displayName"][0].ToString();
                            }

                            if (result1.Properties["mail"] != null && result1.Properties["mail"].Count > 0)
                            {
                                newUserEmail = result1.Properties["mail"][0].ToString();
                            }

                        }

                    }

                }



                //release resources
                srch.Dispose();
                root.Dispose();
            }
                       

            var newuser = new DotUser
                {
                    Name = newUserDisplayName,
                    Email = newUserEmail,
                    Realm = Entities.Realm.BG,
                    UserName = winUser, //AD_userName, //Entities.User.GenerateUserName(model.Name),
                    CurrentCultureId = "ru-RU", //Globalization.RegionCulture.Name,
                    CurrentUICultureId = "ru-RU",//Globalization.LanguageCulture.Name,
                    TimeZoneId = Globalization.TimeZoneInfo.Id
                };

                
                var newresult = await _userManager.CreateAsync(newuser, "password");

                if (newresult.Succeeded)
                {
                    await _signInManager.SignInAsync(newuser, isPersistent: true, rememberBrowser: false);
                    var entity = await _userManager.FindByNameAsync(newuser.UserName);
                    return RedirectToLocal();
            }

               
            //}            


            var result =  _signInManager.PasswordSignIn(
                    winUser,
                    "password",
                    true,
                    shouldLockout: false
                );

                switch (result)
                {
                    case SignInStatus.Success:
                        {
                            // Get user data.

                            var user =  _userManager.FindByNameAsync(winUser);

                            // Update globalization data.
                            // ConfigureGlobalizationContext(HttpContext, user.CurrentCultureId, user.CurrentUICultureId, user.TimeZoneId);
                            // return RedirectToLocal(returnUrl);

                        break;
                    }

                    case SignInStatus.Failure:
                    {
                        ModelState.AddModelError("credentials", UserResources.InvalidCredentials);
                        break;
                    }
                }
            



            var model = new DashboardIndexViewModel();
            
            IEnumerable<StateUnited>  statesAll = _stateunitedRepository.GetAll();

            int diccount = 1;
            Dictionary<int, string> Cons = new Dictionary<int, string>();
            Cons.Add(diccount, "ВСЕ");

            List<ConsignorsViewModel> consignors = new List<ConsignorsViewModel>();
            ConsignorsViewModel con1 = new ConsignorsViewModel
            { Id = diccount, Name = "ВСЕ" };
            consignors.Add(con1);

            foreach (StateUnited st in statesAll)
            {
                if (Cons.ContainsValue(st.Consignor))
                {

                }
                else
                {
                    diccount++;
                    Cons.Add(diccount, st.Consignor);


                    ConsignorsViewModel con2 = new ConsignorsViewModel
                    { Id = diccount, Name = st.Consignor };
                                       
                    consignors.Add(con2);

                }
            }
            


            
            model.Consignors = new SelectList(
                 consignors
               , "Name"  // , "Id"
               , "Name"
           );


            

            if (period1 == null || period2 == null || consignor1 == null)
            {              

                ViewBag.PeriodTitle = "Всё время";
                    

                model.StartDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);               
                model.EndDate = DateTime.Now;
                
            }
            else
            {

                //
                DateTime startDate = DateTime.Parse(period1);
                DateTime endDate = DateTime.Parse(period2);

              

                statesAll = statesAll.Where(x => x.UTCCreation.Date >= startDate.Date && x.UTCCreation.Date <= endDate.Date);

                ViewBag.PeriodTitle = "С " + period1 + " ПО " + period2;

                if ( consignor1 != "ВСЕ")
                {
                    if (consignor1 == "")
                    {
                        statesAll = statesAll.Where(x => x.Consignor == null);
                    }
                    else
                    {
                        statesAll = statesAll.Where(x => x.Consignor == consignor1);
                    }

                   


                    ViewBag.PeriodTitle = "С " + period1 + " ПО " + period2 + " " + consignor1;

                }



                model.StartDate = startDate;
                model.EndDate = endDate;
                model.Consignors = new SelectList(
                 consignors
               , "Name"  // , "Id"
               , "Name",
                 consignor1
           );

                

            }
            

            IEnumerable<StateUnited> statesOnRoad = statesAll.Where(x => x.newState == "OnRoad");
            IEnumerable<StateUnited> statesDelivering = statesAll.Where(x => x.newState == "Delivering");
            IEnumerable<StateUnited> statesOnTerminal = statesAll.Where(x => x.newState == "OnTerminal");
            IEnumerable<StateUnited> statesOnTerminalPickup = statesAll.Where(x => x.newState == "OnTerminalPickup");
            IEnumerable<StateUnited> statesOnTerminalDelivery = statesAll.Where(x => x.newState == "OnTerminalDelivery");
            IEnumerable<StateUnited> statesReturnedFromDelivery = statesAll.Where(x => x.newState == "ReturnedFromDelivery");
            IEnumerable<StateUnited> statesDelivered = statesAll.Where(x => x.newState == "Delivered");

            IEnumerable<StateUnited> statesProblem = statesAll.Where(x => x.newState == "Problem");



           int OthersCount = statesAll.Count() - statesOnRoad.Count()
                                   - statesDelivering.Count() - statesOnTerminal.Count()
                                   - statesOnTerminalPickup.Count() - statesOnTerminalDelivery.Count()
                                   - statesReturnedFromDelivery.Count() - statesDelivered.Count()
                                   - statesProblem.Count();






            double PercentOnRoad = 0;
            double PercentDelivering = 0;
            double PercentOnTerminal = 0;
            double PercentOnTerminalPickup = 0;
            double PercentOnTerminalDelivery = 0;
            double PercentReturnedFromDelivery = 0;
            double PercentDelivered = 0;
            double PercentProblem = 0;
            double PercentOthersCount = 0;

            if (statesAll.Count() != 0 ) {
                PercentOnRoad = statesOnRoad.Count() * 100 / statesAll.Count();
                PercentDelivering = statesDelivering.Count() * 100 / statesAll.Count();
                PercentOnTerminal = statesOnTerminal.Count() * 100 / statesAll.Count();
                PercentOnTerminalPickup = statesOnTerminalPickup.Count() * 100 / statesAll.Count();
                PercentOnTerminalDelivery = statesOnTerminalDelivery.Count() * 100 / statesAll.Count();
                PercentReturnedFromDelivery = statesReturnedFromDelivery.Count() * 100 / statesAll.Count();
                PercentDelivered = statesDelivered.Count() * 100 / statesAll.Count();
                PercentProblem = statesProblem.Count() * 100 / statesAll.Count();
                PercentOthersCount = OthersCount * 100 / statesAll.Count();
            }

            ViewBag.StatesAllCount = statesAll.Count();

            ViewBag.StatesOnRoadCount = statesOnRoad.Count();
            ViewBag.StatesDeliveringCount = statesDelivering.Count();
            ViewBag.StatesOnTerminalCount = statesOnTerminal.Count();
            ViewBag.StatesOnTerminalPickupCount = statesOnTerminalPickup.Count();
            ViewBag.StatesOnTerminalDeliveryCount = statesOnTerminalDelivery.Count();
            ViewBag.StatesReturnedFromDeliveryCount = statesReturnedFromDelivery.Count();
            ViewBag.StatesDeliveredCount = statesDelivered.Count();
            ViewBag.StatesProblemCount = statesProblem.Count();


            ViewBag.OthersCount = OthersCount;

            ViewBag.PercentOnRoad = PercentOnRoad;
            ViewBag.PercentDelivering = PercentDelivering;
            ViewBag.PercentOnTerminal = PercentOnTerminal;

            ViewBag.PercentOnTerminalPickup = PercentOnTerminalPickup;
            ViewBag.PercentOnTerminalDelivery = PercentOnTerminalDelivery;
            ViewBag.PercentReturnedFromDelivery = PercentReturnedFromDelivery;
            ViewBag.PercentDelivered = PercentDelivered;
            ViewBag.PercentProblem = PercentProblem;
            ViewBag.PercentOthersCount = PercentOthersCount;

            ViewBag.PercentOther = 100
                - PercentDelivered
                - PercentOnRoad
                - PercentDelivering;
            //- PercentOnTerminal
            //- PercentOnTerminalPickup
            //- PercentOnTerminalDelivery
            //- PercentReturnedFromDelivery;



            return View(model);
            

		}


        public RedirectToRouteResult GetDefaultRedirectRoute() => RedirectToAction(nameof(HomeController.Index), nameof(HomeController).RemoveControllerSuffix());

        [NonAction]
        private ActionResult RedirectToLocal(string returnUrl = null)
        {
            if (Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return GetDefaultRedirectRoute();
        }




    }
}