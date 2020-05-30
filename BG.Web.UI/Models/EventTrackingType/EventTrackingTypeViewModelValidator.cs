using FluentValidation;
using BG.Core.Entities;
using BG.Core.Repositories;
using BG.Core.Resources;
using System;

namespace BG.Web.UI.Models
{
	public class EventTrackingTypeFormViewModelValidator : AbstractValidator<EventTrackingTypeViewModel>
	{
		private IBlobsRepository _blobsRepository = null;

		public EventTrackingTypeFormViewModelValidator(IBlobsRepository blobsRepository)
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
