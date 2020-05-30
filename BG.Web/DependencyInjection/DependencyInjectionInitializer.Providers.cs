using BG.Core.Providers;
using BG.Web.Configs;
using BG.Web.Providers;
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
		/// Register all infrastructure service providers.
		/// </summary>
		private static void RegisterProviders(ConfigsBase configs, Container container, IEnumerable<Assembly> assemblies, IEnumerable<Type> exportedTypes)
		{
			/*
			 * Email provider and parameters
			 */
			var activeEmailProvider = configs.EmailService.GetActiveProvider();

			var exportedEmailProviderType = exportedTypes.Where(t => t.FullName.Equals(activeEmailProvider.Type)).SingleOrDefault();

			if (exportedEmailProviderType == null)
				throw new ActivationException(nameof(DependencyInjectionInitializer), new ArgumentNullException(nameof(activeEmailProvider)));

			container.RegisterSingleton(() => new EmailProviderParameters(
				activeEmailProvider.Parameters.Cast<ParameterCollectionItem>().ToDictionary(p => p.Key, p => (object)p.Value)
			));

			container.RegisterSingleton(typeof(IEmailProvider), exportedEmailProviderType);

			/*
			 * Image provider and parameters
			 */
			var activeStorageProvider = configs.ImageService.GetActiveStorageProvider();

			var exportedImageStorageProviderType = exportedTypes.Where(t => t.FullName.Equals(activeStorageProvider.Type)).SingleOrDefault();

			if (exportedImageStorageProviderType == null)
				throw new ActivationException(nameof(DependencyInjectionInitializer), new ArgumentNullException(nameof(activeStorageProvider)));

			container.RegisterSingleton(() => new ImageStorageProviderParameters(
				activeStorageProvider.ImageUploadMaxLengthInBytes,
				activeStorageProvider.Parameters.Cast<ParameterCollectionItem>().ToDictionary(p => p.Key, p => (object)p.Value)
			));

			container.RegisterSingleton(typeof(IImageStorageProvider), exportedImageStorageProviderType);

			container.Register<VirtualFileProviderPlugin>();
		}
	}
}
