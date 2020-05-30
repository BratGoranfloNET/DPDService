using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial users controller.
	/// </summary>
	public partial class UsersController
	{
		/// <summary>
		/// POST / Profile image upload action.
		/// </summary>
		[HttpPost]
		[Route("profile/image/upload", Name = "UsersProfileImageUploadPost")]
		public ActionResult ProfileImageUpload(ImageUploadViewModel model)
		{
			if (ModelState.IsValid)
			{
				var blob = _imageService.Upload(
					model.ImageFile.FileName,
					model.ImageFile.ContentType,
					model.ImageFile.InputStream
				);

				return Json(new
				{
					imageBlob = blob,
					previewThumbnailUrl = _imageService.BuildUrl(blob.Name, "Preview", model.ExpectedThumbWidth, model.ExpectedThumbHeight)
				});
			}

			return JsonError(ModelState);
		}
	}
}
