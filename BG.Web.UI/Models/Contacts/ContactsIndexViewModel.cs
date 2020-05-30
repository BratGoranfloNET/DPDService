using BG.Core.Entities;
using System.Collections.Generic;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Contacts index view model.
	/// </summary>
	public class ContactsIndexViewModel : BaseViewModel
	{
		/// <summary>
		/// Gets or sets the contacts list.
		/// </summary>
		public IEnumerable<Contact> Contacts { get; set; }
	}
}
