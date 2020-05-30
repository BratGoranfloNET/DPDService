using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	
	public class StageManagerScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
        /// 
		public const string BundleVirtualPath = "~/bundles/stage/manage-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
        /// 
		public StageManagerScriptsInit() : base(BundleVirtualPath)
		{			
			Include("~/scripts/stage/manager.js");
		}
	}
}
