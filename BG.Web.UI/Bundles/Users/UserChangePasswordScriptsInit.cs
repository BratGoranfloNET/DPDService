using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class UserChangePasswordScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/users/change-password-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public UserChangePasswordScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/users/changePassword.js");
		}
	}
}
