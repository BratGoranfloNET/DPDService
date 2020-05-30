using System;

namespace BG.Core.Entities
{
	/// <summary>
	/// Represents an activity entity.
	/// </summary>
	public class Activity : IEntity
	{
		/// <summary>
		/// Gets or sets the id.
		/// </summary>
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the realm where the activity was originated.
		/// </summary>
		public Realm Realm { get; set; }

		/// <summary>
		/// Gets or sets the timestamp for this activity.
		/// </summary>
		public DateTimeOffset Date { get; set; }

		/// <summary>
		/// Gets or sets the activity type.
		/// </summary>
		public ActivityType Type { get; set; }

		/// <summary>
		/// Gets or sets the user that originated the activity.
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Gets or sets the unique signature for this activity.
		/// </summary>
		public Guid Signature { get; set; }
	}
}
