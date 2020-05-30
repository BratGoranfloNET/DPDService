using Omu.ValueInjecter;
using BG.Web.UI.Models;
using System.Web.Mvc;

namespace BG.Web.UI.Controllers
{
	/// <summary>
	/// Partial calendar controller.
	/// </summary>
	public partial class CalendarController
	{
		/// <summary>
		/// Post / Events delete action.
		/// </summary>
		[HttpPost]
		[Route("events/image/upload", Name = "CalendarEventsImageUploadPost")]
		public ActionResult EventsImageUpload(ImageUploadViewModel model)
		{
			if (ModelState.IsValid)
			{
				var blob = _imageService.Upload(
					model.ImageFile.FileName,
					model.ImageFile.ContentType,
					model.ImageFile.InputStream
				);

				var eventImageViewModel = Mapper.Map<CalendarEventImageViewModel>(blob);

				return Json(new
				{
					imageBlob = blob,
					imageHtml = RenderPartialViewToString("EventImage", eventImageViewModel),
					previewThumbnailUrl = _imageService.BuildUrl(blob.Name, "Preview", model.ExpectedThumbWidth, model.ExpectedThumbHeight)
				});
			}

			return JsonError(ModelState);
		}
	}
}