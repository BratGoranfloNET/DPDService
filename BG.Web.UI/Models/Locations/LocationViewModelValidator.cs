using FluentValidation;
using BG.Core.Entities;
using BG.Core.Repositories;
using BG.Core.Resources;
using System;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Location view model validator.
	/// </summary>
	public class LocationsFormViewModelValidator : AbstractValidator<LocationViewModel>
	{
		private IBlobsRepository _blobsRepository = null;

		public LocationsFormViewModelValidator(IBlobsRepository blobsRepository)
		{
			_blobsRepository = blobsRepository;

			// Image Blob Id
			RuleFor(model => model.ImageBlobId).Must(BeExistingImageBlobId);

			// Name
			RuleFor(model => model.Name).NotEmpty();
			RuleFor(model => model.Name).Length(0, Location.NameMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);

			// Time zone id
			RuleFor(model => model.TimeZoneId).NotEmpty();

            RuleFor(model => model.City).NotEmpty();
            RuleFor(model => model.Latitude).NotEmpty();
            RuleFor(model => model.Longitude).NotEmpty();


        }

		private bool BeExistingImageBlobId(Guid? imageBlobId)
		{
			if (!imageBlobId.HasValue)
				return true;

			var imageBlob = _blobsRepository.GetById(imageBlobId.Value);

			return imageBlob != null;
		}
	}
}
