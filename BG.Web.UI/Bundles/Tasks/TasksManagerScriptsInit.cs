using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	/// <summary>
	/// Specialized bundle.
	/// </summary>
	public class TasksManagerScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
		public const string BundleVirtualPath = "~/bundles/tasks/manage-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
		public TasksManagerScriptsInit() : base(BundleVirtualPath)
		{
			
			Include("~/scripts/tasks/manager.js");
		}
	}
}
