using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Locations index view model.
	/// </summary>
	public class LocationsIndexViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the locations list.
		/// </summary>
		public IEnumerable<Location> Locations { get; set; }
	}
}
