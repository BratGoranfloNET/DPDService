using FluentValidation;
using BG.Core.Entities;
using BG.Core.Repositories;
using BG.Core.Resources;
using System;

namespace BG.Web.UI.Models
{	
	public class EventTrackingParameterFormViewModelValidator : AbstractValidator<EventTrackingParameterViewModel>
	{
		private IBlobsRepository _blobsRepository = null;

		public EventTrackingParameterFormViewModelValidator(IBlobsRepository blobsRepository)
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
