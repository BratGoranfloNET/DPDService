using BG.Core.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BG.Data.Contacts
{
	/// <summary>
	/// Partial contacts repository implementation.
	/// </summary>
	public partial class ContactsRepository
	{
		/// <summary>
		/// Get entities.
		/// </summary>
		public IEnumerable<Contact> GetAllByType(params ContactType[] contactTypes)
		{
			var entities = GetAll();

			return entities.Where(c => contactTypes.Contains(c.Type)).ToList();
		}
	}
}
