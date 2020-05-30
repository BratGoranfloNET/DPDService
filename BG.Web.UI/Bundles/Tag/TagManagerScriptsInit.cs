using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class TagManagerScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/tag/manage-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public TagManagerScriptsInit() : base(BundleVirtualPath)
		{
		   //Include("~/scripts/contacts/modal.js");
			Include("~/scripts/tag/manager.js");
		}
	}
}
