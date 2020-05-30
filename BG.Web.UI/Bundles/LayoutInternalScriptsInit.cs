using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class LayoutInternalScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/layout/internal-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public LayoutInternalScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/calendar/eventsSidebar.js");
			Include("~/scripts/users/lockScreen.js");
		}
	}
}
