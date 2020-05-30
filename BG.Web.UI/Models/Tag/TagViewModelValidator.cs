using FluentValidation;
using BG.Core.Entities;
using BG.Core.Repositories;
using BG.Core.Resources;
using System;

namespace BG.Web.UI.Models
{	
	public class TagFormViewModelValidator : AbstractValidator<TagViewModel>
	{
		private IBlobsRepository _blobsRepository = null;

		public TagFormViewModelValidator(IBlobsRepository blobsRepository)
		{
			_blobsRepository = blobsRepository;
			RuleFor(model => model.Name).NotEmpty();
			RuleFor(model => model.Name).Length(0, Location.NameMaxLength).WithLocalizedMessage(() => FluentValidationResources.MaxLength);

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
