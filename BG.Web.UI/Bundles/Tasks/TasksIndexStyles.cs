using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class TasksIndexStyles : StyleBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/tasks/index-styles";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public TasksIndexStyles() : base(BundleVirtualPath)
		{
			// Fix relative urls in css files
			// Css relative paths should be wrapped by quotes or include the min file.
			var urlTransform = new CssRewriteUrlTransform();

			Include("~/assets/vendor/jquery-datatables-bs3/assets/css/datatables.css", urlTransform);
		}
	}
}
