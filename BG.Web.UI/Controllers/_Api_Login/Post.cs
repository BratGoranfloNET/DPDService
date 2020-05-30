using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BG.Web.UI.Models;
using BG.Core;
using BG.Core.Entities;
using Omu.ValueInjecter;
using BG.Web.UI.ViewModels;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using BG.Core.Resources;
using System.Threading.Tasks;
using BG.Web.UI.Extensions;
using System.Net.Http;



namespace BG.Web.UI.ApiControllers
{

    public class LoginData
    {
        public string username { get; set; }
        public string password { get; set; }
    }

    public partial class LoginController
    {



        [HttpPost]
        [Route("", Name = "LoginPostApi")]
        public LoginJsonModel Post(LoginData login)
        {
            bool RememberMe = true;
            LoginJsonModel view_model = new LoginJsonModel();

            if (login != null)
            {

                var result = _signInManager.PasswordSignIn(
                    login.username,
                    login.password,
                    RememberMe,
                    shouldLockout: false
                );

                switch (result)
                {
                    case SignInStatus.Success:
                        {
                            view_model.Token = TokenGenerator.Generate(10);
                            view_model.ExpiredTime = DateTime.UtcNow.AddYears(1).ToShortDateString();

                            return view_model;
                        }
                    case SignInStatus.Failure:
                        {
                            view_model.Token = "0000000000";
                            view_model.ExpiredTime = "01.01.2000";

                            return view_model;
                        }
                }

            }
            else
            {
                view_model.Token = "0000000000";
                view_model.ExpiredTime = "01.01.2000";
               
            }

            return view_model;
        }
    }

}