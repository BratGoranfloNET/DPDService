using FluentValidation;
using BG.Core.Resources;
using BG.Services.Image;
using System.Web;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Single image upload view model validator.
	/// </summary>
	public class ImageUploadViewModelValidator : AbstractValidator<ImageUploadViewModel>
	{
		IImageService _imageService = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public ImageUploadViewModelValidator(IImageService imageService)
		{
			_imageService = imageService;

			// Image
			RuleFor(model => model.ImageFile).NotNull();
			RuleFor(model => model.ImageFile).Must(BeOfValidContentLength).WithLocalizedMessage(() => FluentValidationResources.BlobSizeLimitError);
			RuleFor(model => model.ImageFile).Must(BeImageMimeType).WithLocalizedMessage(() => FluentValidationResources.BlobImageMimeTypeError);
		}

		/// <summary>
		/// Checks if the posted file does not exceed the image provider content max length.
		/// </summary>
		private bool BeOfValidContentLength(HttpPostedFileBase postedFile)
		{
			if (postedFile == null)
				return true;

			if (postedFile.ContentLength <= 0)
				return false;

			return postedFile.ContentLength <= _imageService.ImageUploadMaxLengthInBytes;
		}

		/// <summary>
		/// Checks if the posted file content type is from an image.
		/// </summary>
		private bool BeImageMimeType(HttpPostedFileBase postedFile)
		{
			if (postedFile == null)
				return true;

			return postedFile.ContentType.Contains("image/");
		}
	}
}
