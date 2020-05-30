using System;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Alert view model class.
	/// </summary>
	public class AlertViewModel
	{
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the creation date.
		/// </summary>
		public DateTime UTCCreation { get; set; }

		/// <summary>
		/// Gets or sets the icon (E.g. fa fa-thumbs-down bg-danger).
		/// </summary>
		public string Icon { get; set; }

		/// <summary>
		/// Gets or sets the label.
		/// </summary>
		public string Label { get; set; }

		/// <summary>
		/// Gets or sets action link.
		/// </summary>
		public string Href { get; set; }

		/// <summary>
		/// Gets or sets action link target.
		/// </summary>
		public string HrefTarget { get; set; } = "_self";
	}
}
