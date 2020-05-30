using Microsoft.AspNet.Identity.Owin;
using BG.Core.Resources;
using BG.Web.UI.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.Protocols;
using System.Web.Security;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Security.Principal;
using System.Net;
using System.Web;
using System.IO;
using System;
using Microsoft.AspNet.Identity;
using BG.Web.UI.Attributes;


namespace BG.Web.UI.Controllers
{


    public class KerberosToken
    {
        public KerberosReceiverSecurityToken GenerateReceiver()
        {
            KerberosReceiverSecurityToken receiverToken = null;
            //string SPN1 = "HTTP/s001nd-sp-api1.BG.local BG\a001-dpdservice";
            string SPN = "HTTP/s001nd-sp-api1.BG.local";//  garage\dpd_service";

            var currUserName = HttpContext.Current.User.Identity.Name;

            var WindowsAccountName = HttpContext.Current.Request.LogonUserIdentity.Name;

            //KerberosSecurityTokenProvider provider1 =
            //             new KerberosSecurityTokenProvider(SPN,
            //             TokenImpersonationLevel.Impersonation,
            //             new NetworkCredential("dpd_service", "123", "Garage"));

            //KerberosSecurityTokenProvider provider2 =
            //              new KerberosSecurityTokenProvider(SPN,
            //              TokenImpersonationLevel.Impersonation,
            //              CredentialCache.DefaultNetworkCredentials);


            KerberosSecurityTokenProvider provider3 =
                          new KerberosSecurityTokenProvider(SPN,
                          TokenImpersonationLevel.Impersonation);


            //KerberosSecurityTokenProvider provider4 =
            //               new KerberosSecurityTokenProvider(SPN);


            try
            {

                KerberosRequestorSecurityToken requestorToken = provider3.GetToken(TimeSpan.FromMinutes(180)) as KerberosRequestorSecurityToken;
                var abRequest = requestorToken.GetRequest();
                var sId = requestorToken.Id;
                KerberosReceiverSecurityToken oReceivedToken = new KerberosReceiverSecurityToken(abRequest, sId);

              

                using (FileStream fstream = new FileStream(@"C:\DPD500LOG\good_note.txt", FileMode.OpenOrCreate))
                {
                    // var oAuthenticator = new KerberosSecurityTokenAuthenticator();
                    // var oCol = oAuthenticator.ValidateToken(oReceivedToken);
                    //    foreach (var o in oCol)
                    //    {
                    //        Console.WriteLine(o.Id);
                    //    }

                    // преобразуем строку в байты
                    byte[] array = System.Text.Encoding.Default.GetBytes(oReceivedToken.Id);// exception.ToString());
                    // запись массива байтов в файл
                    fstream.Write(array, 0, array.Length);
                }


            }
            catch(Exception ex)
            {

                Console.WriteLine(ex.Message);

                using (FileStream fstream = new FileStream(@"C:\DPD500LOG\error_note.txt", FileMode.OpenOrCreate))
                {
                    // преобразуем строку в байты
                    byte[] array = System.Text.Encoding.Default.GetBytes(ex.Message);// exception.ToString());
                    // запись массива байтов в файл
                    fstream.Write(array, 0, array.Length);
                }

            }

            return receiverToken;
        }


        }







        /// <summary>
        /// Partial users controller.
        /// </summary>
        public partial class UsersController
	{
        [HttpGet]
        [AllowAnonymous]
        [Route("winlogin", Name = "UserLoginWinGet")]
        public ActionResult WinLogin()
        {
            JsonResult result = new JsonResult();

            // Loading drop down lists.
         

            return result =  this.Json(new { ok = "ok"  }, JsonRequestBehavior.AllowGet);

        }



        /// <summary>
        /// GET / Login method.
        /// </summary>
        [HttpGet]
		[AllowAnonymous]
		[Route("login", Name = "UserLoginGet")]
		public ActionResult Login(string returnUrl)        
        {            

            //try
            //{
            //    KerberosToken KT = new KerberosToken();
            //    var receiver = KT.GenerateReceiver();
            //}
            //catch (Exception ex)
            //{
            //    using (FileStream fstream = new FileStream(@"C:\DPD500LOG\error1_note.txt", FileMode.OpenOrCreate))
            //    {
            //        // преобразуем строку в байты
            //        byte[] array = System.Text.Encoding.Default.GetBytes(ex.Message);// exception.ToString());
            //        // запись массива байтов в файл
            //        fstream.Write(array, 0, array.Length);
            //    }
            //}
                                   

          //  var currUserName = System.Web.HttpContext.Current.User.Identity.Name;
          //  var WindowsAccountName = System.Web.HttpContext.Current.Request.LogonUserIdentity.Name;
            
           // if (Request.IsAuthenticated)
			//	return GetDefaultRedirectRoute();

			ViewBag.ReturnUrl = returnUrl;

			return View(new UserLoginViewModel());

		}

		/// <summary>
		/// POST / Login method.
		/// </summary>
		[HttpPost]
		[AllowAnonymous]
		[ValidateAntiForgeryToken]
		[Route("login", Name = "UserLoginPost")]
		public async Task<ActionResult> Login(UserLoginViewModel model, string returnUrl)
		{

            //  var currUserName = System.Web.HttpContext.Current.User.Identity.Name;
            //  var WindowsAccountName = System.Web.HttpContext.Current.Request.LogonUserIdentity.Name;



            //try
            //{
            //    KerberosToken KT = new KerberosToken();
            //    var receiver = KT.GenerateReceiver();
            //}
            //catch(Exception ex)
            //{
            //    using (FileStream fstream = new FileStream(@"C:\DPD500LOG\error1_note.txt", FileMode.OpenOrCreate))
            //    {
            //        // преобразуем строку в байты
            //        byte[] array = System.Text.Encoding.Default.GetBytes(ex.Message);// exception.ToString());
            //        // запись массива байтов в файл
            //        fstream.Write(array, 0, array.Length);
            //    }

            //}


            ////////!!! if (Request.IsAuthenticated)
            //////!!!    return GetDefaultRedirectRoute();

            //  var currContext = System.Web.HttpContext.Current;

            //bool isAuth =
            //    System.Web.HttpContext.Current != null &&
            //    System.Web.HttpContext.Current.Request != null &&
            //    System.Web.HttpContext.Current.Application != null &&
            //    System.Web.HttpContext.Current.Session != null &&
            //    System.Web.HttpContext.Current.Request.IsAuthenticated ;
            // ProprietaryAuthenticationFunction(System.Web.HttpContext.Current.Application, 
            // System.Web.HttpContext.Current.Session);

            _authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);


            if (ModelState.IsValid)
            {
                string emailOrUsername = model.EmailOrUsername;

                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(
                        emailOrUsername,
                        model.Password,
                        model.RememberMe,
                        shouldLockout: false
                    );

                    switch (result)
                    {
                        case SignInStatus.Success:
                            {
                                // Get user data.
                                var user = await _userManager.FindByNameAsync(model.EmailOrUsername);

                                // Update globalization data.
                                ConfigureGlobalizationContext(HttpContext, user.CurrentCultureId, user.CurrentUICultureId, user.TimeZoneId);

                                // return RedirectToLocal(returnUrl);

                                return RedirectToAction("Users", nameof(PlatformController).RemoveControllerSuffix());

                            }

                        case SignInStatus.Failure:
                            ModelState.AddModelError("credentials", UserResources.InvalidCredentials);
                            break;
                    }
                }
            }

            return View(model);



        }
	}
}