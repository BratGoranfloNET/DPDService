using FluentValidation;
using BG.Core.Repositories;
using System;

namespace BG.Web.UI.Models
{
	public class StateHistoryFormViewModelValidator : AbstractValidator<StateHistoryViewModel>
	{
		private IBlobsRepository _blobsRepository = null;

		public StateHistoryFormViewModelValidator(IBlobsRepository blobsRepository)
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
