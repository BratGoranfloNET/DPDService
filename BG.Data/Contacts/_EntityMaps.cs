using BG.Core.Entities;
using System;

namespace BG.Data.Contacts
{
	/// <summary>
	/// Partial contacts repository implementation.
	/// </summary>
	public partial class ContactsRepository
	{
		/// <summary>
		/// Build the entity object from the query results.
		/// </summary>
		private Func<Contact, Blob, Contact> _contactMap = (contact, blob) =>
		{
			contact.ImageBlob = blob;

			return contact;
		};
	}
}
