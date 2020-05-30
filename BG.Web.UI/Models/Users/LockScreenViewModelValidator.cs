using FluentValidation;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Lock screen view model validator.
	/// </summary>
	public class LockScreenViewModelValidator : AbstractValidator<LockScreenViewModel>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public LockScreenViewModelValidator()
		{
			// Password
			RuleFor(model => model.Password).NotEmpty();
		}
	}
}
