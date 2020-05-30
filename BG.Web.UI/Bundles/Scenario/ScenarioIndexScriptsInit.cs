using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class ScenarioIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/scenario/index-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ScenarioIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/scenario/index.js");
		}
	}
}
