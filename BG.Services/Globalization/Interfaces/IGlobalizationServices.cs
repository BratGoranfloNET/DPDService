using System;
using System.Collections.Generic;
using System.Globalization;

namespace BG.Services.Globalization
{
	/// <summary>
	/// Globalization services interface.
	/// </summary>
	public interface IGlobalizationServices
	{
		/// <summary>
		/// Get supported region cultures (for date, time and numer formats).
		/// </summary>
		List<CultureInfo> GetRegionCultures();

		/// <summary>
		/// Get supported language cultures (for content translation).
		/// </summary>
		List<CultureInfo> GetLanguageCultures();

		/// <summary>
		/// Get supported time zones.
		/// </summary>
		List<TimeZoneInfo> GetTimeZones();
	}
}
