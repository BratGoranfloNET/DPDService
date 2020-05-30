using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Core.Entities
{
	/// <summary>
	/// Known systems that can access the platform information.
	/// </summary>
	public enum Realm
	{
		/// <summary>
		/// #0 AdminWebsite
		/// </summary>
		[Display(Name = "RealmBG", ResourceType = typeof(CoreResources))]
		BG = 0,

		/// <summary>
		/// #1 WebApi
		/// </summary>
		[Display(Name = "RealmWebApi", ResourceType = typeof(CoreResources))]
		WebApi = 1
	}
}
