using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class CalendarIndexScripts : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/calendar/index-scripts";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public CalendarIndexScripts() : base(BundleVirtualPath)
		{
			Include("~/assets/vendor/moment/moment.js");
			Include("~/assets/vendor/fullcalendar/fullcalendar.js");
			this.IncludeLocaleScripts("~/assets/vendor/fullcalendar/locale/{0}.js");
		}
	}
}
