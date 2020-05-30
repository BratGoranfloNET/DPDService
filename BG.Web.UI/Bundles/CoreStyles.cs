using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class CoreStyles : StyleBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/core/styles";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public CoreStyles() : base(BundleVirtualPath)
		{
			// Fix relative urls in css files
			// Css relative paths should be wrapped by quotes or include the min file.
			var urlTransform = new CssRewriteUrlTransform();

			Include("~/assets/vendor/bootstrap/css/bootstrap.min.css", urlTransform);
			Include("~/assets/vendor/font-awesome/css/font-awesome.min.css", urlTransform);
			Include("~/assets/vendor/magnific-popup/magnific-popup.css", urlTransform);
			Include("~/assets/vendor/bootstrap-datepicker/css/bootstrap-datepicker3.css", urlTransform);
			Include("~/assets/vendor/bootstrap-timepicker/css/bootstrap-timepicker.css", urlTransform);

			Include("~/assets/vendor/bootstrap-colorpicker/css/bootstrap-colorpicker.min.css", urlTransform);

			Include("~/assets/vendor/jquery-ui/jquery-ui.css", urlTransform);
			Include("~/assets/vendor/jquery-ui/jquery-ui.theme.css", urlTransform);

			Include("~/assets/vendor/pnotify/pnotify.custom.css", urlTransform);

			Include("~/assets/vendor/select2/css/select2.css", urlTransform);
			Include("~/assets/vendor/select2-bootstrap-theme/select2-bootstrap.css", urlTransform);
		}
	}
}
