using FluentValidation;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// User login view model validator.
	/// </summary>
	public class UserLoginViewModelValidator : AbstractValidator<UserLoginViewModel>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public UserLoginViewModelValidator()
		{
			// Email or username
			RuleFor(model => model.EmailOrUsername).NotEmpty();

			// Password
			RuleFor(model => model.Password).NotEmpty();
		}
	}
}
