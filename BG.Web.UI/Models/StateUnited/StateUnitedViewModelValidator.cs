using FluentValidation;
using BG.Core.Repositories;
using System;

namespace BG.Web.UI.Models
{	
	public class StateUnitedFormViewModelValidator : AbstractValidator<StateUnitedViewModel>
	{
		private IBlobsRepository _blobsRepository = null;

		public StateUnitedFormViewModelValidator(IBlobsRepository blobsRepository)
		{
			_blobsRepository = blobsRepository;
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
