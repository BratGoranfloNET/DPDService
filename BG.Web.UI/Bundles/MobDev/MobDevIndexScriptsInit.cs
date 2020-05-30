using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class MobDevIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/mobdev/index-scripts-init";

        /// <summary>
        /// Constructor method.
        /// </summary>
        public MobDevIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/mobdev/index.js");
		}
	}
}
