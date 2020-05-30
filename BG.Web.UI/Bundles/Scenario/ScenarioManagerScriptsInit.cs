using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	
	public class ScenarioManagerScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
        /// 
		public const string BundleVirtualPath = "~/bundles/scenario/manage-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
        /// 
		public ScenarioManagerScriptsInit() : base(BundleVirtualPath)
		{			
			Include("~/scripts/scenario/manager.js");
		}
	}
}
