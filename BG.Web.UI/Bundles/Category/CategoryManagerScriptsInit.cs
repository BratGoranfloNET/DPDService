using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class CategoryManagerScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/category/manage-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public CategoryManagerScriptsInit() : base(BundleVirtualPath)
		{
		   //Include("~/scripts/contacts/modal.js");
			Include("~/scripts/category/manager.js");
		}
	}
}
