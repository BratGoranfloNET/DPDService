using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class StatusIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/status/index-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public StatusIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/status/index.js");
		}
	}
}
