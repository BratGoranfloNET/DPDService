using System;
using System.Collections.Generic;

namespace BG.Core.Entities
{
	/// <summary>
	/// Represents an user entity.
	/// </summary>
	public class User : IEntity
	{
		public const int EmailMaxLength = 255;
		public const int NameMaxLength = 175;
		public const int PasswordMinLength = 6;
		public const int UsernameMaxLength = 255;
		public const int StatusMessageMaxLength = 140;
		public const byte AutoLockScreenMaxMinutes = 60;

		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the deleted status.
		/// </summary>
		public bool IsDeleted { get; set; }

		/// <summary>
		/// Gets or sets the creation date (UTC).
		/// </summary>
		public DateTime UTCCreation { get; set; }

		/// <summary>
		/// Gets or set the confirmed e-mail status.
		/// </summary>
		public bool EmailConfirmed { get; set; }

		/// <summary>
		/// Gets or sets the lockout enabled status.
		/// </summary>
		public bool LockoutEnabled { get; set; }

		/// <summary>
		/// Gets or sets the two factor authentication enabled status.
		/// </summary>
		public bool TwoFactorEnabled { get; set; }

		/// <summary>
		/// Gets or sets the mobile phone confirmed status.
		/// </summary>
		public bool MobilePhoneConfirmed { get; set; }

		/// <summary>
		/// Gets or sets the lockout end date (UTC).
		/// </summary>
		public DateTime? LockoutEndDateUtc { get; set; }

		/// <summary>
		/// Gets or sets the access failed attempts count.
		/// </summary>
		public int AccessFailedCount { get; set; }

		/// <summary>
		/// Gets or sets the password hash.
		/// </summary>
		public string PasswordHash { get; set; }

		/// <summary>
		/// Gets or sets the security stamp.
		/// </summary>
		public string SecurityStamp { get; set; }

		/// <summary>
		/// Gets or sets the user name.
		/// </summary>
		public string UserName { get; set; }

		/// <summary>
		/// Gets or sets the e-mail.
		/// </summary>
		public string Email { get; set; }

		/// <summary>
		/// Gets or sets the realm where the user was created.
		/// </summary>
		public Realm Realm { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the gender.
		/// </summary>
		public Gender Gender { get; set; }

		/// <summary>
		/// Gets or sets the image blob id.
		/// </summary>
		public Guid? ImageBlobId { get; set; }

		/// <summary>
		/// Gets or sets the image blob instance.
		/// </summary>
		public Blob ImageBlob { get; set; }

		/// <summary>
		/// Gets or sets the mobile phone number.
		/// </summary>
		public string MobilePhone { get; set; }

		/// <summary>
		/// Gets or sets the biography information.
		/// </summary>
		public string Biography { get; set; }

		/// <summary>
		/// Gets or set the github profile link.
		/// </summary>
		public string GitHubLink { get; set; }

		/// <summary>
		/// Gets or set the twitter profile link.
		/// </summary>
		public string TwitterLink { get; set; }

		/// <summary>
		/// Gets or set the linked in profile link.
		/// </summary>
		public string LinkedInLink { get; set; }

		/// <summary>
		/// Gets or set the facebook profile link.
		/// </summary>
		public string FacebookLink { get; set; }

		/// <summary>
		/// Gets or set the instagram profile link.
		/// </summary>
		public string InstagramLink { get; set; }

		/// <summary>
		/// Gets or sets the current culture name.
		/// </summary>
		public string CurrentCultureId { get; set; }

		/// <summary>
		/// Gets or sets the current UI culture name.
		/// </summary>
		public string CurrentUICultureId { get; set; }

		/// <summary>
		/// Gets or sets the time zone id (e.g UTC).
		/// </summary>
		public string TimeZoneId { get; set; }

		/// <summary>
		/// Gets or sets the screen locked state.
		/// </summary>
		public bool ScreenLocked { get; set; }

		/// <summary>
		/// Gets or sets the number of minutes before auto locking the screen.
		/// </summary>
		public byte AutoLockScreenInMinutes { get; set; }

		/// <summary>
		/// Gets or sets the current profile status message.
		/// </summary>
		public string StatusMessage { get; set; }

		/// <summary>
		/// Gets or sets the user related claims.
		/// </summary>
		public List<UserClaim> Claims { get; set; } = new List<UserClaim>();

		/// <summary>
		/// Gets or sets the roles that the user belongs to.
		/// </summary>
		public List<UserRole> Roles { get; set; } = new List<UserRole>();

		/// <summary>
		/// Generate an unique username based on the input data.
		/// </summary>
		public static string GenerateUserName(string input)
		{
			int suffix = (new Random()).Next(
				100,
				1000
			);

			var suffixString = suffix.ToString();

			input = input.NormalizeAccentuation();
			input = input.FilterSpecialChars(replacer: string.Empty);

			return string.Concat(input.Truncate(UsernameMaxLength - suffixString.Length, string.Empty), suffixString);
		}
	}
}
