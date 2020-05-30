using BG.Core.Entities;

namespace BG.Services.Search
{
	/// <summary>
	/// Partial search service implementation.
	/// </summary>
	public partial class SearchService
	{
		/// <summary>
		/// Search known contents.
		/// </summary>
		public SearchResults Search(string query)
		{
			var results = new SearchResults();

			results.Contacts = _contactsRepository.Search(query);
			results.Locations = _locationsRepository.Search(query);
			results.Events = _eventsRepository.Search(query);

			if (_webContext.User.IsInRole(Role.Admin))
				results.Users = _usersRepository.Search(query);

			return results;
		}
	}
}
