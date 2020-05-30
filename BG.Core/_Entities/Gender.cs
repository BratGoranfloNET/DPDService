using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Core.Entities
{
	/// <summary>
	/// Available gender types.
	/// </summary>
	public enum Gender : byte
	{
		/// <summary>
		/// #1 Male
		/// </summary>
		[Display(Name = "GenderMale", ResourceType = typeof(CoreResources))]
		Male = 1,

		/// <summary>
		/// #2 Female
		/// </summary>
		[Display(Name = "GenderFemale", ResourceType = typeof(CoreResources))]
		Female = 2,

		/// <summary>
		/// #0 Not Specified
		/// </summary>
		[Display(Name = "GenderNotSpecified", ResourceType = typeof(CoreResources))]
		NotSpecified = 0
	}
}
