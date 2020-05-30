using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class ContactsManagerScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/contacts/manage-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ContactsManagerScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/contacts/manager.js");
		}
	}
}
