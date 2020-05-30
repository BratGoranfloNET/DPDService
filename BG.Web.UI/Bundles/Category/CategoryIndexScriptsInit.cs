using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class CategoryIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/category/index-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public CategoryIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/category/index.js");
		}
	}
}
