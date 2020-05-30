using BG.Core.Resources;
using System.ComponentModel.DataAnnotations;

namespace BG.Core.Entities
{
	/// <summary>
	/// Represent all know activity types in the platform.
	/// </summary>
	public enum ActivityType : int
	{
		/// <summary>
		/// User creates its own account.
		/// </summary>
		[Display(Name = "CreatedItsOwnAccount", ResourceType = typeof(TimelineResources))]
		CreatedItsOwnAccount = 0,

		/// <summary>
		/// User update its own profile information.
		/// </summary>
		[Display(Name = "UpdatedItsOwnProfileInformation", ResourceType = typeof(TimelineResources))]
		UpdatedItsOwnProfileInformation = 1,

		/// <summary>
		/// User updates its status message.
		/// </summary>
		[Display(Name = "UpdatedItsOwnStatusMessage", ResourceType = typeof(TimelineResources))]
		UpdatedItsOwnStatusMessage = 2,

		/// <summary>
		/// Come contact is created.
		/// </summary>
		[Display(Name = "ContactCreated", ResourceType = typeof(TimelineResources))]
		ContactCreated = 3,

		/// <summary>
		/// Some contact is updated.
		/// </summary>
		[Display(Name = "ContactUpdated", ResourceType = typeof(TimelineResources))]
		ContactUpdated = 4,

		/// <summary>
		/// Some contact is deleted.
		/// </summary>
		[Display(Name = "ContactDeleted", ResourceType = typeof(TimelineResources))]
		ContactDeleted = 5,

		/// <summary>
		/// Some location is created.
		/// </summary>
		[Display(Name = "LocationCreated", ResourceType = typeof(TimelineResources))]
		LocationCreated = 6,

		/// <summary>
		/// Some location is updated.
		/// </summary>
		[Display(Name = "LocationUpdated", ResourceType = typeof(TimelineResources))]
		LocationUpdated = 7,

		/// <summary>
		/// Some location is deleted.
		/// </summary>
		[Display(Name = "LocationDeleted", ResourceType = typeof(TimelineResources))]
		LocationDeleted = 8,

		/// <summary>
		/// Some event is created.
		/// </summary>
		[Display(Name = "EventCreated", ResourceType = typeof(TimelineResources))]
		EventCreated = 9,

		/// <summary>
		/// Some event is updated.
		/// </summary>
		[Display(Name = "EventUpdated", ResourceType = typeof(TimelineResources))]
		EventUpdated = 10,

		/// <summary>
		/// Some event is deleted.
		/// </summary>
		[Display(Name = "EventDeleted", ResourceType = typeof(TimelineResources))]
		EventDeleted = 11,

		/// <summary>
		/// User update its own general settings.
		/// </summary>
		[Display(Name = "UpdatedItsOwnGeneralSettings", ResourceType = typeof(TimelineResources))]
		UpdatedItsOwnGeneralSettings = 12,


        /// <summary>
		/// Some location is created.
		/// </summary>
		[Display(Name = "TenderCreated", ResourceType = typeof(TimelineResources))]
        TenderCreated = 13,

        /// <summary>
        /// Some location is updated.
        /// </summary>
        [Display(Name = "TenderUpdated", ResourceType = typeof(TimelineResources))]
        TenderUpdated = 14,

        /// <summary>
        /// Some location is deleted.
        /// </summary>
        [Display(Name = "TenderDeleted", ResourceType = typeof(TimelineResources))]
        TenderDeleted = 15,


    }
}
