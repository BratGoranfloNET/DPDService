using BG.Services.Globalization;
using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle extensions.
	/// </summary>
	public static class BundleExtensions
	{
		/// <summary>
		/// Get locale file path (If the region culture does not exist, it will fallback to ISO name).
		/// </summary>
		public static void IncludeLocaleScripts(this ScriptBundle @this, string pathTemplate)
		{
			var globalizationServices = DependencyResolver.Current.GetService<IGlobalizationServices>();

			foreach (var culture in globalizationServices.GetRegionCultures())
			{
				if (File.Exists(HostingEnvironment.MapPath(string.Format(pathTemplate, culture.Name))))
				{
					@this.Include(string.Format(pathTemplate, culture.Name));
					continue;
				}

				@this.Include(string.Format(pathTemplate, culture.TwoLetterISOLanguageName));
			}
		}
	}
}
