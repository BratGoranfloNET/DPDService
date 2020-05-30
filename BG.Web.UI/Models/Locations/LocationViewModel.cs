using BG.Core.Entities;
using BG.Core.Resources;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Location view model.
	/// </summary>
	public class LocationViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the image file max length in bytes.
		/// </summary>
		public long ImageUploadMaxLengthInBytes { get; set; } = 0;

		/// <summary>
		/// Gets or set the image blob name.
		/// </summary>
		public string ImageBlobName { get; set; }

		/// <summary>
		/// Gets or set the id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or set the image blob id.
		/// </summary>
		[Display(Name = "ImageBlobId", ResourceType = typeof(LocationResources))]
		public Guid? ImageBlobId { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		[Display(Name = "Name", ResourceType = typeof(LocationResources))]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		[Display(Name = "Type", ResourceType = typeof(LocationResources))]
		public LocationType? Type { get; set; }

		/// <summary>
		/// Gets or sets the time zone id.
		/// </summary>
		[Display(Name = "TimeZoneId", ResourceType = typeof(LocationResources))]
		public string TimeZoneId { get; set; }

		/// <summary>
		/// Gets or sets the timezones.
		/// </summary>
		public SelectList TimeZones { get; set; }

		/// <summary>
		/// Gets or sets the primary contact id.
		/// </summary>
		[Display(Name = "ContactId", ResourceType = typeof(LocationResources))]
		public int? ContactId { get; set; }

		/// <summary>
		/// Gets or sets the related observation notes.
		/// </summary>
		[Display(Name = "Notes", ResourceType = typeof(LocationResources))]
		public string Notes { get; set; }

		/// <summary>
		/// Gets or sets the contacts list.
		/// </summary>
		public SelectList Contacts { get; set; }



        [Display(Name = "Город")]
        public string City { get; set; }



        [Display(Name = "Широта")]
        public string Latitude { get; set; }


        [Display(Name = "Долгота")]
        public string Longitude { get; set; }



    }
}
