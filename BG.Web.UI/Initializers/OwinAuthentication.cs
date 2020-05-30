using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using BG.Core.Entities;
using BG.Web.Configs;
using BG.Web.Identity;
using SimpleInjector;
using System;

namespace BG.Web.UI
{
	/// <summary>
	/// Owin initializer partial class.
	/// </summary>
	public partial class Initializer
	{
		/// <summary>
		/// Initialize oauth identity.
		/// </summary>
		private void ConfigureOwinAuthentication(WebUIConfigs uiConfigs, IAppBuilder appBuilder, Container container)
		{

            // HttpListener listener = (HttpListener)app.Properties["System.Net.HttpListener"];
            // listener.AuthenticationSchemes = AuthenticationSchemes.IntegratedWindowsAuthentication;


            appBuilder.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                CookieName = uiConfigs.Auth.CookieName,
                //LoginPath = new PathString(uiConfigs.Auth.LoginPath),
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,

                Provider = new CookieAuthenticationProvider
                {
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<DotUserManager, DotUser, int>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentityCallback: (manager, user) =>
                        {

                            manager.Realm = Realm.BG;

                            return user.GenerateUserIdentityAsync(manager);

                        },
                        getUserIdCallback: (user) => user.GetUserId<int>()
                    )
                },

                SlidingExpiration = true,
                ExpireTimeSpan = TimeSpan.FromDays(180),


            });



        }
	}
}
