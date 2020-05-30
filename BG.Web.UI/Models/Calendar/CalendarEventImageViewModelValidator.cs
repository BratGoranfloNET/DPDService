using FluentValidation;
using BG.Core.Entities;
using BG.Core.Repositories;
using BG.Core.Resources;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Calendar event image view model validator.
	/// </summary>
	public class CalendarEventImageViewModelValidator : AbstractValidator<CalendarEventImageViewModel>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public CalendarEventImageViewModelValidator(IBlobsRepository blobsRepository)
		{
			// Label
			RuleFor(model => model.ImageLabel).NotEmpty().WithLocalizedMessage(() => FluentValidationResources.CalendarImageEmpty);
			RuleFor(model => model.ImageLabel).Length(0, EventImage.LabelMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);
		}
	}
}
