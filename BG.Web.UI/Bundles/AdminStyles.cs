using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class AdminStyles : StyleBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/admin/styles";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public AdminStyles() : base(BundleVirtualPath)
		{
			// Fix relative urls in css files
			var urlTransform = new CssRewriteUrlTransform();

			Include("~/contents/admin.css", urlTransform);
		}
	}
}
