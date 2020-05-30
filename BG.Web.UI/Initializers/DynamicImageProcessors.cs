using Owin;
using BG.Web.Configs;
using BG.Web.Providers;
using SimpleInjector;
using System;

namespace BG.Web.UI
{
	/// <summary>
	/// Owin initializer partial class.
	/// </summary>
	public partial class Initializer
	{
		/// <summary>
		/// Initialize image resizer tools (Enabled image resirer module to use the currently active IImageService).
		/// <para>http://imageresizing.net/docs/v4/extend/basics</para>
		/// </summary>
		public void ConfigureDynamicImageProcessors(WebUIConfigs uiConfigs, IAppBuilder appBuilder, Container container)
		{
			var plugin = container.GetInstance<VirtualFileProviderPlugin>();

			if (plugin == null)
				throw new ArgumentException(nameof(Initializer), new ArgumentNullException(nameof(plugin)));

			plugin.Install(ImageResizer.Configuration.Config.Current);
		}
	}
}
