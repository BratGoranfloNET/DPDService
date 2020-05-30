namespace BG.Web.UI.Models
{
	/// <summary>
	/// View models base class.
	/// </summary>
	public abstract class BaseViewModel
	{
		/// <summary>
		/// Gets or sets the current page name.
		/// </summary>
		public string PageLabel { get; set; }

		/// <summary>
		/// Gets or sets the current page meta description.
		/// </summary>
		public string PageMetaDescription { get; set; }

		/// <summary>
		/// Gets or sets the current section label.
		/// </summary>
		public string SectionLabel { get; set; }

		/// <summary>
		/// Gets or sets the search context html element class.
		/// </summary>
		public bool IsSearchResultsContext { get; set; }

		/// <summary>
		/// Gets or sets the value indicating whether the main overlay loader is enabled.
		/// </summary>
		public bool IsOverlayLoaderEnabled { get; set; }

		/// <summary>
		/// Gets or sets the value indicating whether the page has toolbars.
		/// </summary>
		public bool HasToolbar { get; set; }
	}
}
