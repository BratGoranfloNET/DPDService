using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security.OAuth;
using BG.Core.Entities;
using BG.Core.Principal;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BG.Web.Identity
{
	/// <summary>
	/// ASP.Net identity user.
	/// </summary>
	public class DotUser : User, IUser<int>
	{
		/// <summary>
		/// Generate a claims identiy .
		/// </summary>
		public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<DotUser, int> manager)
		{
			var dotUserManager = manager as DotUserManager;

			var authenticationType = DefaultAuthenticationTypes.ApplicationCookie;

			if (dotUserManager.Realm == Realm.WebApi)
				authenticationType = OAuthDefaults.AuthenticationType;

			var userIdentity = await manager.CreateIdentityAsync(
				this,
				authenticationType
			);

			// Claims automatically added during signin process:
			// -------------------------------------------
			// - Id
			// - UserName
			// - Roles (UserRoles table)
			// - Specific claims (UserClaims table)
			// -------------------------------------------

			// Add here any common required claims
			userIdentity.AddClaim(new Claim(CorePrincipal.ClaimTypes.Name, Name));
			userIdentity.AddClaim(new Claim(CorePrincipal.ClaimTypes.Email, Email));
			userIdentity.AddClaim(new Claim(CorePrincipal.ClaimTypes.ScreenLocked, ScreenLocked.ChangeType(string.Empty)));
			userIdentity.AddClaim(new Claim(CorePrincipal.ClaimTypes.AutoLockScreenInMinutes, AutoLockScreenInMinutes.ChangeType(string.Empty)));
			userIdentity.AddClaim(new Claim(CorePrincipal.ClaimTypes.ImageBlobId, ImageBlobId.ChangeType(string.Empty)));
			userIdentity.AddClaim(new Claim(CorePrincipal.ClaimTypes.ImageBlobName, ImageBlob?.Name ?? string.Empty));

			userIdentity.AddClaim(new Claim(CorePrincipal.ClaimTypes.RegionCulture, CurrentCultureId));
			userIdentity.AddClaim(new Claim(CorePrincipal.ClaimTypes.LanguageCulture, CurrentUICultureId));
			userIdentity.AddClaim(new Claim(CorePrincipal.ClaimTypes.LocalUserTimeZone, TimeZoneId));

			userIdentity.AddClaim(new Claim(CorePrincipal.ClaimTypes.Realm, (Realm.ChangeType<int>()).ToString()));

			return userIdentity;
		}
	}
}
