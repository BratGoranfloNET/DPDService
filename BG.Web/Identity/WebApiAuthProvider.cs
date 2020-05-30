using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.OAuth;
using BG.Core.Entities;
using BG.Core.Resources;
using System.Threading.Tasks;

namespace BG.Web.Identity
{
	/// <summary>
	/// Provide web api bearer tokens.
	/// </summary>
	public class WebApiAuthProvider : OAuthAuthorizationServerProvider
	{
		/// <summary>
		/// Validate the token request and set the corresponding identity.
		/// </summary>
		public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
		{
			var userManager = context.OwinContext.GetUserManager<DotUserManager>();

			var dotUser = await userManager?.FindAsync(context.UserName, context.Password) ?? null;

			if (dotUser != null)
			{
				userManager.Realm = Realm.WebApi;

				var oAuthIdentity = await dotUser.GenerateUserIdentityAsync(userManager);

				context.Validated(oAuthIdentity);

				return;
			}

			context.SetError(
				"invalid_grant",
				WebApiResources.InvalidCredentials
			);
		}

		/// <summary>
		/// Checks if the requesting client application has permission to acquire api access tokens
		/// (Checks if the ClientId from the requesting app is allowed to use the API).
		/// </summary>
		public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
		{
			// Validate access
			// - Currently, all client applications are accepted.
			context.Validated();

			return Task.FromResult<object>(null);
		}
	}
}