using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class LocationsManagerScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/locations/manage-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public LocationsManagerScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/contacts/modal.js");
			Include("~/scripts/locations/manager.js");
		}
	}
}
