using FluentValidation;
using BG.Core.Repositories;
using System;

namespace BG.Web.UI.Models
{	
	public class StateParcelsFormViewModelValidator : AbstractValidator<StateParcelsViewModel>
	{
		private IBlobsRepository _blobsRepository = null;
		public StateParcelsFormViewModelValidator(IBlobsRepository blobsRepository)
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
