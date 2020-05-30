using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Core.Entities
{
	/// <summary>
	/// Sample location types.
	/// </summary>
	public enum LocationType : byte
	{
		[Display(Name = "LocationType1", ResourceType = typeof(CoreResources))]
		LocationType1 = 1,

		[Display(Name = "LocationType2", ResourceType = typeof(CoreResources))]
		LocationType2 = 2,

		[Display(Name = "LocationType3", ResourceType = typeof(CoreResources))]
		LocationType3 = 3,

		[Display(Name = "LocationType4", ResourceType = typeof(CoreResources))]
		LocationType4 = 4,

		[Display(Name = "LocationType5", ResourceType = typeof(CoreResources))]
		LocationType5 = 5
	}
}
