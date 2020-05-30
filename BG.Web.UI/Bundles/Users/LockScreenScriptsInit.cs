using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class LockScreenScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/users/lockscreen-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public LockScreenScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/users/lockScreen.js");
		}
	}
}
