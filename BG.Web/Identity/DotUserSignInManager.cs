using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BG.Web.Identity
{
	/// <summary>
	/// Custom ASP.Net identity sign in manager.
	/// </summary>
	public class DotUserSignInManager : SignInManager<DotUser, int>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public DotUserSignInManager(DotUserManager userManager, IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
		{
		}

		/// <summary>
		/// Callback for creating a new identity during the signin process.
		/// </summary>
		public override Task<ClaimsIdentity> CreateUserIdentityAsync(DotUser user)
		{
			return user.GenerateUserIdentityAsync(UserManager);
		}
	}
}
