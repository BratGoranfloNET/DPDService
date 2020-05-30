using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class PlatformUsersScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/platform/users-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public PlatformUsersScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/platform/users.js");
		}
	}
}
