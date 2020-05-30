using FluentValidation;
using BG.Core.Entities;
using BG.Core.Resources;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// User reset password view model validator.
	/// </summary>
	public class UserResetPasswordViewModelValidator : AbstractValidator<UserResetPasswordViewModel>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public UserResetPasswordViewModelValidator()
		{
			// Email
			RuleFor(model => model.Email).NotEmpty();
			RuleFor(model => model.Email).Matches(RegularExpressions.SimpleEmailPattern);
			RuleFor(model => model.Email).Length(0, User.EmailMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);
		}
	}
}