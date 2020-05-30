using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Core.Entities
{
	/// <summary>
	/// Sample location types.
	/// </summary>
	public enum Season : byte
	{
		[Display(Name = "Winter", ResourceType = typeof(CoreResources))]
        winter = 1,

		[Display(Name = "Spring", ResourceType = typeof(CoreResources))]
        spring = 2,

		[Display(Name = "Summer", ResourceType = typeof(CoreResources))]
        summer = 3,

		[Display(Name = "Autumn", ResourceType = typeof(CoreResources))]
        autumn = 4,
        		
	}
}
