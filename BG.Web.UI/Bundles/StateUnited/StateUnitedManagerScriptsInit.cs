using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class StateUnitedManagerScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/stateunited/manage-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public StateUnitedManagerScriptsInit() : base(BundleVirtualPath)
		{
		   //Include("~/scripts/contacts/modal.js");
			Include("~/scripts/stateunited/manager.js");
		}
	}
}
