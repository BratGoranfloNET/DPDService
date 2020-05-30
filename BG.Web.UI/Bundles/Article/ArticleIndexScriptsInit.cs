using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class ArticleIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/article/article-index-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
        



		public ArticleIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/article/index.js");
          


              

        }
	}
}
