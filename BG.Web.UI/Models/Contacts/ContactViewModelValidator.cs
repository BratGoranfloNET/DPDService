using FluentValidation;
using BG.Core.Entities;
using BG.Core.Repositories;
using BG.Core.Resources;
using System;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Contact view model validator.
	/// </summary>
	public class ContactViewModelValidator : AbstractValidator<ContactViewModel>
	{
		private IBlobsRepository _blobsRepository = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ContactViewModelValidator(IBlobsRepository blobsRepository)
		{
			_blobsRepository = blobsRepository;

			// Image Blob Id
			RuleFor(model => model.ImageBlobId).Must(BeExistingImageBlobId);

			// Name
			RuleFor(model => model.Name).NotEmpty();
			RuleFor(model => model.Name).Length(0, Contact.NameMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);

			// Birth Date
			RuleFor(model => model.BirthDate).Must(BeAValidDate);

			// Primary Email
			RuleFor(model => model.Email1).Matches(RegularExpressions.SimpleEmailPattern);
			RuleFor(model => model.Email1).Length(0, Contact.EmailMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);

			// Secondary Email
			RuleFor(model => model.Email2).Matches(RegularExpressions.SimpleEmailPattern);
			RuleFor(model => model.Email2).Length(0, Contact.EmailMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);

			// Primary Phone
			RuleFor(model => model.Phone1).Length(0, Contact.PhoneMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);

			// Secondary Phone
			RuleFor(model => model.Phone2).Length(0, Contact.PhoneMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);
		}

		private bool BeExistingImageBlobId(Guid? imageBlobId)
		{
			if (!imageBlobId.HasValue)
				return true;

			var imageBlob = _blobsRepository.GetById(imageBlobId.Value);

			return imageBlob != null;
		}

		private bool BeAValidDate(DateTime? birthDate)
		{
			if (!birthDate.HasValue)
				return true;

			return !birthDate.Value.Equals(default(DateTime));
		}
	}
}
