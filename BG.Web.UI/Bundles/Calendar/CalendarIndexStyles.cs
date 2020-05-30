using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class CalendarIndexStyles : StyleBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/calendar/index-styles";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public CalendarIndexStyles() : base(BundleVirtualPath)
		{
			// Fix relative urls in css files
			var urlTransform = new CssRewriteUrlTransform();

			Include("~/assets/vendor/fullcalendar/fullcalendar.min.css", urlTransform);
		}
	}
}
