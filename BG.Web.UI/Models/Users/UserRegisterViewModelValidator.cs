using FluentValidation;
using BG.Core.Entities;
using BG.Core.Repositories;
using BG.Core.Resources;
using BG.Web.Validators;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// User register view model validator.
	/// </summary>
	public class UserRegisterViewModelValidator : AbstractValidator<UserRegisterViewModel>
	{
		private IUsersRepository _usersRepository = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public UserRegisterViewModelValidator(IUsersRepository usersRepository)
		{
			_usersRepository = usersRepository;

			// Name
			RuleFor(model => model.Name).NotEmpty();
			RuleFor(model => model.Name).Length(0, User.NameMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);

			// Email
			RuleFor(model => model.Email).NotEmpty();
			RuleFor(model => model.Email).Matches(RegularExpressions.SimpleEmailPattern);
			RuleFor(model => model.Email).Length(0, User.EmailMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);
			RuleFor(model => model.Email).Must(BeUniqueEmail).WithLocalizedMessage(() => FluentValidationResources.UserUniqueFieldError);

			// Password
			RuleFor(model => model.Password).NotEmpty();
			RuleFor(model => model.Password).Length(User.PasswordMinLength, int.MaxValue).WithLocalizedMessage(() => FluentValidationResources.MinLength);

			// Confirm Password
			RuleFor(model => model.ConfirmPassword).NotEmpty();
			RuleFor(model => model.ConfirmPassword).Equal(model => model.Password);

			// Terms Of Use
			// RuleFor(model => model.TermsOfUse).SetValidator(new RequiredCheckboxValidator()).WithLocalizedMessage(() => FluentValidationResources.TermsOfUseAgreement);
		}

		private bool BeUniqueEmail(string email)
		{
			if (string.IsNullOrWhiteSpace(email))
				return false;

			var user = _usersRepository.GetByEmail(email);

			return user == null;
		}
	}
}