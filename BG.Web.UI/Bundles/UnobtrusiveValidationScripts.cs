using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class UnobtrusiveValidationScripts : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/unobtrusive-validation/scripts";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public UnobtrusiveValidationScripts() : base(BundleVirtualPath)
		{
			Include("~/Scripts/jquery.validate.unobtrusive.min.js");
			Include("~/Scripts/jquery.validate.unobtrusive.setup.js");
		}
	}
}
