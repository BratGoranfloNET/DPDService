using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class CalendarEventsManagerScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/calendar/events-manage-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public CalendarEventsManagerScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/calendar/eventsManager.js");
		}
	}
}
