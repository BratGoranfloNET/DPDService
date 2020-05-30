using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Core.Repositories
{
	/// <summary>
	/// Contacts repository interface.
	/// </summary>
	public interface IContactsRepository : ISimpleRepository<Contact>,
                                           ISearchableRepository<Contact>
                                          
    {
		/// <summary>
		/// Get entities by type.
		/// </summary>
		IEnumerable<Contact> GetAllByType(params ContactType[] contactTypes);
	}
}
