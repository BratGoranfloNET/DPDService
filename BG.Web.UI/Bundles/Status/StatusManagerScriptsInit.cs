using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	
	public class StatusManagerScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
        /// 
		public const string BundleVirtualPath = "~/bundles/status/manage-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
        /// 
		public StatusManagerScriptsInit() : base(BundleVirtualPath)
		{			
			Include("~/scripts/status/manager.js");
		}
	}
}
