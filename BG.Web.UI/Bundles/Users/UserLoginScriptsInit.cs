using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class UserLoginScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/users/login-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public UserLoginScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/users/login.js");
		}
	}
}
