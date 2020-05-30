using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class PlatformUsersManagerScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/platform/users-manager-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public PlatformUsersManagerScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/platform/usersManager.js");
		}
	}
}
