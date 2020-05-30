using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class EventTypeIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/eventtype/index-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public EventTypeIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/eventtype/index.js");
		}
	}
}
