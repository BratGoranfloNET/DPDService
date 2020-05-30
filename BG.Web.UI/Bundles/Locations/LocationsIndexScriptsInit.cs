using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class LocationsIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/locations/index-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public LocationsIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/locations/index.js");
		}
	}
}
