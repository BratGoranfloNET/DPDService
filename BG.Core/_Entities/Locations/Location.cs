using System;

namespace BG.Core.Entities
{
	/// <summary>
	/// Represents a location entity.
	/// </summary>
	public class Location : IEntity
	{
		public const int NameMaxLength = 175;

		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the creation date.
		/// </summary>
		public DateTime UTCCreation { get; set; }

		/// <summary>
		/// Gets or sets the related image blob id.
		/// </summary>
		public Guid? ImageBlobId { get; set; }

		/// <summary>
		/// Gets or sets the related image blob.
		/// </summary>
		public Blob ImageBlob { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		public LocationType? Type { get; set; }

		/// <summary>
		/// Gets or sets the time zone id.
		/// </summary>
		public string TimeZoneId { get; set; }

		/// <summary>
		/// Gets or sets the primary contact id.
		/// </summary>
		public int? ContactId { get; set; }

		/// <summary>
		/// Gets or sets the primary contact.
		/// </summary>
		public Contact Contact { get; set; }

		/// <summary>
		/// Gets or sets the observation notes.
		/// </summary>
		public string Notes { get; set; }
        public string City { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }      

    }
}
