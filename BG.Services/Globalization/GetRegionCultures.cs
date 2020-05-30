using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BG.Services.Globalization
{
	/// <summary>
	/// Partial globalization services implementation.
	/// </summary>
	public partial class GlobalizationServices
	{
		/// <summary>
		/// Get supported region cultures (for date, time and numer formats).
		/// </summary>
		public List<CultureInfo> GetRegionCultures()
		{
			var availableCultures = new List<string>() {
				"en-US",
				"en-GB",
				"en-CA",
				"en-AU",
				"en-AT",
				"en-IN",
				"de-DE",
				"de-AT",
				"tr-TR",
				"pt-BR",
				"pt-PT",
				"hi-IN",
				"fr-FR",
                "ru-RU"
            };

			var regionCultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures).ToList();

			return regionCultures.Where(rc => availableCultures.Any(ac => rc.Name.Equals(ac, System.StringComparison.InvariantCultureIgnoreCase))).ToList();
		}
	}
}
