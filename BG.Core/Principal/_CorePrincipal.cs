using BG.Core.Entities;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace BG.Core.Principal
{
	/// <summary>
	/// Partial platform principal.
	/// </summary>
	public partial class CorePrincipal : IPrincipal
	{
		IPrincipal _principal = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public CorePrincipal(IPrincipal principal)
		{
			_principal = principal;
		}

		/// <summary>
		/// Gets the identity of the current principal.
		/// </summary>
		public IIdentity Identity => _principal?.Identity;

		/// <summary>
		/// Gets the id from user claims.
		/// </summary>
		public int Id => GetClaimValue<int>(ClaimTypes.Id);

		/// <summary>
		/// Gets the realm from user claims.
		/// </summary>
		public Realm Realm => GetClaimValue<Realm>(ClaimTypes.Realm);

		/// <summary>
		/// Gets the name from user claims.
		/// </summary>
		public string Name => GetClaimValue<string>(ClaimTypes.Name);

		/// <summary>
		/// Gets the e-mail from user claims.
		/// </summary>
		public string Email => GetClaimValue<string>(ClaimTypes.Email);

		/// <summary>
		/// Gets the screen locked from user claims.
		/// </summary>
		public bool ScreenLocked => GetClaimValue<bool>(ClaimTypes.ScreenLocked);

		/// <summary>
		/// Gets the screen locked from user claims.
		/// </summary>
		public byte AutoLockScreenInMinutes => GetClaimValue<byte>(ClaimTypes.AutoLockScreenInMinutes);

		/// <summary>
		/// Gets the username from user claims.
		/// </summary>
		public string UserName => GetClaimValue<string>(ClaimTypes.UserName);

		/// <summary>
		/// Gets the image blob id from user claims.
		/// </summary>
		public Guid? ImageBlobId => GetClaimValue<Guid?>(ClaimTypes.ImageBlobId, null);

		/// <summary>
		/// Gets the image blob name from user claims.
		/// </summary>
		public string ImageBlobName => GetClaimValue<string>(ClaimTypes.ImageBlobName, null);

		/// <summary>
		/// Gets the culture info for date, time and number formats.
		/// </summary>
		public string RegionCulture => GetClaimValue(ClaimTypes.RegionCulture, "en-US");

		/// <summary>
		/// Gets the culture info for language translation
		/// </summary>
		public string LanguageCulture => GetClaimValue(ClaimTypes.LanguageCulture, "en-US");

		/// <summary>
		/// Gets the time zone information.
		/// </summary>
		public string TimeZone => GetClaimValue(ClaimTypes.LocalUserTimeZone, "UTC");

		/// <summary>
		/// Determines whether the current principal belongs to the specified role.
		/// </summary>
		public bool IsInRole(string role) => IsInRole(role.ChangeType<Role>());

		/// <summary>
		/// Determines whether the current principal belongs to the specified role.
		/// </summary>
		public bool IsInRole(Role role) => _principal?.IsInRole(role.ToString()) ?? false;

		/// <summary>
		/// Determines whether the current principal belongs to all specified roles
		/// </summary>
		public bool IsInRoleAll(params Role[] roles)
		{
			var roleNames = roles.Select(role => role.ToString());

			foreach (var name in roleNames)
			{
				var isInRole = _principal?.IsInRole(name) ?? false;

				if (!isInRole)
					return false;
			}

			return true;
		}

		/// <summary>
		/// Determines whether the current principal belongs to any of the specified roles.
		/// </summary>
		public bool IsInRoleAny(params Role[] roles)
		{
			var roleNames = roles.Select(role => role.ToString());

			foreach (var name in roleNames)
			{
				var isInRole = _principal?.IsInRole(name) ?? false;

				if (isInRole)
					return true;
			}

			return false;
		}

		/// <summary>
		/// Extract the claim value from current user claims collection.
		/// </summary>
		public T GetClaimValue<T>(string claimType, T defaultValue = default(T))
		{
			var ci = Identity as ClaimsIdentity;

			var claim = ci?.FindFirst(c => c.Type.Equals(claimType, StringComparison.InvariantCultureIgnoreCase)) ?? null;

			if (claim == null || claim.Value == null)
				return defaultValue;

			return claim.Value.ChangeType(defaultValue);
		}
	}
}
