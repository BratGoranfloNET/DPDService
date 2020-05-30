using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class UserAccountScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/users/account-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public UserAccountScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/users/account.js");
		}
	}
}
