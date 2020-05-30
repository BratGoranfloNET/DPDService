using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Services.Search
{
	/// <summary>
	/// Search results dto.
	/// </summary>
	public class SearchResults
	{
		/// <summary>
		/// Gets or sets the contacts.
		/// </summary>
		public IEnumerable<Contact> Contacts { get; set; }

		/// <summary>
		/// Gets or sets the locations.
		/// </summary>
		public IEnumerable<Location> Locations { get; set; }

		/// <summary>
		/// Gets or sets the events.
		/// </summary>
		public IEnumerable<Event> Events { get; set; }

		/// <summary>
		/// Gets or sets the users.
		/// </summary>
		public IEnumerable<User> Users { get; set; }
	}
}
