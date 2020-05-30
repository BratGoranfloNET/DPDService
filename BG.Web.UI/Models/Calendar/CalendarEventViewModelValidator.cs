using FluentValidation;
using BG.Core.Entities;
using BG.Core.Repositories;
using BG.Core.Resources;
using System;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Calendar event view model validator.
	/// </summary>
	public class CalendarEventViewModelValidator : AbstractValidator<CalendarEventViewModel>
	{
		/// <summary>
		/// Constructor method.
		/// </summary>
		public CalendarEventViewModelValidator(IBlobsRepository blobsRepository)
		{
			// Color
			RuleFor(model => model.Color).NotEmpty();

			// Name
			RuleFor(model => model.Name).NotEmpty();
			RuleFor(model => model.Name).Length(0, Event.NameMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);

			// Start Date
			RuleFor(model => model.StartDate).NotEmpty();
			RuleFor(model => model.StartDate).Must(BeAValidDate);

			// Start Time
			RuleFor(model => model.StartTime).NotEmpty();
			RuleFor(model => model.StartTime).Must(BeAValidTime);

			// End Date
			RuleFor(model => model.EndDate).NotEmpty();
			RuleFor(model => model.EndDate).Must(BeAValidDate);

			// End Time
			RuleFor(model => model.EndTime).NotEmpty();
			RuleFor(model => model.EndTime).Must(BeAValidTime);

			// Location
			//RuleFor(model => model.LocationId).NotEmpty();

            // Production
            //RuleFor(model => model.ProductionId).NotEmpty();

            // Production
            //RuleFor(model => model.EventTypeId).NotEmpty();
            

            // Images
            RuleFor(model => model.Images).SetCollectionValidator(new CalendarEventImageViewModelValidator(blobsRepository));
		}

		/// <summary>
		/// Validate the date.
		/// </summary>
		private bool BeAValidDate(DateTime? date)
		{
			if (!date.HasValue)
				return true;

			return !date.Value.Equals(default(DateTime));
		}

		/// <summary>
		/// Validate the time.
		/// </summary>
		private bool BeAValidTime(DateTime? time)
		{
			if (!time.HasValue)
				return true;

			return !time.Value.TimeOfDay.Equals(TimeSpan.Zero);
		}
	}
}
