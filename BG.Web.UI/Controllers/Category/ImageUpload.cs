using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial locations controller.
	/// </summary>
	public partial class CategoryController
	{
		/// <summary>
		/// POST / Image upload action.
		/// </summary>
		[HttpPost]
		[Route("image/upload", Name = "CategoryImageUploadPost")]
		public ActionResult ImageUpload(ImageUploadViewModel model)
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
