using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class TasksIndexScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/tasks/index-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public TasksIndexScriptsInit() : base(BundleVirtualPath)
		{
			Include("~/scripts/tasks/index.js");
		}
	}
}
