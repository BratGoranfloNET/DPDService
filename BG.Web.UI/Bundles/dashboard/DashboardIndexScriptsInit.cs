using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class DashboardIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/dashboard/index-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public DashboardIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/dashboard/index.js");
            //Include("~/scripts/Static/dash.js");
          

        }
	}
}
