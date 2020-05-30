using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class ContactsIndexStyles : StyleBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/contacts/index-styles";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ContactsIndexStyles() : base(BundleVirtualPath)
		{
			// Fix relative urls in css files
			// Css relative paths should be wrapped by quotes or include the min file.
			var urlTransform = new CssRewriteUrlTransform();

			Include("~/assets/vendor/jquery-datatables-bs3/assets/css/datatables.css", urlTransform);
		}
	}
}
