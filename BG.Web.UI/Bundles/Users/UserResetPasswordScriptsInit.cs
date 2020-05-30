using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class UserResetPasswordScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/users/resetpassword-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public UserResetPasswordScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/users/resetPassword.js");
		}
	}
}
