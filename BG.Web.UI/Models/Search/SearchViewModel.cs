using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Search view model.
	/// </summary>
	public class SearchViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the query.
		/// </summary>
		public string Query { get; set; } = string.Empty;

		/// <summary>
		/// Gets or sets the result items.
		/// </summary>
		public List<BaseViewModel> Items { get; set; } = new List<BaseViewModel>();

		/// <summary>
		/// Gets or sets the result medias.
		/// </summary>
		public List<SearchResultMediaViewModel> Medias { get; set; } = new List<SearchResultMediaViewModel>();

		/// <summary>
		/// Constructor method.
		/// </summary>
		public SearchViewModel(string query)
		{
			Query = query;
		}
	}
}
