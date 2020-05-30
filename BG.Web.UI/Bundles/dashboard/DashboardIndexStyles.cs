using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class DashboardIndexStyles : StyleBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/dashboard/index-styles";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public DashboardIndexStyles() : base(BundleVirtualPath)
		{
			// Fix relative urls in css files
			var urlTransform = new CssRewriteUrlTransform();

			Include("~/assets/vendor/bootstrap-multiselect/bootstrap-multiselect.css", urlTransform);
		}
	}
}
