using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class AdminScripts : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/admin/scripts";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public AdminScripts() : base(BundleVirtualPath)
		{
			Include("~/scripts/_admin.js");
			Include("~/scripts/_admin_utilities.js");
			Include("~/scripts/_admin_notify.js");
			Include("~/scripts/_admin_progress.js");
			Include("~/scripts/_admin_tables.js");
			Include("~/scripts/_admin_validation.js");
			Include("~/scripts/_admin_feedback.js");
		}
	}
}
