using BG.Core.Entities;
using System;

namespace BG.Data.Locations
{
	/// <summary>
	/// Partial locations repository implementation.
	/// </summary>
	public partial class LocationsRepository
	{
		/// <summary>
		/// Build the entity object from the query results.
		/// </summary>
		private Func<Location, Blob, Contact, Location> _locationMap = (location, blob, contact) =>
		{
			location.ImageBlob = blob;
			location.Contact = contact;

			return location;
		};
	}
}
