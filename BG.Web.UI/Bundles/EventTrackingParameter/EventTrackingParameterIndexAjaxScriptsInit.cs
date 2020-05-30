using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class EventTrackingParameterIndexAjaxScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/eventtrackingparameter/index-ajax-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public EventTrackingParameterIndexAjaxScriptsInit() : base(BundleVirtualPath)
		{
            // Include("~/scripts/stateunited/index-ajax.js");

            // Include("~/scripts/stateunited/modal-ajax.js");

            Include("~/scripts/EventTrackingParameter/index-ajax.js");

        }
    }
}
