using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	
	public partial class TagController
	{
		[HttpPost]
		[Route("image/upload", Name = "TagImageUploadPost")]
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
