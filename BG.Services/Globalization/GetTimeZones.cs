using System;
using System.Collections.Generic;
using System.Linq;

namespace BG.Services.Globalization
{
	/// <summary>
	/// Partial globalization services implementation.
	/// </summary>
	public partial class GlobalizationServices
	{
		/// <summary>
		/// Get supported time zones.
		/// </summary>
		public List<TimeZoneInfo> GetTimeZones()
		{
			return TimeZoneInfo.GetSystemTimeZones().ToList();
		}
	}
}
