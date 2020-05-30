using FluentValidation;
using BG.Core.Entities;
using BG.Core.Resources;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// User change password view model validator.
	/// </summary>
	public class UserChangePasswordViewModelValidator : AbstractValidator<UserChangePasswordViewModel>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public UserChangePasswordViewModelValidator()
		{
			// Password
			RuleFor(model => model.Password).NotEmpty();
			RuleFor(model => model.Password).Length(User.PasswordMinLength, int.MaxValue).WithLocalizedMessage(() => FluentValidationResources.MinLength);

			// New Password
			RuleFor(model => model.NewPassword).NotEmpty();
			RuleFor(model => model.NewPassword).Length(User.PasswordMinLength, int.MaxValue).WithLocalizedMessage(() => FluentValidationResources.MinLength);

			// New Password Confirmation
			RuleFor(model => model.NewPasswordConfirmation).NotEmpty();
			RuleFor(model => model.NewPasswordConfirmation).Equal(model => model.NewPassword);
		}
	}
}
