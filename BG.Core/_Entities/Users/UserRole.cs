namespace BG.Core.Entities
{
	/// <summary>
	/// Represents a user role entity.
	/// </summary>
	public class UserRole : IEntity
	{
		/// <summary>
		/// Gets or sets the user id.
		/// </summary>
		public int UserId { get; set; }

		/// <summary>
		/// Gets or sets the role.
		/// </summary>
		public Role Role { get; set; }
	}
}
