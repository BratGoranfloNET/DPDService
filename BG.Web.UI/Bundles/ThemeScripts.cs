using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class ThemeScripts : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/theme/scripts";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ThemeScripts() : base(BundleVirtualPath)
		{
			Include("~/assets/javascripts/theme.js");
			Include("~/assets/javascripts/theme.custom.js");
			Include("~/assets/javascripts/theme.init.js");
		}
	}
}
