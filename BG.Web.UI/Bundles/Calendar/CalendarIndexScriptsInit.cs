using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class CalendarIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/calendar/index-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public CalendarIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/calendar/index.js");
		}
	}
}
