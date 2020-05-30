using BG.Web.Configs;
using BG.Web.Logger;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace BG.Web.DependencyInjection
{
	/// <summary>
	/// Dependency injection initializer partial class.
	/// </summary>
	public partial class DependencyInjectionInitializer
	{
        /// <summary>
        /// Register all logger related types.
        /// </summary>
        ///       
        private static void RegisterLoggerItems(ConfigsBase configs, Container container, IEnumerable<Assembly> assemblies, IEnumerable<Type> exportedTypes)
        {
            container.RegisterConditional(
                typeof(ILoggerFactory),
                context => typeof(LoggerFactory<>).MakeGenericType(context.Consumer.ImplementationType),
                Lifestyle.Singleton,
                context => true
            );
        }
    }
}
