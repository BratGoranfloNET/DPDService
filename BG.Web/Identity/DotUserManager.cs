using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using BG.Core.Entities;
using BG.Services.Email;

namespace BG.Web.Identity
{
	/// <summary>
	/// Custom ASP.Net identity user manager.
	/// </summary>
	public class DotUserManager : UserManager<DotUser, int>
	{
		/// <summary>
		/// Gets the realm where this instance is running.
		/// </summary>
		public Realm Realm { get; set; }

		/// <summary>
		/// Constructor method.
		/// </summary>
		public DotUserManager(DotUserStore userStore, IEmailService emailService, IDataProtectionProvider dataProtectionProvider) : base(userStore)
		{
			// Username
			UserValidator = new UserValidator<DotUser, int>(this)
			{
				AllowOnlyAlphanumericUserNames = false,
				RequireUniqueEmail = false
			};

			// Passwords
			PasswordValidator = new PasswordValidator
			{
				RequiredLength = User.PasswordMinLength,
				RequireDigit = false,
				RequireLowercase = false,
				RequireUppercase = false,
				RequireNonLetterOrDigit = false
			};

			EmailService = new IdentityEmailService(emailService);

			if (dataProtectionProvider != null)
				UserTokenProvider = new DataProtectorTokenProvider<DotUser, int>(dataProtectionProvider.Create(".Net Admin Identity"));
		}
	}
}
