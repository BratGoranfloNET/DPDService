using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class UserRegisterScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/users/register-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public UserRegisterScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/users/register.js");
		}
	}
}
