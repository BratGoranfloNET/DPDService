using System;
using System.Collections.Generic;

namespace BG.Core.Entities
{
	/// <summary>
	/// Represents an event entity.
	/// </summary>
	public class Event : IEntity
	{
		public const int NameMaxLength = 175;

		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the UTC creation date.
		/// </summary>
		public DateTime UTCCreation { get; set; }

		/// <summary>
		/// Gets or sets the name.
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the color.
		/// </summary>
		public string Color { get; set; }

		/// <summary>
		/// Gets or sets the all day flag.
		/// </summary>
		public bool AllDay { get; set; }

		/// <summary>
		/// Gets or sets the start date.
		/// </summary>
		public DateTimeOffset StartDate { get; set; }

		/// <summary>
		/// Gets or sets the end date.
		/// </summary>
		public DateTimeOffset EndDate { get; set; }

		/// <summary>
		/// Gets or sets the related location id.
		/// </summary>
		public int? LocationId { get; set; }
        public int? StateUnitedId { get; set; }
       
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        public string Description { get; set; }

		/// <summary>
		/// Gets or sets the related location entity.
		/// </summary>
		public Location Location { get; set; }

		/// <summary>
		/// Gets or sets the related event contacts.
		/// </summary>
		public List<Contact> Contacts { get; set; } = new List<Contact>();

		/// <summary>
		/// Gets or sets the related event images.
		/// </summary>
		public List<EventImage> Images { get; set; } = new List<EventImage>();
        
        public int? EventTypeId { get; set; }
        public EventType EventType { get; set; }
        public string Fio { get; set; }

    }
}
