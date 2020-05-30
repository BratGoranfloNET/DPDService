using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class ThemeStyles : StyleBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/theme/styles";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ThemeStyles() : base(BundleVirtualPath)
		{
			// Fix relative urls in css files
			var urlTransform = new CssRewriteUrlTransform();

			// Theme CSS
			Include("~/assets/stylesheets/theme.css", urlTransform);

			// Skin CSS
			Include("~/assets/stylesheets/skins/default.css", urlTransform);
			Include("~/assets/stylesheets/skins/square-borders.css", urlTransform);

			// Theme Custom CSS
			Include("~/assets/stylesheets/theme-custom.css", urlTransform);
		}
	}
}
