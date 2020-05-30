using Owin;
using BG.Web.Configs;
using SimpleInjector;
using System.Web.Optimization;

namespace BG.Web.UI
{
	/// <summary>
	/// Owin initializer partial class.
	/// </summary>
	public partial class Initializer
	{
		/// <summary>
		/// Initialize script and css bundles.
		/// </summary>
		public void ConfigureBundles(WebUIConfigs uiConfigs, IAppBuilder appBuilder, Container container)
		{
			// Set to true/false to force minification state (otherwise, it will be managed by debug/release configurations)
			// BundleTable.EnableOptimizations = true;

			// Let files be rendered just like they are defined.
			BundleTable.Bundles.FileSetOrderList.Clear();

			var bundles = container.GetAllInstances<Bundle>();

			foreach (var bundle in bundles)
				BundleTable.Bundles.Add(bundle);
		}
	}
}
