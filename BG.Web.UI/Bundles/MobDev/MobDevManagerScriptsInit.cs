using System.Web.Optimization;

namespace BG.Web.UI.Bundles
{
	
	public class MobDevManagerScriptsInit : ScriptBundle
	{
		/// <summary>
		/// Gets the path that will reference this bundle on views.
		/// </summary>
        /// 
		public const string BundleVirtualPath = "~/bundles/mobdev/manage-scripts-init";

		/// <summary>
		/// Constructor method.
		/// </summary>
        /// 
		public MobDevManagerScriptsInit() : base(BundleVirtualPath)
		{			
			Include("~/scripts/mobdev/manager.js");
		}
	}
}
