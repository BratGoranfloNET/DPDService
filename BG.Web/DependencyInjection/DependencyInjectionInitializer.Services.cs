using BG.Services.Email;
using BG.Web.Configs;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace BG.Web.DependencyInjection
{
	/// <summary>
	/// Dependency injection initializer partial class.
	/// </summary>
	public partial class DependencyInjectionInitializer
	{
		/// <summary>
		/// Register all types that implement interfaces from the 'BG.Services' namespace.
		/// </summary>
		private static void RegisterServices(ConfigsBase configs, Container container, IEnumerable<Assembly> assemblies, IEnumerable<Type> exportedTypes)
		{
			container.RegisterSingleton(() => new EmailServiceSettings(
				configs.EmailService.SenderDisplayName,
				configs.EmailService.SenderEmailAddress)
			);

			var items = exportedTypes.Where(type =>
				type.GetInterfaces().Any(@interface =>
					@interface.Namespace != null
					&& @interface.Namespace.StartsWith("BG.Services")
				)
			).Select(type => new
			{
				service = type.GetInterfaces().First(),
				implementation = type
			}).ToList();

			items.ForEach(item => container.Register(item.service, item.implementation));
		}
	}
}
