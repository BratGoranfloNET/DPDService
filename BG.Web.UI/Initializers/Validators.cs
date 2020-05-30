using FluentValidation;
using FluentValidation.Mvc;
using Owin;
using BG.Core.Resources;
using BG.Web.Configs;
using BG.Web.Validators;
using SimpleInjector;

namespace BG.Web.UI
{
	/// <summary>
	/// Owin initializer partial class.
	/// </summary>
	public partial class Initializer
	{
		/// <summary>
		/// Initialize validator.
		/// </summary>
		public void ConfigureValidators(WebUIConfigs uiConfigs, IAppBuilder appBuilder, Container container)
		{
			// Set fluent validation error message resources type.
			ValidatorOptions.ResourceProviderType = typeof(FluentValidationResources);

			// Set custom factory for MVC validators.
			FluentValidationModelValidatorProvider.Configure(config =>
			{
				config.ValidatorFactory = new SimpleInjectorValidatorFactory(container);
			});
		}
	}
}
