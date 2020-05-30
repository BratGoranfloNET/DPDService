using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class EventTypeManagerScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/eventtype/manage-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public EventTypeManagerScriptsInit() : base(BundleVirtualPath)
		{
		   //Include("~/scripts/contacts/modal.js");
			Include("~/scripts/eventtype/manager.js");
		}
	}
}
