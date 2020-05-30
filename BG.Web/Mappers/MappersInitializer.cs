using BG.Core.Mappers;
using SimpleInjector;

namespace BG.Web.Mappers
{
	/// <summary>
	/// Mappers initializer partial class.
	/// </summary>
	public partial class MappersInitializer
	{
		/// <summary>
		/// Initialize platform common class and data mappers.
		/// </summary>
		public static void ConfigurePlatformCommonMappers(Container container)
		{
			var mappers = container.GetAllInstances<IClassMapper>();

			foreach (var mapper in mappers)
				mapper.Configure();
		}
	}
}