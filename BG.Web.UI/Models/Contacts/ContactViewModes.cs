using System.ComponentModel.DataAnnotations;

namespace BG.Web.UI.Models
{
	/// <summary>
	/// Represent the possible ways a contact view can be displayed (E.g.: When being shown in a modal).
	/// </summary>
	public enum ContactViewModes : byte
	{
		/// <summary>
		/// Show all form fields.
		/// </summary>
		[Display(Name = "Full")]
		Full = 0,

		/// <summary>
		/// Show only required and primary fields.
		/// </summary>
		[Display(Name = "Simple")]
		Simple = 1,

		/// <summary>
		/// Show only image, required and primary fields.
		/// </summary>
		[Display(Name = "Simple With Picture")]
		SimpleWithPicture = 2,

       
        [Display(Name = "Vizier")]
        Vizier = 3


    }
}
