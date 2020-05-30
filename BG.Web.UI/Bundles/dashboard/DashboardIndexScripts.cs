using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class DashboardIndexScripts : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/dashboard/index-scripts";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public DashboardIndexScripts() : base(BundleVirtualPath)
		{
			//Include("~/assets/vendor/bootstrap-multiselect/bootstrap-multiselect.js");
			//Include("~/assets/vendor/flot/jquery.flot.js");
			//Include("~/assets/vendor/flot.tooltip/flot.tooltip.js");
			//Include("~/assets/vendor/flot/jquery.flot.pie.js");
			//Include("~/assets/vendor/flot/jquery.flot.categories.js");
			//Include("~/assets/vendor/flot/jquery.flot.resize.js");
		}
	}
}
