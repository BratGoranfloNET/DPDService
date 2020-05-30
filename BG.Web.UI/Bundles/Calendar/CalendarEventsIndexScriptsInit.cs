using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class CalendarEventsIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/calendar/events-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public CalendarEventsIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/calendar/eventsIndex.js");
		}
	}
}
