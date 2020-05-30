using FluentValidation.Validators;
using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Internal;

namespace BG.Web.Validators
{
	/// <summary>
	/// Custom validator that required a checkbox to be checked. Supports server and client side validation.
	/// </summary>
	public class RequiredCheckboxValidator : PropertyValidator, IClientValidatable
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public RequiredCheckboxValidator() : base("'{PropertyName}' is required!")
		{
		}

		/// <summary>
		/// Validate the checkbox state.
		/// </summary>
		protected override bool IsValid(PropertyValidatorContext context)
		{
			var state = context.PropertyValue.ChangeType<bool?>();

			return state.HasValue && state.Value;
		}

		/// <summary>
		/// Get the validation rules for the unobtrusive javascript validation.
		/// </summary>
		public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
		{
			var messageFormatter = new MessageFormatter().AppendPropertyName(metadata.DisplayName);
			var FormatterdMessage = messageFormatter.BuildMessage(ErrorMessageSource.GetString());

			var rule = new ModelClientValidationRule
			{
				ErrorMessage = FormatterdMessage,
				ValidationType = "requiredcheckbox"
			};

			yield return rule;
		}
	}
}
