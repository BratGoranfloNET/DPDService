using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class StateUnitedIndexAjaxScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/stateunited/index-ajax-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public StateUnitedIndexAjaxScriptsInit() : base(BundleVirtualPath)
		{
            // Include("~/scripts/stateunited/index-ajax.js");

            // Include("~/scripts/stateunited/modal-ajax.js");

            Include("~/scripts/stateunited/index-ajax-mixed.js");

        }
    }
}
