using BG.Core.Context;
using BG.Core.Repositories;

namespace BG.Services.Search
{
	/// <summary>
	/// Partial search service implementation.
	/// </summary>
	public partial class SearchService : ISearchService
	{
		private IWebContext _webContext = null;
		private IContactsRepository _contactsRepository = null;
		private ILocationsRepository _locationsRepository = null;
		private IEventsRepository _eventsRepository = null;
		private IUsersRepository _usersRepository = null;

		/// <summary>
		/// Constructor method.
		/// </summary>
		public SearchService(IWebContext webContext, IContactsRepository contactsRepository, ILocationsRepository locationsRepository, IEventsRepository eventsRepository, IUsersRepository usersRepository)
		{
			_webContext = webContext;
			_contactsRepository = contactsRepository;
			_locationsRepository = locationsRepository;
			_eventsRepository = eventsRepository;
			_usersRepository = usersRepository;
		}
	}
}
