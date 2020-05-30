using Microsoft.Owin;
using Owin;
using BG.Web.Configs;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Http;
using SimpleInjector.Integration.WebApi;

[assembly: OwinStartup(typeof(BG.Web.UI.Initializer), "Initialize")]

namespace BG.Web.UI
{
	/// <summary>
	/// Owin initializer partial class.
	/// </summary>
	public partial class Initializer
	{
		/// <summary>
		/// Initialize features (All elements that participate in the initialization process are considered part of the composition root).
		/// </summary>
		public void Initialize(IAppBuilder appBuilder)
		{
			var container = new Container();

			var assemblies = GetKnownLoadedAssemblies();

			// Replace MVC dependency resolver.
			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

			// Get the application settings from the web configuration file.
			var uiConfigs = ConfigurationManager.GetSection("dotadmin.webui") as WebUIConfigs;

			// Dependency injection
			ConfigureContainerAndRegisterTypes(uiConfigs, appBuilder, container, assemblies);

			// Dynamic image processors
			ConfigureDynamicImageProcessors(uiConfigs, appBuilder, container);

			// Authentication
			ConfigureOwinAuthentication(uiConfigs, appBuilder, container);

			// Validators
			ConfigureValidators(uiConfigs, appBuilder, container);

			// Mappers
			ConfigureMappers(uiConfigs, appBuilder, container);

			// Logger
			ConfigureLogger(uiConfigs, appBuilder, container);

			// Bundles
			ConfigureBundles(uiConfigs, appBuilder, container);

			// Verify configuration.
			container.Verify();


            // Replace Web API dependency resolver.
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);


        }

        /// <summary>
        /// Get all known assemblies loaded by the app.
        /// </summary>
        private static IEnumerable<Assembly> GetKnownLoadedAssemblies()
		{
			var assemblies = AppDomain.CurrentDomain.GetAssemblies();

			return assemblies.Where(a => a.FullName.Contains("BG.")).ToList();
		}
	}
}
