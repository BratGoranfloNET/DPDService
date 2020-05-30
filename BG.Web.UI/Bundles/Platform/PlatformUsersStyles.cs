using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class PlatformUsersStyles : StyleBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/platform/users-styles";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public PlatformUsersStyles() : base(BundleVirtualPath)
		{
			// Fix relative urls in css files
			// Css relative paths should be wrapped by quotes or include the min file.
			var urlTransform = new CssRewriteUrlTransform();

			Include("~/assets/vendor/jquery-datatables-bs3/assets/css/datatables.css", urlTransform);
		}
	}
}
