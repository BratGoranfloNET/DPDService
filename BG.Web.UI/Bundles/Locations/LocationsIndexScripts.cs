using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class LocationsIndexScripts : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/locations/index-scripts";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public LocationsIndexScripts() : base(BundleVirtualPath)
		{
			// Data tables
			Include("~/assets/vendor/jquery-datatables/media/js/jquery.dataTables.js");
			Include("~/assets/vendor/jquery-datatables/extras/TableTools/js/dataTables.tableTools.js");
			Include("~/assets/vendor/jquery-datatables-bs3/assets/js/datatables.js");
		}
	}
}
