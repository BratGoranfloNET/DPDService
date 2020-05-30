using BG.Web.Globalization;
using System;
using System.Globalization;

namespace BG.Web.Helpers
{
	/// <summary>
	/// Partial @Globalization helper.
	/// </summary>
	public partial class GlobalizationHelper : GlobalizationContext
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public GlobalizationHelper(CultureInfo regionCulture, CultureInfo languageCulture, TimeZoneInfo timeZoneInfo) : base(regionCulture, languageCulture, timeZoneInfo)
		{
		}
	}
}
