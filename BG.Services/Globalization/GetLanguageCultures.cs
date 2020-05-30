using System.Collections.Generic;
using System.Globalization;

namespace BG.Services.Globalization
{
	/// <summary>
	/// Partial globalization services implementation.
	/// </summary>
	public partial class GlobalizationServices
	{
		/// <summary>
		/// Get supported language cultures (for content translation).
		/// </summary>
		public List<CultureInfo> GetLanguageCultures()
		{
            // return new List<CultureInfo>() { CultureInfo.GetCultureInfo("en-US") };

            return new List<CultureInfo>() { CultureInfo.GetCultureInfo("ru-RU") };
        }
	}
}
