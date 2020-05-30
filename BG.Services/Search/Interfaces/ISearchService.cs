namespace BG.Services.Search
{
	/// <summary>
	/// Search service interface.
	/// </summary>
	public interface ISearchService
	{
		/// <summary>
		/// Search known contents.
		/// </summary>
		SearchResults Search(string query);
	}
}
