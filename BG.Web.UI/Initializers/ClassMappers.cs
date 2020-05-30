using Owin;
using BG.Web.Configs;
using BG.Web.Mappers;
using SimpleInjector;

namespace BG.Web.UI
{
	/// <summary>
	/// Owin initializer partial class.
	/// </summary>
	public partial class Initializer
	{
		/// <summary>
		/// Initialize value injecter class mappers.
		/// </summary>
		public void ConfigureMappers(WebUIConfigs uiConfigs, IAppBuilder appBuilder, Container container)
		{
			MappersInitializer.ConfigurePlatformCommonMappers(container);
		}
	}
}