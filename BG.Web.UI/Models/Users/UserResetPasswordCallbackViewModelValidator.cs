using FluentValidation;
using BG.Core.Entities;
using BG.Core.Resources;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// User reset password view model validator.
	/// </summary>
	public class UserResetPasswordCallbackViewModelValidator : AbstractValidator<UserResetPasswordCallbackViewModel>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public UserResetPasswordCallbackViewModelValidator()
		{
			// Email
			RuleFor(model => model.Email).NotEmpty();
			RuleFor(model => model.Email).Matches(RegularExpressions.SimpleEmailPattern);
			RuleFor(model => model.Email).Length(0, User.EmailMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);

			// Password
			RuleFor(model => model.Password).NotEmpty();
			RuleFor(model => model.Password).Length(User.PasswordMinLength, int.MaxValue).WithLocalizedMessage(() => FluentValidationResources.MinLength);

			// Confirm Password
			RuleFor(model => model.ConfirmPassword).NotEmpty();
			RuleFor(model => model.ConfirmPassword).Equal(model => model.Password);
		}
	}
}
