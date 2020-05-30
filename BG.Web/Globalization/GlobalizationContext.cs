using System;
using System.Globalization;

namespace BG.Web.Globalization
{
	/// <summary>
	/// Globalization context manager.
	/// </summary>
	public class GlobalizationContext
	{
		public const string DefaultRegionCultureName = "ru-RU";  //"en-US";
        public const string DefaultLanguageCultureName = "ru-RU";  //"en-US";
        public const string DefaultTimeZoneId = "UTC";

		public const string LanguageCultureCookieName = "_BGLanguageCulture";
		public const string RegionCultureCookieName = "_suburRegionCulture";
		public const string TimeZoneIdCookieName = "_BGTimeZoneId";

		/// <summary>
		/// Gets the language culture (for resource translations).
		/// </summary>
		public CultureInfo LanguageCulture { get; private set; }

		/// <summary>
		/// Gets the region culture (for date, time and number formats).
		/// </summary>
		public CultureInfo RegionCulture { get; private set; }

		/// <summary>
		/// Gets the time zone.
		/// </summary>
		public TimeZoneInfo TimeZoneInfo { get; private set; }

		/// <summary>
		/// Gets the current region culture default time format mode.
		/// </summary>
		public bool Is24HoursTimeFormat => RegionCulture.DateTimeFormat.ShortTimePattern.Contains("H");

		/// <summary>
		/// Contructor method.
		/// </summary>
		public GlobalizationContext(CultureInfo regionCulture, CultureInfo languageCulture, TimeZoneInfo timeZoneInfo)
		{
			RegionCulture = regionCulture ?? CultureInfo.GetCultureInfo(DefaultRegionCultureName);
			LanguageCulture = languageCulture ?? CultureInfo.GetCultureInfo(DefaultLanguageCultureName);
			TimeZoneInfo = timeZoneInfo ?? TimeZoneInfo.FindSystemTimeZoneById(DefaultTimeZoneId);
		}

		/// <summary>
		/// Gets the specified date converted to the requesting user timezone.
		/// </summary>
		public DateTimeOffset GetLocalDateTime(DateTime date)
		{
			return TimeZoneInfo.ConvertTime(date, TimeZoneInfo);
		}

		/// <summary>
		/// Gets the specified date converted to the requesting user timezone.
		/// </summary>
		public DateTimeOffset GetLocalDateTime(DateTimeOffset date)
		{
			return TimeZoneInfo.ConvertTime(date, TimeZoneInfo);
		}
	}
}
