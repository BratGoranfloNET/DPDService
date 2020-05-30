using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Single image upload view model.
	/// </summary>
	public class ImageUploadViewModel
	{
		/// <summary>
		/// Gets or sets the posted image file.
		/// </summary>
		[Display(Name = "Image")]
		public HttpPostedFileBase ImageFile { get; set; }

		/// <summary>
		/// Gets or sets the expected preview thumbnail width.
		/// </summary>
		public int? ExpectedThumbWidth { get; set; }

		/// <summary>
		/// Gets or sets the expected preview thumbnail heigth.
		/// </summary>
		public int? ExpectedThumbHeight { get; set; }
	}
}
