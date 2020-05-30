namespace BG.Core.Principal
{
	/// <summary>
	/// Partial platform principal.
	/// </summary>
	public partial class CorePrincipal
	{
		/// <summary>
		/// Represents the set of claim types recognized by the platform.
		/// </summary>
		public struct ClaimTypes
		{
			/// <summary>
			/// User id.
			/// </summary>
			public const string Id = System.Security.Claims.ClaimTypes.NameIdentifier;

			/// <summary>
			/// Full Name.
			/// </summary>
			public const string Name = "dot.full.name";

			/// <summary>
			/// Primary e-mail.
			/// </summary>
			public const string Email = System.Security.Claims.ClaimTypes.Email;

			/// <summary>
			/// Realm where the user was created.
			/// </summary>
			public const string Realm = "dot.realm.id";

			/// <summary>
			/// Screen locked status.
			/// </summary>
			public const string ScreenLocked = "dot.scr.lck";

			/// <summary>
			/// How many minutes before the screen shoul be locked.
			/// </summary>
			public const string AutoLockScreenInMinutes = "dot.scr.at.lck.mins";

			/// <summary>
			/// User name.
			/// </summary>
			public const string UserName = System.Security.Claims.ClaimTypes.Name;

			/// <summary>
			/// Image blob id.
			/// </summary>
			public const string ImageBlobId = "dot.blob.id";

			/// <summary>
			/// Image blob name.
			/// </summary>
			public const string ImageBlobName = "dot.blob.name";

			/// <summary>
			/// Region culture (Date, time an number formats).
			/// </summary>
			public const string RegionCulture = "dot.culture";

			/// <summary>
			/// Language culture (Text translation).
			/// </summary>
			public const string LanguageCulture = "dot.culture.ui";

			/// <summary>
			/// Time zone.
			/// </summary>
			public const string LocalUserTimeZone = "dot.timezone";
		}
	}
}
