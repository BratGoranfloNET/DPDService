using FluentValidation;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using BG.Core.Mappers;
using BG.Core.Repositories;
using BG.Web.Configs;
using BG.Web.Identity;
using SimpleInjector;
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
		public static void RegisterWebPlatformCommonTypes(ConfigsBase configs, IAppBuilder appBuilder, Container container, IEnumerable<Assembly> assemblies)
		{
			// Get publicly available types from the domain.
			var exportedTypes = assemblies.SelectMany(a => a.GetExportedTypes());

			// Web.config connection string aware IDbConnection profactory.
			container.Register<IDbConnectionFactory, WebConnectionFactory>();			          

            // Register all fluent validation validators.
            container.Register(typeof(IValidator<>), assemblies);

			// Register all value injecter class mappers.
			container.RegisterCollection<IClassMapper>(assemblies);

            // Register logger items            
            RegisterLoggerItems(configs, container, assemblies, exportedTypes); 

            // Provider interfaces
            RegisterProviders(configs, container, assemblies, exportedTypes);

			// BG.Core.Repositories interfaces
			RegisterRepositories(configs, container, assemblies, exportedTypes);

			// BG.Services interfaces
			RegisterServices(configs, container, assemblies, exportedTypes);

			// IDataProtectionProvider
			container.Register(() => appBuilder.GetDataProtectionProvider());

			// Register common OAuth
			container.Register<DotUserStore>();
			container.Register<DotUserManager>();
		}
	}
}
