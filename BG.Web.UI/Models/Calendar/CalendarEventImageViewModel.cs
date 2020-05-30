using BG.Core.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Calendar event image view model.
	/// </summary>
	public class CalendarEventImageViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or set the image blob id.
		/// </summary>
		[Display(Name = "EventImageBlobId", ResourceType = typeof(CalendarResources))]
		public Guid? ImageBlobId { get; set; }

		/// <summary>
		/// Gets or set the image blob name.
		/// </summary>
		public string ImageBlobName { get; set; }

		/// <summary>
		/// Gets or sets the order index.
		/// </summary>
		public int OrderIndex { get; set; }

		/// <summary>
		/// Gets or sets the image display label.
		/// </summary>
		[Display(Name = "EventImageLabel", ResourceType = typeof(CalendarResources))]
		public string ImageLabel { get; set; }

		/// <summary>
		/// Gets or sets the image description.
		/// </summary>
		[Display(Name = "EventImageDescription", ResourceType = typeof(CalendarResources))]
		public string ImageDescription { get; set; }

		/// <summary>
		/// Gets or sets the delete flag.
		/// </summary>
		[Display(Name = "EventImageDelete", ResourceType = typeof(CalendarResources))]
		public bool? Delete { get; set; }
	}
}
