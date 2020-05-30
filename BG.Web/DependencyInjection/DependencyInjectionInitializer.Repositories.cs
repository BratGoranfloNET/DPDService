using BG.Core.Repositories;
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
		/// Register all types that implement repository interfaces from the 'BG.Core.Repositories' namespace.
		/// </summary>
		private static void RegisterRepositories(ConfigsBase configs, Container container, IEnumerable<Assembly> assemblies, IEnumerable<Type> exportedTypes)
		{
			var items = exportedTypes.Where(type =>
				type.IsClass
				&& type.GetInterfaces().Any(@interface =>
					@interface.Namespace != null
					&& @interface.Namespace.StartsWith("BG.Core.Repositories")                   
                    && @interface != typeof(IDbConnectionFactory)
				)
			)
			.Select(type => new
			{
				service = type.GetInterfaces().First(),
				implementation = type
			}).ToList();

			items.ForEach(item => container.Register(item.service, item.implementation));
		}
	}
}
