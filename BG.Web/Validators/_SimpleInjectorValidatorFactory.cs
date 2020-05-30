using FluentValidation;
using SimpleInjector;
using System;

namespace BG.Web.Validators
{
	/// <summary>
	/// Simple injector dependency injection enabled fluent validator factory.
	/// </summary>
	public class SimpleInjectorValidatorFactory : ValidatorFactoryBase
	{
		private Container _container = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		/// <param name="container"></param>
		public SimpleInjectorValidatorFactory(Container container)
		{
			_container = container;
		}

		/// <summary>
		/// Get validator implementation.
		/// </summary>
		public override IValidator CreateInstance(Type validatorType)
		{
			var registration = _container.GetRegistration(validatorType, throwOnFailure: false);

			if (registration == null)
				return null;

			return registration.GetInstance() as IValidator;
		}
	}
}
