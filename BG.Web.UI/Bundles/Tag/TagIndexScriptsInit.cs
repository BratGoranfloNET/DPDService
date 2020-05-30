using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class TagIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/tag/index-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public TagIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/tag/index.js");
		}
	}
}
