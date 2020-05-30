using BG.Core.Resources;
using System;
using System.ComponentModel.DataAnnotations;

namespace BG.Core.Entities
{
	/// <summary>
	/// Represents the set of role names recognized by the platform.
	/// </summary>
	[Flags]
	public enum Role
	{
		/// <summary>
		/// #0 - User
		/// </summary>
		[Display(Name = "RoleUser", ResourceType = typeof(CoreResources))]
		User = 1,

		/// <summary>
		/// #1 - Admin
		/// </summary>
		[Display(Name = "RoleAdmin", ResourceType = typeof(CoreResources))]
		Admin = 2,      
       

        // Use powers of two for flag operations
        //Sample = 4,
        //Sample = 8,
        //Sample = 16,
        //Sample = 32,
        //Sample = 64,
        //Sample...
    }
}
