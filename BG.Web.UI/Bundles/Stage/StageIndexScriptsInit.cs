using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class StageIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/stage/index-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public StageIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/stage/index.js");
		}
	}
}
