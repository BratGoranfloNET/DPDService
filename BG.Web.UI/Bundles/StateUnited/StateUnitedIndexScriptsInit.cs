using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class StateUnitedIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/stateunited/index-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public StateUnitedIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/stateunited/index.js");
            //Include("~/scripts/stateunited/modal.js");
            Include("~/scripts/stateunited/modal-ajax.js");
        }
	}
}
