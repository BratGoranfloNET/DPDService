using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class HeadScripts : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/head/scripts";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public HeadScripts() : base(BundleVirtualPath)
		{
			Include("~/assets/vendor/modernizr/modernizr.js");
		}
	}
}
