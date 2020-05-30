using Microsoft.Owin;
using Owin;
using BG.Core.Context;
using BG.Core.Principal;
using BG.Web.Configs;
using BG.Web.DependencyInjection;
using BG.Web.Identity;
using SimpleInjector;
using SimpleInjector.Advanced;
using SimpleInjector.Integration.Web;
using System.Collections.Generic;
using System.Reflection;
using System.Web;
using System.Web.Optimization;

namespace BG.Web.UI
{
	/// <summary>
	/// Owin initializer partial class.
	/// </summary>
	public partial class Initializer
	{
		/// <summary>
		/// Initialize can configure main container types.
		/// </summary>
		private void ConfigureContainerAndRegisterTypes(WebUIConfigs uiConfigs, IAppBuilder appBuilder, Container container, IEnumerable<Assembly> assemblies)
		{
			container.Options.DefaultLifestyle = new WebRequestLifestyle();
			container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();
			container.Options.PropertySelectionBehavior = new ImportPropertySelectionBehavior();

			// Register all web platform commont types
			DependencyInjectionInitializer.RegisterWebPlatformCommonTypes(uiConfigs, appBuilder, container, assemblies);

			// Register all optimization bundles
			container.RegisterCollection<Bundle>(assemblies);

			// MVC IFilterProvider attributes
			container.RegisterMvcIntegratedFilterProvider();

			// MVC controllers
			container.RegisterMvcControllers();

			// OAuth user sign in manager
			container.Register<DotUserSignInManager>();

			// IAuthenticationManager
			container.Register(() =>
			{
				// If testing (container.Verify()) or no context available, return a dummy instance
				if (AdvancedExtensions.IsVerifying(container) || HttpContext.Current == null)
					return new OwinContext().Authentication;

				// Otherwise return current authentication manager instance
				return HttpContext.Current.GetOwinContext().Authentication;
			});

			// IWebContext
			container.Register<IWebContext>(() =>
			{
				// If testing (container.Verify()) or no context available, return a dummy instance
				if (AdvancedExtensions.IsVerifying(container) || HttpContext.Current == null)
					return new WebUIContext();

				// Otherwise return current user web context.
				return new WebUIContext(new CorePrincipal(HttpContext.Current.User));
			});
		}
	}
}
