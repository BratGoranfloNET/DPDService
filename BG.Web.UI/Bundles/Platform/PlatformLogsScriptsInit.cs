using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class PlatformLogsScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/platform/logs-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public PlatformLogsScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/platform/logs.js");
		}
	}
}
